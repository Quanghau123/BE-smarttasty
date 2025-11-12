using backend.Domain.Models.Requests.Favorite;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IFavoriteService
    {
        Task<ApiResponse<object>> CreateFavoriteAsync(CreateFavoriteRequest request);
        Task<ApiResponse<object>> DeleteAsync(int id);
        Task<ApiResponse<object>> GetFavoritesByRestaurantAsync(int restaurantId);

    }
}
