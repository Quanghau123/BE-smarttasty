using backend.Domain.Models;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Application.DTOs.Dish;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace backend.Application.Interfaces
{
    public interface IDishService
    {
        Task<ApiResponse<DishDto?>> CreateDishAsync(Dish dish, IFormFile? file);
        Task<ApiResponse<List<DishDto>>> GetDishByRestaurantIdAsync(int restaurantId);
        Task<ApiResponse<DishDto?>> UpdateDishAsync(int id, Dish updatedDish, IFormFile? file);
        Task<ApiResponse<object>> DeleteDishAsync(int id);
    }
}
