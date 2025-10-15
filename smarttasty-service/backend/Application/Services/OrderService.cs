using backend.Application.Interfaces;
using backend.Domain.Enums;
using backend.Domain.Enums.Commons.Response;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Order;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace backend.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper) // Sửa constructor
        {
            _context = context;
            _mapper = mapper;
        }

        // ---------------- Order CRUD ----------------
        public async Task<ApiResponse<object>> CreateOrderAsync(CreateOrderRequest request)
        {
            if (request.Items == null || !request.Items.Any())
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Order must contain at least one item",
                    Data = null
                };
            }

            var order = new Order
            {
                UserId = request.UserId,
                RestaurantId = request.RestaurantId,
                DeliveryAddress = request.DeliveryAddress,
                RecipientName = request.RecipientName,
                RecipientPhone = request.RecipientPhone,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            foreach (var itemReq in request.Items)
            {
                var dish = await _context.Dishes.FindAsync(itemReq.DishId);
                if (dish == null)
                {
                    return new ApiResponse<object>
                    {
                        ErrCode = ErrorCode.NotFound,
                        ErrMessage = $"Dish {itemReq.DishId} not found",
                        Data = null
                    };
                }

                var item = OrderItem.Create(dish.Id, (decimal)dish.Price, itemReq.Quantity);
                order.AddItem(item);
            }

            if (!order.OrderItems.Any())
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Order must contain valid items",
                    Data = null
                };
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Order created successfully",
                Data = new { order.Id }
            };
        }

        public async Task<ApiResponse<object>> GetByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems).ThenInclude(i => i.Dish)
                .Include(o => o.Restaurant)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                };
            }

            var orderDto = _mapper.Map<backend.Application.DTOs.Order.OrderDto>(order);

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = orderDto
            };
        }

        public async Task<ApiResponse<object>> UpdateOrderAsync(int orderId, UpdateOrderRequest request)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                };
            }

            if (order.Status == OrderStatus.Paid || order.Status == OrderStatus.Cancelled)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Cannot update a paid or cancelled order",
                    Data = null
                };
            }

            // Cập nhật thông tin giao hàng (không xử lý items ở đây)
            if (!string.IsNullOrWhiteSpace(request.DeliveryAddress))
                order.DeliveryAddress = request.DeliveryAddress;
            if (!string.IsNullOrWhiteSpace(request.RecipientName))
                order.RecipientName = request.RecipientName;
            if (!string.IsNullOrWhiteSpace(request.RecipientPhone))
                order.RecipientPhone = request.RecipientPhone;

            order.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var orderDto = _mapper.Map<backend.Application.DTOs.Order.OrderDto>(order);

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Order updated successfully",
                Data = orderDto
            };
        }

        public async Task<ApiResponse<object>> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                };
            }

            if (order.Status == OrderStatus.Paid || order.Status == OrderStatus.Paid)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Cannot delete a paid or completed order",
                    Data = null
                };
            }

            order.UpdatedAt = DateTime.UtcNow;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Deleted successfully",
                Data = null
            };
        }

        // ---------------- Order Items ----------------
        public async Task<ApiResponse<object>> AddItemAsync(int orderId, int dishId, int quantity)
        {
            if (quantity <= 0)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Quantity must be greater than zero",
                    Data = null
                };
            }

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                };
            }

            var dish = await _context.Dishes.FindAsync(dishId);
            if (dish == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Dish not found",
                    Data = null
                };
            }

            var existingItem = order.OrderItems.FirstOrDefault(i => i.DishId == dishId);
            if (existingItem != null)
            {
                // Thay đổi: gán quantity mới (thay vì cộng thêm)
                existingItem.Quantity = quantity;
                order.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var item = OrderItem.Create(dish.Id, (decimal)dish.Price, quantity);
                order.AddItem(item);
            }

            order.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var orderDto = _mapper.Map<backend.Application.DTOs.Order.OrderDto>(order);

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Item added/updated successfully",
                Data = orderDto
            };
        }

        public async Task<ApiResponse<object>> RemoveItemAsync(int orderId, int orderItemId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                };
            }

            var item = order.OrderItems.FirstOrDefault(i => i.Id == orderItemId);
            if (item == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Item not found in order",
                    Data = null
                };
            }

            order.RemoveItem(orderItemId);
            order.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var orderDto = _mapper.Map<backend.Application.DTOs.Order.OrderDto>(order);

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Item removed successfully",
                Data = orderDto
            };
        }

        // ---------------- Update Status ----------------
        public async Task<ApiResponse<object>> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                };
            }

            // Example business rule: cannot change from Completed/Cancelled
            if (order.Status == OrderStatus.Paid || order.Status == OrderStatus.Cancelled)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Cannot update a completed or canceled order",
                    Data = null
                };
            }

            order.Status = newStatus;
            order.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            var orderDto = _mapper.Map<backend.Application.DTOs.Order.OrderDto>(order);

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Order status updated successfully",
                Data = orderDto
            };
        }

        public async Task<ApiResponse<object>> UpdateDeliveryStatusAsync(int orderId, DeliveryStatus newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                };

            if (order.Status != OrderStatus.Paid && order.Status != OrderStatus.Paid)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Cannot update delivery status before payment",
                    Data = null
                };
            }

            order.DeliveryStatus = newStatus;
            if (newStatus == DeliveryStatus.Delivered)
                order.DeliveredAt = DateTime.UtcNow;

            order.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var orderDto = _mapper.Map<backend.Application.DTOs.Order.OrderDto>(order);

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = orderDto
            };
        }

        // ---------------- Queries ----------------
        public async Task<ApiResponse<object>> GetOrdersByUserAsync(int userId)
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems).ThenInclude(i => i.Dish)
                .Include(o => o.Restaurant)
                .Where(o => o.UserId == userId)
                .ToListAsync();

            var orderDtos = _mapper.Map<List<backend.Application.DTOs.Order.OrderDto>>(orders);

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = orderDtos
            };
        }

        public async Task<ApiResponse<object>> GetOrdersByStatusAsync(OrderStatus status)
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Restaurant)
                .Where(o => o.Status == status)
                .ToListAsync();

            var orderDtos = _mapper.Map<List<backend.Application.DTOs.Order.OrderDto>>(orders);

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = orderDtos
            };
        }
    }
}
