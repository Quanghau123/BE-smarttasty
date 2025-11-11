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

        // Áp dụng promotion
        public async Task<float> ApplyPromotionAsync(Order order, int currentUserId, string? voucherCode = null)
        {
            float finalTotal = order.OrderItems.Sum(i => (float)i.TotalPrice);

            Console.WriteLine($"[ApplyPromotion] Order total: {finalTotal}");
            Console.WriteLine($"[ApplyPromotion] UserId: {currentUserId}");
            Console.WriteLine($"[ApplyPromotion] Voucher: {(voucherCode ?? "(none)")}");
            Console.WriteLine($"[ApplyPromotion] RestaurantId: {order.RestaurantId}");

            // dùng DateTime.Now thay vì UtcNow để tránh lệch múi giờ VN
            var nowUtc = DateTime.UtcNow;

            var validPromotions = await _context.OrderPromotions
                .Include(op => op.Promotion)
                .Where(op =>
                    // op.Promotion!.StartDate <= nowUtc &&
                    // op.Promotion!.EndDate >= nowUtc &&
                    finalTotal >= op.MinOrderValue &&
                // (op.IsGlobal || op.TargetUserId == currentUserId) &&
                (op.RestaurantId == null || op.RestaurantId == order.RestaurantId)
                // (voucherCode == null || op.Promotion!.VoucherCode == voucherCode)
                )
                .ToListAsync();

            Console.WriteLine($"[ApplyPromotion] Found {validPromotions.Count} valid promotions");

            if (!validPromotions.Any())
            {
                order.AppliedPromotionId = null;
                order.AppliedVoucherCode = null;
                order.FinalPrice = (decimal)finalTotal;
                await _context.SaveChangesAsync();
                Console.WriteLine("[ApplyPromotion] No valid promotions found — skipping discount");
                return finalTotal;
            }

            var promo = validPromotions.First().Promotion!;
            Console.WriteLine($"[ApplyPromotion] Applying promo ID={promo.Id}, Type={promo.DiscountType}, Value={promo.DiscountValue}");

            if (promo.DiscountType == DiscountType.percent)
                finalTotal -= finalTotal * promo.DiscountValue / 100f;
            else
                finalTotal -= promo.DiscountValue;

            finalTotal = Math.Max(finalTotal, 0);

            order.AppliedPromotionId = promo.Id;
            order.AppliedVoucherCode = voucherCode;
            order.FinalPrice = (decimal)Math.Round(finalTotal, 2);

            await _context.SaveChangesAsync();

            Console.WriteLine($"[ApplyPromotion] Final price after discount: {order.FinalPrice}");
            return finalTotal;
        }

        // Hủy promotion
        public async Task<float> RemovePromotionAsync(Order order)
        {
            order.AppliedPromotionId = null;
            order.AppliedVoucherCode = null;
            order.FinalPrice = order.OrderItems.Sum(i => i.TotalPrice);
            await _context.SaveChangesAsync();
            Console.WriteLine("[ApplyPromotion] Promotion removed, reset to original total");
            return (float)order.FinalPrice;
        }
    }
}
