using backend.Application.Interfaces;
using backend.Domain.Enums;
using backend.Domain.Models;
using backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Services
{
    public class ApplyPromotionService : IApplyPromotionService
    {
        private readonly ApplicationDbContext _context;

        public ApplyPromotionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<float> ApplyPromotionAsync(int orderId, string voucherCode)
        {
            if (string.IsNullOrWhiteSpace(voucherCode))
                throw new ArgumentException("Voucher code is required", nameof(voucherCode));

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                throw new Exception("Order not found");

            float orderTotal = order.OrderItems.Sum(i => (float)i.TotalPrice);
            string vc = voucherCode.Trim();

            var orderPromotion = await _context.OrderPromotions
                .Include(op => op.Promotion)
                .Where(op =>
                    !string.IsNullOrEmpty(op.Promotion.VoucherCode) &&
                    op.Promotion.VoucherCode.Trim() == vc &&
                    (op.RestaurantId == null || op.RestaurantId == order.RestaurantId) &&
                    (op.IsGlobal || op.TargetUserId == order.UserId) &&
                    orderTotal >= op.MinOrderValue
                )
                .FirstOrDefaultAsync();

            if (orderPromotion == null)
            {
                order.AppliedPromotionId = null;
                order.AppliedVoucherCode = null;
                order.FinalPrice = (decimal)orderTotal;
                await _context.SaveChangesAsync();
                return orderTotal;
            }

            var promo = orderPromotion.Promotion!;
            float finalTotal = orderTotal;

            if (promo.DiscountType == DiscountType.percent)
                finalTotal -= finalTotal * promo.DiscountValue / 100f;
            else
                finalTotal -= promo.DiscountValue;

            finalTotal = Math.Max(finalTotal, 0);

            order.AppliedPromotionId = promo.Id;
            order.AppliedVoucherCode = voucherCode;
            order.FinalPrice = (decimal)Math.Round(finalTotal, 2);

            await _context.SaveChangesAsync();
            return finalTotal;
        }

        public async Task<float> RemovePromotionAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                throw new Exception("Order not found");

            order.AppliedPromotionId = null;
            order.AppliedVoucherCode = null;
            order.FinalPrice = order.OrderItems.Sum(i => i.TotalPrice);

            await _context.SaveChangesAsync();
            return (float)order.FinalPrice;
        }
    }
}
