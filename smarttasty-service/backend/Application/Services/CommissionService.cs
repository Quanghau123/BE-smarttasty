using backend.Application.DTOs.Commission;
using backend.Application.Interfaces;
using backend.Domain.Enums;
using backend.Domain.Models;
using backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Services
{
    public class CommissionService : ICommissionService
    {
        private readonly ApplicationDbContext _context;

        public CommissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsCommissionRecorded(int orderId)
        {
            return await _context.OrderCommission
                .AnyAsync(x => x.OrderId == orderId);
        }

        public async Task RecordCommissionAsync(Order order)
        {
            bool exists = await _context.OrderCommission
                .AnyAsync(x => x.OrderId == order.Id);

            if (exists) return;

            var payment = await _context.Payments
                .FirstOrDefaultAsync(x => x.OrderId == order.Id);

            if (payment == null)
                throw new Exception("Không tìm thấy thông tin thanh toán cho Order.");

            PaymentMethod paymentMethod = payment.Method;

            decimal rate = paymentMethod switch
            {
                PaymentMethod.VNPay => 0.10m,
                PaymentMethod.COD => 0.05m,
                _ => 0.10m
            };

            var commission = new OrderCommission
            {
                OrderId = order.Id,
                RestaurantId = order.RestaurantId,
                UserId = order.UserId,
                PaymentMethod = paymentMethod,
                FinalPrice = order.FinalPrice,
                CommissionRate = rate,
                CommissionAmount = Math.Round(order.FinalPrice * rate, 2),
                CreatedAt = DateTime.UtcNow
            };

            _context.OrderCommission.Add(commission);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetMonthlyCommissionAsync(int month, int year)
        {
            return await _context.OrderCommission
                .Where(x => x.CreatedAt.Month == month && x.CreatedAt.Year == year)
                .SumAsync(x => x.CommissionAmount);
        }

        public async Task<IEnumerable<CommissionResponse>> GetCommissionListAsync(int month, int year)
        {
            return await _context.OrderCommission
                .Where(x => x.CreatedAt.Month == month && x.CreatedAt.Year == year)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new CommissionResponse
                {
                    OrderId = x.OrderId,
                    RestaurantId = x.RestaurantId,
                    CommissionAmount = x.CommissionAmount,
                    Rate = x.CommissionRate,
                    FinalPrice = x.FinalPrice,
                    CreatedAt = x.CreatedAt
                }).ToListAsync();
        }

        public async Task<IEnumerable<RestaurantCommissionResponse>> GetCommissionByRestaurantAsync(int month, int year)
        {
            return await _context.OrderCommission
                .Include(x => x.Restaurant)
                .Where(x => x.CreatedAt.Month == month && x.CreatedAt.Year == year)
                .GroupBy(x => new { x.RestaurantId, RestaurantName = x.Restaurant.Name })
                .Select(g => new RestaurantCommissionResponse
                {
                    RestaurantId = g.Key.RestaurantId,
                    RestaurantName = g.Key.RestaurantName,
                    TotalCommission = g.Sum(x => x.CommissionAmount),
                    TotalOrders = g.Count(),
                    TotalRevenue = g.Sum(x => x.FinalPrice)
                })
                .OrderByDescending(r => r.TotalCommission)
                .ToListAsync();
        }

        public async Task<IEnumerable<DailyCommissionResponse>> GetDailyCommissionAsync(int month, int year)
        {
            return await _context.OrderCommission
                .Where(x => x.CreatedAt.Month == month && x.CreatedAt.Year == year)
                .GroupBy(x => x.CreatedAt.Day)
                .Select(g => new DailyCommissionResponse
                {
                    Day = g.Key,
                    TotalCommission = g.Sum(x => x.CommissionAmount)
                })
                .OrderBy(x => x.Day)
                .ToListAsync();
        }

        public async Task<IEnumerable<PaymentCommissionResponse>> GetCommissionByPaymentMethodAsync(int month, int year)
        {
            return await _context.OrderCommission
                .Where(x => x.CreatedAt.Month == month && x.CreatedAt.Year == year)
                .GroupBy(x => x.PaymentMethod)
                .Select(g => new PaymentCommissionResponse
                {
                    PaymentMethod = g.Key,
                    TotalCommission = g.Sum(x => x.CommissionAmount),
                    TotalOrders = g.Count()
                })
                .ToListAsync();
        }

        public async Task<CommissionResponse?> GetCommissionDetailAsync(int orderId)
        {
            return await _context.OrderCommission
                .Where(x => x.OrderId == orderId)
                .Select(x => new CommissionResponse
                {
                    OrderId = x.OrderId,
                    CommissionAmount = x.CommissionAmount,
                    Rate = x.CommissionRate,
                    FinalPrice = x.FinalPrice,
                    CreatedAt = x.CreatedAt
                })
                .FirstOrDefaultAsync();
        }
    }
}
