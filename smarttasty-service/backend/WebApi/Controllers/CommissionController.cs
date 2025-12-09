using backend.Application.DTOs.Commission;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionController : ControllerBase
    {
        private readonly ICommissionService _commissionService;

        public CommissionController(ICommissionService commissionService)
        {
            _commissionService = commissionService;
        }

        [HttpGet("monthly")]
        public async Task<IActionResult> GetMonthlyCommission([FromQuery] int month, [FromQuery] int year)
        {
            var result = await _commissionService.GetMonthlyCommissionAsync(month, year);
            return Ok(new
            {
                Month = month,
                Year = year,
                TotalCommission = result
            });
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] int month, [FromQuery] int year)
        {
            var result = await _commissionService.GetCommissionListAsync(month, year);
            return Ok(result);
        }

        [HttpGet("restaurant")]
        public async Task<IActionResult> GetCommissionByRestaurant([FromQuery] int month, [FromQuery] int year)
        {
            var result = await _commissionService.GetCommissionByRestaurantAsync(month, year);
            return Ok(result);
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyCommission([FromQuery] int month, [FromQuery] int year)
        {
            var result = await _commissionService.GetDailyCommissionAsync(month, year);
            return Ok(result);
        }

        [HttpGet("payment-method")]
        public async Task<IActionResult> GetCommissionByPaymentMethod([FromQuery] int month, [FromQuery] int year)
        {
            var result = await _commissionService.GetCommissionByPaymentMethodAsync(month, year);
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetCommissionDetail(int orderId)
        {
            var result = await _commissionService.GetCommissionDetailAsync(orderId);
            if (result == null)
                return NotFound(new { Message = "Commission not found" });

            return Ok(result);
        }
    }
}
