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
        private readonly IVoucherService _voucherService;

        public ApplyPromotionService(ApplicationDbContext context, IVoucherService voucherService)
        {
            _context = context;
            _voucherService = voucherService;
        }

        public async Task<float> ApplyPromotionAsync(Order order, string? voucherCode = null)
        {
            float finalTotal = 0;

            // ----- DishPromotion -----
            foreach (var item in order.OrderItems)
            {
                var dish = await _context.Dishes
                    .Include(d => d.DishPromotions)
                    .ThenInclude(dp => dp.Promotion)
                    .FirstOrDefaultAsync(d => d.Id == item.DishId);

                if (dish == null) continue;

                float price = (float)(item.UnitPrice * item.Quantity);

                var validDishPromotions = dish.DishPromotions
                    .Where(dp => dp.Promotion.StartDate <= DateTime.UtcNow &&
                                 dp.Promotion.EndDate >= DateTime.UtcNow)
                    .ToList();

                foreach (var dp in validDishPromotions)
                {
                    if (dp.Promotion.DiscountType == DiscountType.percent)
                        price -= price * dp.Promotion.DiscountValue / 100f;
                    else
                        price -= dp.Promotion.DiscountValue;
                }

                finalTotal += price;
            }

            // ----- OrderPromotion -----
            var validOrderPromotions = await _context.OrderPromotions
                .Include(op => op.Promotion)
                .Where(op => op.Promotion!.StartDate <= DateTime.UtcNow &&
                             op.Promotion!.EndDate >= DateTime.UtcNow &&
                             finalTotal >= op.MinOrderValue)
                .ToListAsync();

            foreach (var op in validOrderPromotions)
            {
                if (op.Promotion!.DiscountType == DiscountType.percent)
                    finalTotal -= finalTotal * op.Promotion.DiscountValue / 100f;
                else
                    finalTotal -= op.Promotion.DiscountValue;
            }

            // ----- Voucher -----
            if (!string.IsNullOrEmpty(voucherCode))
            {
                var response = await _voucherService.GetByCodeAsync(voucherCode);
                var voucher = response.Data;
                if (voucher != null && !voucher.IsUsed &&
                    voucher.StartDate <= DateTime.UtcNow &&
                    voucher.EndDate >= DateTime.UtcNow)
                {
                    if (voucher.DiscountType == DiscountType.percent)
                        finalTotal -= finalTotal * voucher.DiscountValue / 100f;
                    else
                        finalTotal -= voucher.DiscountValue;

                    await _voucherService.MarkAsUsedAsync(voucher.Id);
                }
            }

            return finalTotal < 0 ? 0 : finalTotal;
        }
    }
}
