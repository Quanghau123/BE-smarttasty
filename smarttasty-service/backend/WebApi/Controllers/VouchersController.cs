using backend.Domain.Models.Requests.Voucher;
using backend.Application.Interfaces;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Mvc;

namespace backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly IVoucherService _service;

        public VouchersController(IVoucherService service)
        {
            _service = service;
        }

        private IActionResult CreateResult<T>(ApiResponse<T> res)
        {
            return StatusCode(MapErrorCodeToStatus(res.ErrCode), res);
        }

        private int MapErrorCodeToStatus(ErrorCode code) => code switch
        {
            ErrorCode.Success => 200,
            ErrorCode.NotFound => 404,
            ErrorCode.ValidationError => 400,
            _ => 500
        };

        [HttpPost]
        public async Task<IActionResult> CreateVoucher([FromBody] CreateVoucherRequest dto)
        {
            var res = await _service.CreateVoucherAsync(dto);
            return CreateResult(res);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserVouchers(int userId)
        {
            var res = await _service.GetUserVouchersAsync(userId);
            return CreateResult(res);
        }

        [HttpPut("{id}/use")]
        public async Task<IActionResult> MarkVoucherAsUsed(int id)
        {
            var res = await _service.MarkAsUsedAsync(id);
            return CreateResult(res);
        }
    }
}
