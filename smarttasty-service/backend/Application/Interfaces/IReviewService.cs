using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Application.DTOs.Review;
using backend.Domain.Models.Requests.Review;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using backend.Application.DTOs.Commons;
using backend.Domain.Models.Requests.Filters;

namespace backend.Application.Interfaces
{
    public interface IReviewService
    {
        Task<ApiResponse<ReviewDTO>> CreateReviewAsync(CreateReviewRequest request);
        Task<ApiResponse<PagedDto<ReviewDTO>>> GetAllAsync(PagedRequest filter);
        Task<ApiResponse<ReviewDTO?>> GetByIdAsync(int id);
        Task<ApiResponse<PagedDto<ReviewDTO>>> GetByRestaurantIdAsync(int id, PagedRequest filter);
        Task<ApiResponse<List<ReviewDTO>>> SearchAsync(string keyword);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
