using backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplyPromotionController : ControllerBase
    {
        private readonly IApplyPromotionService _applyPromotionService;

        public ApplyPromotionController(IApplyPromotionService applyPromotionService)
        {
            _applyPromotionService = applyPromotionService;
        }

        // Áp dụng voucher
        [HttpPost("{orderId}")]
        public async Task<IActionResult> ApplyPromotion(int orderId, [FromQuery] string voucherCode)
        {
            try
            {
                var finalPrice = await _applyPromotionService.ApplyPromotionAsync(orderId, voucherCode);

                return Ok(new
                {
                    OrderId = orderId,
                    FinalTotal = finalPrice,
                    VoucherCode = voucherCode
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Hủy promotion
        [HttpPost("{orderId}/remove")]
        public async Task<IActionResult> RemovePromotion(int orderId)
        {
            try
            {
                var finalPrice = await _applyPromotionService.RemovePromotionAsync(orderId);

                return Ok(new
                {
                    OrderId = orderId,
                    FinalTotal = finalPrice,
                    VoucherCode = (string?)null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
