using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using backend.Application.Interfaces;
using backend.Domain.Models.Requests.Refund;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefundController : ControllerBase
    {
        private readonly IRefundService _refundService;

        public RefundController(IRefundService refundService)
        {
            _refundService = refundService;
        }

        private IActionResult CreateResult<T>(ApiResponse<T> res)
        {
            return StatusCode(MapErrorCodeToStatus(res.ErrCode), res);
        }

        private int MapErrorCodeToStatus(ErrorCode code) => code switch
        {
            ErrorCode.Success => 200,
            ErrorCode.ValidationError => 400,
            ErrorCode.NotFound => 404,
            ErrorCode.Unauthorized => 401,
            ErrorCode.Forbidden => 403,
            ErrorCode.ServerError => 500,
            _ => 500
        };

        // POST: api/refund
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRefundRequest request)
        {
            var res = await _refundService.CreateRefundAsync(request);
            return CreateResult(res);
        }

        // GET: api/refund/payment/{paymentId}
        [HttpGet("payment/{paymentId}")]
        public async Task<IActionResult> GetRefundsByPayment(int paymentId)
        {
            var res = await _refundService.GetRefundsByPaymentAsync(paymentId);
            return CreateResult(res);
        }
    }
}
