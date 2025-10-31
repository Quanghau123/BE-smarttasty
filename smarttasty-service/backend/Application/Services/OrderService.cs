using backend.Application.Interfaces;
using backend.Domain.Enums;
using backend.Domain.Enums.Commons.Response;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Order;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace backend.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;

        public OrderService(ApplicationDbContext context, IMapper mapper, IImageHelper imageHelper)
        {
            _context = context;
            _mapper = mapper;
            _imageHelper = imageHelper;
        }

        // ---------------- Order CRUD ----\------------
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
        public async Task<ApiResponse<object>> AddItemOrderAsync(int orderId, int dishId, int quantity)
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
                 .ThenInclude(i => i.Dish)
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

            // disallow modification if paid or cancelled
            if (order.Status == OrderStatus.Paid || order.Status == OrderStatus.Cancelled)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Cannot modify a paid or cancelled order",
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

            // ensure dish belongs to the same restaurant as the order
            if (dish.RestaurantId != order.RestaurantId)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Dish does not belong to the order's restaurant",
                    Data = null
                };
            }

            var existingItem = order.OrderItems.FirstOrDefault(i => i.DishId == dishId);
            if (existingItem != null)
            {
                // increment existing quantity
                existingItem.Quantity += quantity;
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
                    .ThenInclude(i => i.Dish)
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

            // Cập nhật thông tin giao hàng
            if (!string.IsNullOrWhiteSpace(request.DeliveryAddress))
                order.DeliveryAddress = request.DeliveryAddress;
            if (!string.IsNullOrWhiteSpace(request.RecipientName))
                order.RecipientName = request.RecipientName;
            if (!string.IsNullOrWhiteSpace(request.RecipientPhone))
                order.RecipientPhone = request.RecipientPhone;

            // Xử lý cập nhật số lượng item (nếu client gửi)
            if (request.Items != null && request.Items.Any())
            {
                foreach (var itemReq in request.Items)
                {
                    var existing = order.OrderItems.FirstOrDefault(i => i.DishId == itemReq.DishId);
                    if (existing == null)
                    {
                        // Nếu muốn, có thể trả lỗi NotFound cho item không thuộc order.
                        // Hiện tại bỏ qua item không tồn tại.
                        continue;
                    }

                    if (itemReq.Quantity <= 0)
                    {
                        // Xóa item nếu quantity <= 0
                        order.RemoveItem(existing.Id);
                    }
                    else
                    {
                        // cập nhật quantity và tính lại total price nếu có
                        var oldQty = existing.Quantity;
                        var oldTotal = existing.TotalPrice; // giả sử tồn tại
                        decimal unitPrice = 0;
                        if (oldQty > 0)
                            unitPrice = oldTotal / oldQty;
                        else if (existing.Dish != null)
                            unitPrice = (decimal)existing.Dish.Price;
                        else
                            unitPrice = oldTotal; // fallback

                        existing.Quantity = itemReq.Quantity;
                        existing.TotalPrice = Math.Round(unitPrice * itemReq.Quantity, 2);
                    }
                }
            }

            order.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            // reload order with includes to ensure mapping có đầy đủ dữ liệu
            order = await _context.Orders
                .Include(o => o.OrderItems).ThenInclude(i => i.Dish)
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(o => o.Id == orderId);

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
            var order = await _context.Orders
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                };

            var payment = order.Payment;

            if (order.Status == OrderStatus.Cancelled)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Cannot update a cancelled order",
                    Data = null
                };

            order.DeliveryStatus = newStatus;
            order.UpdatedAt = DateTime.UtcNow;

            if (newStatus == DeliveryStatus.Delivered)
            {
                order.DeliveredAt = DateTime.UtcNow;

                // Nếu là thanh toán online (VNPAY, ZaloPay)
                if (payment != null &&
                    (payment.Method == PaymentMethod.VNPay || payment.Method == PaymentMethod.ZaloPay))
                {
                    // Đã thanh toán xong trước đó
                    if (payment.Status == PaymentStatus.Success)
                    {
                        order.Status = OrderStatus.Paid;
                    }
                    else
                    {
                        // Nếu chưa thanh toán thành công mà hàng đã giao, lỗi nghiệp vụ
                        return new ApiResponse<object>
                        {
                            ErrCode = ErrorCode.ValidationError,
                            ErrMessage = "Cannot mark as delivered before successful online payment",
                            Data = null
                        };
                    }
                }

                // Nếu là COD
                if (payment != null && payment.Method == PaymentMethod.COD)
                {
                    if (payment.Status == PaymentStatus.Success)
                    {
                        order.Status = OrderStatus.Paid;
                    }
                    else
                    {
                        // Trường hợp shipper chưa thu tiền mà đã giao hàng → báo lỗi
                        return new ApiResponse<object>
                        {
                            ErrCode = ErrorCode.ValidationError,
                            ErrMessage = "Cannot mark COD order as delivered before confirming payment",
                            Data = null
                        };
                    }
                }
            }

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

            // Cập nhật lại Image thành URL đầy đủ
            foreach (var order in orderDtos)
            {
                if (order.Items != null)
                {
                    foreach (var item in order.Items)
                    {
                        item.Image = _imageHelper.GetImageUrl(item.Image);
                    }
                }
            }

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
