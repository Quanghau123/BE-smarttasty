using AutoMapper;
using AutoMapper.QueryableExtensions;
using backend.Infrastructure.Configurations;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers;
using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Models.Requests.User;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Messaging.Kafka;
using backend.Application.DTOs.KafkaPayload;
using backend.Application.DTOs.Kafka;
using backend.Application.DTOs.Auth;
using backend.Domain.Enums;
using backend.Application.DTOs.User;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtSettings _jwtSettings;
        private readonly IConfiguration _config;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext context, IOptions<JwtSettings> jwtOptions, IConfiguration config, KafkaProducerService kafkaProducer, IMapper mapper)
        {
            _mapper = mapper;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _jwtSettings = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions));
            _config = config;
            _kafkaProducer = kafkaProducer;

            if (string.IsNullOrEmpty(_jwtSettings.SecretKey))
                throw new InvalidOperationException("SecretKey is not configured.");
        }

        private string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        public async Task<ApiResponse<LoginResponseDto>> HandleUserLogin(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return new ApiResponse<LoginResponseDto> { ErrCode = ErrorCode.NotFound, ErrMessage = "Email does not exist." };

            if (!BCrypt.Net.BCrypt.Verify(password, user.UserPassword))
                return new ApiResponse<LoginResponseDto> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Wrong password" };

            var oldTokens = _context.RefreshTokens
                .Where(t => t.UserId == user.UserId && (t.IsRevoked || t.ExpiresAt < DateTime.UtcNow));

            _context.RefreshTokens.RemoveRange(oldTokens);
            await _context.SaveChangesAsync();

            var accessToken = GenerateAccessToken(user);

            var refreshToken = new RefreshToken
            {
                UserId = user.UserId,
                Token = Guid.NewGuid().ToString(),
                ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpireDays),
                CreatedAt = DateTime.UtcNow
            };
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            var loginEvent = new KafkaEnvelope<UserLoggedInPayload>
            {
                Event = "UserLoggedIn",
                Target = user.UserId.ToString(),
                Payload = new UserLoggedInPayload
                {
                    UserId = user.UserId.ToString(),
                    Username = user.UserName,
                    Role = user.Role.ToString(),
                    Jwt = accessToken,
                    Timestamp = DateTime.UtcNow
                }
            };

            await _kafkaProducer.SendMessageAsync(loginEvent, topic: "chatbot-auth");
            await _kafkaProducer.SendMessageAsync(loginEvent, topic: "login");

            var dto = new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                User = new LoginUserDto
                {
                    UserId = user.UserId,
                    UserName = user.UserName ?? string.Empty,
                    Role = user.Role.ToString()
                }
            };

            return new ApiResponse<LoginResponseDto>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Login success",
                Data = dto
            };
        }
        public async Task<ApiResponse<TokenResponseDto>> RefreshTokenAsync(string accessToken, string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;

            try
            {
                var principal = tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.SecretKey)),
                    ValidateLifetime = false // cho phép token hết hạn để đọc claim
                }, out validatedToken);

                var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim))
                    return new ApiResponse<TokenResponseDto> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Invalid token." };

                var dbToken = await _context.RefreshTokens
                    .FirstOrDefaultAsync(x => x.Token == refreshToken && x.UserId.ToString() == userIdClaim && !x.IsRevoked && x.ExpiresAt > DateTime.UtcNow);

                if (dbToken == null)
                    return new ApiResponse<TokenResponseDto> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Refresh token is invalid or expired." };

                var user = await _context.Users.FindAsync(int.Parse(userIdClaim));
                if (user == null)
                    return new ApiResponse<TokenResponseDto> { ErrCode = ErrorCode.NotFound, ErrMessage = "User not found." };

                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                var newTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                        new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpireMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var newAccessToken = tokenHandler.CreateToken(newTokenDescriptor);
                var jwt = tokenHandler.WriteToken(newAccessToken);

                dbToken.IsRevoked = true;
                var newRefreshToken = new RefreshToken
                {
                    UserId = user.UserId,
                    Token = Guid.NewGuid().ToString(),
                    ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpireDays),
                    CreatedAt = DateTime.UtcNow
                };

                _context.RefreshTokens.Add(newRefreshToken);
                await _context.SaveChangesAsync();

                var refreshEvent = new KafkaEnvelope<UserTokenRefreshedPayload>
                {
                    Event = "UserTokenRefreshed",
                    Target = user.UserId.ToString(),
                    Payload = new UserTokenRefreshedPayload
                    {
                        UserId = user.UserId.ToString(),
                        Username = user.UserName ?? string.Empty,
                        Role = user.Role.ToString(),
                        AccessToken = jwt
                    }
                };

                await _kafkaProducer.SendMessageAsync(refreshEvent, topic: "user-events-token-refreshed");

                var dto = new TokenResponseDto
                {
                    AccessToken = jwt,
                    RefreshToken = newRefreshToken.Token
                };

                return new ApiResponse<TokenResponseDto>
                {
                    ErrCode = ErrorCode.Success,
                    ErrMessage = "Token refreshed successfully.",
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<TokenResponseDto> { ErrCode = ErrorCode.ServerError, ErrMessage = $"Token refresh failed: {ex.Message}" };
            }
        }
        public async Task<ApiResponse<object>> HandleUserLogout(int userId)
        {
            var tokens = _context.RefreshTokens.Where(t => t.UserId == userId && !t.IsRevoked);
            foreach (var token in tokens)
                token.IsRevoked = true;

            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Logged out and refresh tokens revoked.",
                Data = null
            };
        }

        public async Task<ApiResponse<object>> GetAllUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.UserId,
                    u.UserName,
                    u.Email,
                    u.Phone,
                    Role = u.Role.ToString(),
                    u.Address,
                    u.IsActive,
                    u.CreatedAt
                })
                .ToListAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = users
            };
        }

        public async Task<ApiResponse<object>> GetUserById(int id)
        {
            var user = await _context.Users
                .Where(u => u.UserId == id)
                .Select(u => new
                {
                    u.UserId,
                    u.UserName,
                    u.Email,
                    u.Phone,
                    Role = u.Role.ToString(),
                    u.Address,
                    u.IsActive,
                    u.CreatedAt
                })
                .FirstOrDefaultAsync();

            if (user == null)
                return new ApiResponse<object> { ErrCode = ErrorCode.NotFound, ErrMessage = "User not found" };

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = user
            };
        }

        public async Task<ApiResponse<object>> CreateNewUser(CreateUserRequest data)
        {
            if (!ValidationHelper.IsValidEmail(data.Email))
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Invalid email." };
            }

            if (!ValidationHelper.IsValidPhone(data.Phone))
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Invalid phone number." };
            }

            if (!ValidationHelper.IsValidPassword(data.UserPassword))
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Invalid password." };
            }

            if (await _context.Users.AnyAsync(u => u.Email == data.Email))
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Email is already in use." };
            }

            var user = new User
            {
                UserName = data.UserName,
                Email = data.Email,
                Phone = data.Phone,
                Address = data.Address,
                Role = data.Role,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(data.UserPassword)
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Account created successfully.",
                Data = new { user.UserId, user.UserName, user.Email }
            };
        }

        public async Task<ApiResponse<object>> UpdateUserData(UpdateUserRequest data)
        {
            var user = await _context.Users.FindAsync(data.UserId);
            if (user == null)
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.NotFound, ErrMessage = "User not found" };
            }

            if (!ValidationHelper.IsValidEmail(data.Email))
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Invalid email." };
            }

            if (!ValidationHelper.IsValidPhone(data.Phone))
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Invalid phone number (must be a Vietnamese number starting with 03, 05, 07, 08, 09 and having 10 digits)." };
            }

            if (await _context.Users.AnyAsync(u => u.Email == data.Email && u.UserId != data.UserId))
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Email is already in use." };
            }
            user.UserName = data.UserName;
            user.Email = data.Email;
            user.Phone = data.Phone;
            user.Address = data.Address;
            user.Role = data.Role;
            user.IsActive = data.IsActive;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new ApiResponse<object> { ErrCode = ErrorCode.Success, ErrMessage = "User updated successfully!" };
        }

        public async Task<ApiResponse<object>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return new ApiResponse<object> { ErrCode = ErrorCode.NotFound, ErrMessage = "User does not exist" };

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "User deleted successfully."
            };
        }

        public async Task<ApiResponse<object>> SendResetPasswordEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.NotFound, ErrMessage = "Email không tồn tại trong hệ thống." };
            }

            var existingToken = await _context.PasswordResetTokens
                .FirstOrDefaultAsync(t => t.UserId == user.UserId && !t.IsUsed);

            if (existingToken != null)
            {
                _context.PasswordResetTokens.Remove(existingToken);
            }

            var resetToken = Guid.NewGuid().ToString();
            var expiration = DateTime.UtcNow.AddMinutes(30);

            _context.PasswordResetTokens.Add(new PasswordResetToken
            {
                UserId = user.UserId,
                Token = resetToken,
                Expiration = expiration,
                IsUsed = false
            });

            await _context.SaveChangesAsync();

            var resetLink = $"http://localhost:3000/reset-password?token={resetToken}";

            var resetEvent = new KafkaEnvelope<PasswordResetRequestedPayload>
            {
                Event = "PasswordResetRequested",
                Target = user.UserId.ToString(),
                Payload = new PasswordResetRequestedPayload
                {
                    UserId = user.UserId.ToString(),
                    Email = user.Email,
                    Username = user.UserName,
                    Token = resetToken,
                    ResetLink = resetLink,
                    ExpiresAt = expiration
                }
            };

            await _kafkaProducer.SendMessageAsync(resetEvent, topic: "notifications");

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Password reset request queued (notification service will send email)."
            };
        }

        public async Task<ApiResponse<object>> ResetPassword(string token, string newPassword)
        {
            if (!ValidationHelper.IsValidPassword(newPassword))
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Password must contain uppercase, lowercase, numbers, special characters and be longer than 5 characters."
                };
            }

            var tokenEntry = await _context.PasswordResetTokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Token == token && !t.IsUsed && t.Expiration > DateTime.UtcNow);

            if (tokenEntry == null)
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Token is invalid or expired." };
            }

            var user = tokenEntry.User;
            if (user == null)
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.NotFound, ErrMessage = "User does not exist." };
            }

            user.UserPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
            tokenEntry.IsUsed = true;

            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Password changed successfully!"
            };
        }

        public async Task<ApiResponse<object>> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            if (!int.TryParse(userId, out int parsedUserId))
            {
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Invalid User ID." };
            }

            var user = await _context.Users.FindAsync(parsedUserId);
            if (user == null)
                return new ApiResponse<object> { ErrCode = ErrorCode.NotFound, ErrMessage = "User does not exist." };

            bool isCurrentPasswordValid = BCrypt.Net.BCrypt.Verify(currentPassword, user.UserPassword);
            if (!isCurrentPasswordValid)
                return new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Old password is incorrect." };

            if (!ValidationHelper.IsValidPassword(newPassword))
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "New password must contain uppercase, lowercase, numbers, special characters and be longer than 5 characters."
                };
            }

            user.UserPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Password changed successfully."
            };
        }

        public async Task<ApiResponse<object>> CreateStaffAsync(CreateStaffRequest request, int businessOwnerId)
        {
            var owner = await _context.Users.FindAsync(businessOwnerId);
            if (owner == null || owner.Role != UserRole.business)
                return new ApiResponse<object>(ErrorCode.NotFound, "Business owner not found");

            if (string.IsNullOrWhiteSpace(request.UserName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Phone))
                return new ApiResponse<object>(ErrorCode.ValidationError, "UserName, Email and Phone are required");

            if (!ValidationHelper.IsValidEmail(request.Email))
                return new ApiResponse<object>(ErrorCode.ValidationError, "Invalid email");

            if (await _context.Users.AnyAsync(u => u.Email.ToLower() == request.Email.ToLower()))
                return new ApiResponse<object>(ErrorCode.ValidationError, "Email already used");

            var password = string.IsNullOrWhiteSpace(request.Password)
                ? Guid.NewGuid().ToString("N").Substring(0, 8)
                : request.Password!;

            var staff = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address ?? string.Empty,
                Role = UserRole.staff,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(password),
                BusinessOwnerId = businessOwnerId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _context.Users.AddAsync(staff);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>(ErrorCode.Success, "Staff created", _mapper.Map<StaffDto>(staff));
        }

        public async Task<ApiResponse<object>> GetStaffsByBusinessAsync(int businessOwnerId)
        {
            var owner = await _context.Users.FindAsync(businessOwnerId);
            if (owner == null || owner.Role != UserRole.business)
                return new ApiResponse<object>(ErrorCode.NotFound, "Business owner not found");

            var staffs = await _context.Users
                .Where(u => u.BusinessOwnerId == businessOwnerId && u.Role == UserRole.staff)
                .Select(u => new StaffDto
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    Email = u.Email,
                    Phone = u.Phone,
                    Address = u.Address,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt,
                    BusinessOwnerId = u.BusinessOwnerId,
                    BusinessOwnerName = u.BusinessOwner != null ? u.BusinessOwner.UserName : null,
                    Restaurants = _context.Restaurants
                        .Where(r => r.OwnerId == businessOwnerId)
                        .Select(r => new RestaurantSimpleDto
                        {
                            Id = r.Id,
                            Name = r.Name
                        })
                        .ToList()
                })
                .ToListAsync();

            return new ApiResponse<object>(ErrorCode.Success, "OK", staffs);
        }

        public async Task<ApiResponse<object>> UpdateStaffAsync(UpdateStaffRequest request, int businessOwnerId)
        {
            var owner = await _context.Users.FindAsync(businessOwnerId);
            if (owner == null || owner.Role != UserRole.business)
                return new ApiResponse<object>(ErrorCode.NotFound, "Business owner not found");

            var staff = await _context.Users.FindAsync(request.UserId);
            if (staff == null || staff.Role != UserRole.staff || staff.BusinessOwnerId != businessOwnerId)
                return new ApiResponse<object>(ErrorCode.NotFound, "Staff not found or not managed by this business");

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                if (!ValidationHelper.IsValidEmail(request.Email))
                    return new ApiResponse<object>(ErrorCode.ValidationError, "Invalid email");

                if (await _context.Users.AnyAsync(u => u.Email.ToLower() == request.Email.ToLower() && u.UserId != staff.UserId))
                    return new ApiResponse<object>(ErrorCode.ValidationError, "Email already used");

                staff.Email = request.Email;
            }

            if (!string.IsNullOrWhiteSpace(request.UserName)) staff.UserName = request.UserName;
            if (!string.IsNullOrWhiteSpace(request.Phone)) staff.Phone = request.Phone;
            if (!string.IsNullOrWhiteSpace(request.Address)) staff.Address = request.Address;
            if (request.IsActive.HasValue) staff.IsActive = request.IsActive.Value;

            _context.Users.Update(staff);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>(ErrorCode.Success, "Staff updated", _mapper.Map<StaffDto>(staff));
        }

        public async Task<ApiResponse<object>> DeleteStaffAsync(int staffId, int businessOwnerId)
        {
            var owner = await _context.Users.FindAsync(businessOwnerId);
            if (owner == null || owner.Role != UserRole.business)
                return new ApiResponse<object>(ErrorCode.NotFound, "Business owner not found");

            var staff = await _context.Users.FindAsync(staffId);
            if (staff == null || staff.Role != UserRole.staff || staff.BusinessOwnerId != businessOwnerId)
                return new ApiResponse<object>(ErrorCode.NotFound, "Staff not found or not managed by this business");

            _context.Users.Remove(staff);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>(ErrorCode.Success, "Staff deleted");
        }
    }
}