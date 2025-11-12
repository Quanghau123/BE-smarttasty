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
        private readonly IApplyPromotionService _applyPromotionService;

        public OrderService(
           ApplicationDbContext context,
           IMapper mapper,
           IImageHelper imageHelper,
           IApplyPromotionService applyPromotionService)
        {
            _context = context;
            _mapper = mapper;
            _imageHelper = imageHelper;
            _applyPromotionService = applyPromotionService;
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

                // Kiểm tra có khuyến mãi đang áp dụng
                var now = DateTime.UtcNow;

                var activePromo = await _context.DishPromotions
                    .Include(dp => dp.Promotion)
                    .Where(dp => dp.DishId == dish.Id
                                 && dp.Promotion.StartDate <= now
                                 && dp.Promotion.EndDate >= now)
                    .OrderByDescending(dp => dp.Id)
                    .FirstOrDefaultAsync();

                decimal priceToUse = activePromo?.AppliedPrice != null
                    ? (decimal)activePromo.AppliedPrice
                    : (decimal)dish.Price;

                var item = OrderItem.Create(dish.Id, priceToUse, itemReq.Quantity, (decimal)dish.Price);
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
                Data = new { order.Id, order.FinalPrice }
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

            if (dish.RestaurantId != order.RestaurantId)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Dish does not belong to the order's restaurant",
                    Data = null
                };
            }

            // Kiểm tra khuyến mãi
            var now = DateTime.UtcNow;

            var activePromo = await _context.DishPromotions
                .Include(dp => dp.Promotion)
                .Where(dp => dp.DishId == dish.Id
                             && dp.Promotion.StartDate <= now
                             && dp.Promotion.EndDate >= now)
                .OrderByDescending(dp => dp.Id)
                .FirstOrDefaultAsync();

            decimal priceToUse = activePromo?.AppliedPrice != null
                ? (decimal)activePromo.AppliedPrice
                : (decimal)dish.Price;

            var existingItem = order.OrderItems.FirstOrDefault(i => i.DishId == dishId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                order.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var item = OrderItem.Create(dish.Id, priceToUse, quantity, (decimal)dish.Price);
                order.AddItem(item);
            }

            order.UpdatedAt = DateTime.UtcNow;

            if (order.AppliedPromotionId.HasValue || !string.IsNullOrEmpty(order.AppliedVoucherCode))
                await _applyPromotionService.ApplyPromotionAsync(order.Id, order.AppliedVoucherCode!);
            else
                order.FinalPrice = order.TotalPrice;

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

            if (order.AppliedPromotionId.HasValue || !string.IsNullOrEmpty(order.AppliedVoucherCode))
                await _applyPromotionService.ApplyPromotionAsync(order.Id, order.AppliedVoucherCode!);
            else
                order.FinalPrice = order.TotalPrice;

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

            if (order.Status == OrderStatus.Paid || order.Status == OrderStatus.Cancelled)
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

            if (order.AppliedPromotionId.HasValue || !string.IsNullOrEmpty(order.AppliedVoucherCode))
                await _applyPromotionService.ApplyPromotionAsync(order.Id, order.AppliedVoucherCode!);
            else
                order.FinalPrice = order.TotalPrice;


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

        public async Task<ApiResponse<object>> GetRevenueDashboardAsync(int restaurantId, int year, int month)
        {
            // validate month/year to avoid DateTime overflow (AddMonths/AddYears)
            if (year < 1 || year > 9999 || month < 1 || month > 12)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Invalid year or month",
                    Data = null
                };
            }

            // ensure UTC kinds so Npgsql maps to timestamptz correctly
            var monthStart = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);
            var monthEnd = monthStart.AddMonths(1);

            // compute prev month/year safely
            bool prevMonthAvailable = true;
            DateTime prevMonthStart = DateTime.MinValue;
            DateTime prevMonthEnd = monthStart;
            try
            {
                prevMonthStart = monthStart.AddMonths(-1);
            }
            catch
            {
                prevMonthAvailable = false;
            }

            bool prevYearAvailable = true;
            DateTime yearStart = new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime yearEnd = yearStart.AddYears(1);
            DateTime prevYearStart = DateTime.MinValue;
            DateTime prevYearEnd = yearStart;
            try
            {
                prevYearStart = yearStart.AddYears(-1);
            }
            catch
            {
                prevYearAvailable = false;
            }

            // filter các order đã thanh toán (Paid)
            var paidQuery = _context.Orders.AsQueryable()
                .Where(o => o.RestaurantId == restaurantId && o.Status == OrderStatus.Paid);

            var allQuery = _context.Orders.AsQueryable()
                .Where(o => o.RestaurantId == restaurantId);

            // tháng hiện tại / tháng trước
            var monthRevenue = await paidQuery
                .Where(o => o.CreatedAt >= monthStart && o.CreatedAt < monthEnd)
                .SumAsync(o => (decimal?)o.FinalPrice) ?? 0m;
            var monthPaidCount = await paidQuery
                .Where(o => o.CreatedAt >= monthStart && o.CreatedAt < monthEnd)
                .CountAsync();
            var monthTotalCount = await allQuery
                .Where(o => o.CreatedAt >= monthStart && o.CreatedAt < monthEnd)
                .CountAsync();

            decimal prevMonthRevenue = 0m;
            int prevMonthPaidCount = 0;
            int prevMonthTotalCount = 0;
            if (prevMonthAvailable)
            {
                prevMonthRevenue = await paidQuery
                    .Where(o => o.CreatedAt >= prevMonthStart && o.CreatedAt < prevMonthEnd)
                    .SumAsync(o => (decimal?)o.FinalPrice) ?? 0m;
                prevMonthPaidCount = await paidQuery
                    .Where(o => o.CreatedAt >= prevMonthStart && o.CreatedAt < prevMonthEnd)
                    .CountAsync();
                prevMonthTotalCount = await allQuery
                    .Where(o => o.CreatedAt >= prevMonthStart && o.CreatedAt < prevMonthEnd)
                    .CountAsync();
            }

            // năm hiện tại / năm trước
            var yearRevenue = await paidQuery
                .Where(o => o.CreatedAt >= yearStart && o.CreatedAt < yearEnd)
                .SumAsync(o => (decimal?)o.FinalPrice) ?? 0m;
            var yearPaidCount = await paidQuery
                .Where(o => o.CreatedAt >= yearStart && o.CreatedAt < yearEnd)
                .CountAsync();
            var yearTotalCount = await allQuery
                .Where(o => o.CreatedAt >= yearStart && o.CreatedAt < yearEnd)
                .CountAsync();

            decimal prevYearRevenue = 0m;
            int prevYearPaidCount = 0;
            int prevYearTotalCount = 0;
            if (prevYearAvailable)
            {
                prevYearRevenue = await paidQuery
                    .Where(o => o.CreatedAt >= prevYearStart && o.CreatedAt < prevYearEnd)
                    .SumAsync(o => (decimal?)o.FinalPrice) ?? 0m;
                prevYearPaidCount = await paidQuery
                    .Where(o => o.CreatedAt >= prevYearStart && o.CreatedAt < prevYearEnd)
                    .CountAsync();
                prevYearTotalCount = await allQuery
                    .Where(o => o.CreatedAt >= prevYearStart && o.CreatedAt < prevYearEnd)
                    .CountAsync();
            }

            static decimal CalcPercentChange(decimal current, decimal previous)
            {
                if (previous == 0m)
                    return current == 0m ? 0m : 100m;
                return Math.Round((current - previous) / previous * 100m, 2);
            }

            var monthChangePercent = CalcPercentChange(monthRevenue, prevMonthRevenue);
            var yearChangePercent = CalcPercentChange(yearRevenue, prevYearRevenue);

            var data = new
            {
                Month = new
                {
                    Year = year,
                    Month = month,
                    Revenue = monthRevenue,
                    PaidOrders = monthPaidCount,
                    TotalOrders = monthTotalCount,
                    PrevRevenue = prevMonthRevenue,
                    PrevPaidOrders = prevMonthPaidCount,
                    PrevTotalOrders = prevMonthTotalCount,
                    RevenueChangePercent = monthChangePercent
                },
                Year = new
                {
                    Year = year,
                    Revenue = yearRevenue,
                    PaidOrders = yearPaidCount,
                    TotalOrders = yearTotalCount,
                    PrevRevenue = prevYearRevenue,
                    PrevPaidOrders = prevYearPaidCount,
                    PrevTotalOrders = prevYearTotalCount,
                    RevenueChangePercent = yearChangePercent
                }
            };

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = data
            };
        }
    }
}
