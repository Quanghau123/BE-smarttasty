using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplyPromotionController : ControllerBase
    {
        private readonly IApplyPromotionService _applyPromotionService;
        private readonly ApplicationDbContext _context;

        public ApplyPromotionController(
            IApplyPromotionService applyPromotionService,
            ApplicationDbContext context)
        {
            _applyPromotionService = applyPromotionService;
            _context = context;
        }

        [HttpPost("{orderId}")]
        public async Task<IActionResult> ApplyPromotion(
            int orderId,
            [FromQuery] string? voucherCode = null)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return NotFound(new { message = "Order not found" });

            var finalPrice = await _applyPromotionService.ApplyPromotionAsync(
                order,
                order.UserId,
                voucherCode
            );

            return Ok(new
            {
                OrderId = order.Id,
                OriginalTotal = order.OrderItems.Sum(i => i.TotalPrice),
                FinalTotal = finalPrice,
                VoucherCode = voucherCode
            });
        }
        [HttpPost("{orderId}/remove")]
        public async Task<IActionResult> RemovePromotion(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return NotFound(new { message = "Order not found" });

            var finalPrice = await _applyPromotionService.RemovePromotionAsync(order);

            return Ok(new
            {
                OrderId = order.Id,
                OriginalTotal = order.OrderItems.Sum(i => i.TotalPrice),
                FinalTotal = finalPrice,
                VoucherCode = (string?)null
            });
        }
    }
}
