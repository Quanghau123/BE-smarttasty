using backend.Domain.Enums;
using backend.Domain.Models;
using backend.Application.DTOs.Restaurant;
using backend.Domain.Models.Requests.Restaurant;
using backend.Domain.Models.Requests.Filters;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Interfaces
{
    public interface IRestaurantService
    {
        Task<ApiResponse<object>> GetAllRestaurantsAsync(PagedRequest filter);
        Task<ApiResponse<object>> GetRestaurantByIdAsync(int id);
        Task<ApiResponse<RestaurantDto>> CreateNewRestaurantAsync(CreateRestaurantRequest request);
        Task<ApiResponse<RestaurantDto>> UpdateRestaurantAsync(UpdateRestaurantRequest restaurant);
        Task<ApiResponse<object>> DeleteRestaurantAsync(int id);
        Task<ApiResponse<List<RestaurantDto>>> GetRestaurantsByOwnerIdAsync(int ownerId);
        Task<ApiResponse<List<RestaurantDto>>> SearchRestaurantsByOwnerKeywordAsync(string keyword);
        Task<ApiResponse<List<RestaurantDto>>> GetRestaurantsByCategoryAsync(RestaurantCategory category);
        Task<ApiResponse<List<RestaurantDto>>> SearchRestaurantsAsync(string query);
        Task<List<string>> GetSuggestionsAsync(string query);
        Task<ApiResponse<object>> ChangeRestaurantStatusAsync(int restaurantId, RestaurantStatus status);
        Task<List<RestaurantDto>> GetNearbyRestaurantsAsync(double userLat, double userLng, double radiusKm = 5);
    }
}
