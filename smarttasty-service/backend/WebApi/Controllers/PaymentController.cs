using Microsoft.AspNetCore.Mvc;
using backend.Infrastructure.Data;
using backend.Application.Interfaces;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Models;
using backend.Application.DTOs.Payment;
using backend.Domain.Enums;
using AutoMapper;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IVNPayService _vnPayService;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper; // thêm AutoMapper

        public PaymentController(
            IPaymentService paymentService,
            IVNPayService vnPayService,
            ApplicationDbContext db,
            IMapper mapper)
        {
            _paymentService = paymentService;
            _vnPayService = vnPayService;
            _db = db;
            _mapper = mapper;
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

        [HttpGet("create")]
        public async Task<IActionResult> CreatePayment([FromQuery] decimal amount, [FromQuery] int orderId)
        {
            var existingPayment = await _paymentService.GetPaymentByOrderIdAsync(orderId.ToString());
            if (existingPayment != null)
            {
                var existingDto = _mapper.Map<PaymentDto>(existingPayment);
                return CreateResult(new ApiResponse<PaymentDto>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Payment for this order already exists",
                    Data = existingDto
                });
            }

            var url = _vnPayService.CreatePaymentUrl(HttpContext, amount, orderId.ToString(), "Thanh toan don hang");

            var payment = new Payment
            {
                OrderId = orderId,
                Amount = amount,
                Method = PaymentMethod.VNPay,
                Status = PaymentStatus.Pending,
                PaymentUrl = url,
                CreatedAt = DateTime.UtcNow
            };

            await _paymentService.AddPaymentAsync(payment);

            var fullPayment = await _paymentService.GetPaymentByOrderIdAsync(orderId.ToString());
            var paymentDto = _mapper.Map<PaymentDto>(fullPayment);

            return CreateResult(new ApiResponse<PaymentDto>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Payment created successfully",
                Data = paymentDto
            });
        }

        [HttpGet("vnpay-return")]
        public async Task<IActionResult> VNPayReturn()
        {
            var result = await _paymentService.HandleVNPayReturn(HttpContext.Request.Query);

            if (result.Data is Payment payment)
            {
                var dto = _mapper.Map<PaymentDto>(payment);
                return CreateResult(new ApiResponse<PaymentDto>
                {
                    ErrCode = result.ErrCode,
                    ErrMessage = result.ErrMessage,
                    Data = dto
                });
            }

            // Nếu không phải Payment thì trả về ApiResponse<object>
            return CreateResult(new ApiResponse<object>
            {
                ErrCode = result.ErrCode,
                ErrMessage = result.ErrMessage,
                Data = result.Data
            });
        }

        [HttpGet("vnpay-ipn")]
        public async Task<IActionResult> VNPayIpn()
        {
            var res = await _paymentService.HandleVNPayIpn(HttpContext.Request.Query);
            return Ok(res); // theo spec VNPay: trả JSON {RspCode, Message}
        }

    }
}
