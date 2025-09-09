using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Application.DTOs.Review;
using backend.Domain.Models.Requests.Review;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IReviewService
    {
        Task<ApiResponse<ReviewDTO>> CreateReviewAsync(CreateReviewRequest request);
        Task<ApiResponse<List<ReviewDTO>>> GetAllAsync();
        Task<ApiResponse<ReviewDTO?>> GetByIdAsync(int id);
        Task<ApiResponse<List<ReviewDTO>>> SearchAsync(string keyword);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
