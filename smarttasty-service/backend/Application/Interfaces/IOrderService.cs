using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums;
using backend.Domain.Models.Requests.Order;

namespace backend.Application.Interfaces
{
    public interface IOrderService
    {
        // CRUD
        Task<ApiResponse<object>> CreateOrderAsync(CreateOrderRequest request);
        Task<ApiResponse<object>> AddItemOrderAsync(int orderId, int dishId, int quantity);
        Task<ApiResponse<object>> GetByIdAsync(int id);
        Task<ApiResponse<object>> UpdateOrderAsync(int orderId, UpdateOrderRequest request);
        Task<ApiResponse<object>> DeleteOrderAsync(int id);

        // Order Items
        Task<ApiResponse<object>> RemoveItemAsync(int orderId, int orderItemId);

        // Update Status
        Task<ApiResponse<object>> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
        Task<ApiResponse<object>> UpdateDeliveryStatusAsync(int orderId, DeliveryStatus newStatus);

        // Queries
        Task<ApiResponse<object>> GetOrdersByUserAsync(int userId);
        Task<ApiResponse<object>> GetOrdersByStatusAsync(OrderStatus status);
    }
}
