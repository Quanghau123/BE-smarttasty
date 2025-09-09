using backend.Domain.Models;
using backend.Domain.Models.Requests.User;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<object>> HandleUserLogin(string email, string password);
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