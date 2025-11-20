using backend.Domain.Models;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Application.DTOs.Dish;
using backend.Application.DTOs.Commons;
using backend.Domain.Models.Requests.Filters;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace backend.Application.Interfaces
{
    public interface IDishService
    {
        Task<ApiResponse<DishDto?>> CreateDishAsync(Dish dish, IFormFile? file);
        Task<ApiResponse<PagedDto<DishDto>>> GetDishByRestaurantIdAsync(int restaurantId, PagedRequest filter);
        Task<ApiResponse<DishDto?>> UpdateDishAsync(int id, Dish updatedDish, IFormFile? file);
        Task<ApiResponse<object>> DeleteDishAsync(int id);
    }
}
