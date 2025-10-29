using backend.Domain.Models;
using backend.Domain.Models.Requests.User;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Application.DTOs.Auth;

namespace backend.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<LoginResponseDto>> HandleUserLogin(string email, string password);
        Task<ApiResponse<TokenResponseDto>> RefreshTokenAsync(string accessToken, string refreshToken);
        Task<ApiResponse<object>> HandleUserLogout(int userId);
        Task<ApiResponse<object>> GetAllUsers();
        Task<ApiResponse<object>> GetUserById(int id);
        Task<ApiResponse<object>> CreateNewUser(CreateUserRequest data);
        Task<ApiResponse<object>> UpdateUserData(UpdateUserRequest data);
        Task<ApiResponse<object>> DeleteUser(int id);
        Task<ApiResponse<object>> SendResetPasswordEmail(string email);
        Task<ApiResponse<object>> ResetPassword(string token, string newPassword);
        Task<ApiResponse<object>> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    }
}