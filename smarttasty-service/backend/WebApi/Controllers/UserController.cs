using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Models.Requests.User;
using backend.Domain.Models.Requests.Auth;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        private IActionResult CreateResult<T>(ApiResponse<T> result)
        {
            if (result == null)
            {
                return StatusCode(500, new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ServerError,
                    ErrMessage = "Invalid response format",
                    Data = null
                });
            }
            return StatusCode(result.ErrCode == ErrorCode.Success ? 200 : 400, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> HandleLogin([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.UserPassword))
            {
                return BadRequest(new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Missing input parameters"
                });
            }

            var result = await _userService.HandleUserLogin(request.Email, request.UserPassword);

            if (result.ErrCode != ErrorCode.Success)
                return BadRequest(result);

            // --- ADDED: bảo vệ null trước khi cast sang dynamic ---
            if (result.Data == null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ServerError,
                    ErrMessage = "Login succeeded but no response data."
                });
            }

            var data = result.Data as dynamic;
            var refreshToken = data?.refresh_token?.ToString();

            if (!string.IsNullOrEmpty(refreshToken))
            {
                Response.Cookies.Append("refresh_token", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,          // dùng HTTPS mới bật
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });
            }

            // chỉ trả access token cho FE
            return Ok(new
            {
                access_token = data?.access_token,
                user = data?.user
            });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refresh_token"];
            var accessToken = Request.Headers["Authorization"].ToString()?.Replace("Bearer ", "");

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
                return BadRequest(new ApiResponse<object> { ErrCode = ErrorCode.ValidationError, ErrMessage = "Missing tokens." });

            var result = await _userService.RefreshTokenAsync(accessToken, refreshToken);

            if (result.ErrCode != ErrorCode.Success)
                return BadRequest(result);

            // --- ADDED: bảo vệ null trước khi cast sang dynamic ---
            if (result.Data == null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ServerError,
                    ErrMessage = "Refresh succeeded but no response data."
                });
            }

            var data = result.Data as dynamic;
            var newRefreshToken = data?.refresh_token?.ToString();

            if (!string.IsNullOrEmpty(newRefreshToken))
            {
                Response.Cookies.Append("refresh_token", newRefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });
            }

            return Ok(new { access_token = data?.access_token });
        }

        [HttpPost("logout/{userId}")]
        public async Task<IActionResult> HandleLogout(int userId)
        {
            var result = await _userService.HandleUserLogout(userId);

            Response.Cookies.Delete("refresh_token");

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> HandleGetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return CreateResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> HandleGetUserById(int id)
        {
            if (id == 0)
            {
                return CreateResult(new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Missing required parameter"
                });
            }

            var result = await _userService.GetUserById(id);
            return CreateResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> HandleCreateNewUser([FromBody] CreateUserRequest request)
        {
            var result = await _userService.CreateNewUser(request);
            return CreateResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> HandleUpdateUser([FromBody] UpdateUserRequest request)
        {
            var result = await _userService.UpdateUserData(request);
            return CreateResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HandleDeleteUser(int id)
        {
            if (id == 0)
            {
                return CreateResult(new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Missing required parameter"
                });
            }

            var result = await _userService.DeleteUser(id);
            return CreateResult(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] EmailDtoRequest request)
        {
            var result = await _userService.SendResetPasswordEmail(request.Email);
            return CreateResult(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _userService.ResetPassword(request.Token, request.NewPassword);
            return CreateResult(result);
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var result = await _userService.ChangePasswordAsync(userIdClaim.Value, request.CurrentPassword, request.NewPassword);

            if (result.ErrCode != ErrorCode.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}