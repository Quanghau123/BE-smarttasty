using Microsoft.AspNetCore.Mvc;
using backend.Infrastructure.Data;
using backend.Application.Interfaces;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Models;
using backend.Application.DTOs.Payment;
using backend.Domain.Models.Requests.Payment;
using backend.Domain.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CloudinaryDotNet.Actions; // Add for AnyAsync

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IVNPayService _vnPayService;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

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

        [Authorize(Roles = "user")]
        [HttpPost("vnpay/create")]
        public async Task<IActionResult> CreateVNPayPayment([FromBody] CreatePaymentRequest dto)
        {
            // Fix: Use _db.Orders.AnyAsync if OrderExistsAsync is not available
            if (!await _db.Orders.AnyAsync(o => o.Id == dto.OrderId))
            {
                return CreateResult(new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                });
            }

            var existingPayment = await _paymentService.GetPaymentByOrderIdAsync(dto.OrderId.ToString());
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

            var url = _vnPayService.CreatePaymentUrl(HttpContext, dto.Amount, dto.OrderId.ToString(), "Thanh toan don hang");
            var payment = new Payment
            {
                OrderId = dto.OrderId,
                Amount = dto.Amount,
                Method = PaymentMethod.VNPay,
                Status = PaymentStatus.Pending,
                PaymentUrl = url,
                CreatedAt = DateTime.UtcNow
            };

            await _paymentService.AddPaymentAsync(payment);

            var fullPayment = await _paymentService.GetPaymentByOrderIdAsync(dto.OrderId.ToString());
            var paymentDto = _mapper.Map<PaymentDto>(fullPayment);

            return CreateResult(new ApiResponse<PaymentDto>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Payment created successfully",
                Data = paymentDto
            });
        }

        [Authorize(Roles = "user, business")]
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

        [Authorize(Roles = "user, business")]
        [HttpGet("vnpay-ipn")]
        public async Task<IActionResult> VNPayIpn()
        {
            var result = await _paymentService.ProcessVNPayIpnAsync(HttpContext.Request.Query);
            return StatusCode(
                result.ErrCode == ErrorCode.Success ? 200 : 400,
                result.Data
            );
        }

        [Authorize(Roles = "user, business")]
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingPayments()
        {
            var payments = await _paymentService.GetPendingPayments();
            var dtos = payments.Select(p => _mapper.Map<PaymentDto>(p)).ToList();
            return CreateResult(new ApiResponse<List<PaymentDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Pending payments fetched",
                Data = dtos
            });
        }

        [Authorize(Roles = "user")]
        [HttpPost("cod/create")]
        public async Task<IActionResult> CreateCodPayment([FromBody] CreateCodPaymentRequest dto)
        {
            if (!await _db.Orders.AnyAsync(o => o.Id == dto.OrderId))
            {
                return CreateResult(new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Order not found",
                    Data = null
                });
            }

            var payment = new Payment
            {
                OrderId = dto.OrderId,
                Amount = dto.Amount,
                Method = PaymentMethod.COD,
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _paymentService.CreateCodPaymentAsync(payment);

            // Map Data sang DTO nếu là CODPayment
            CODPaymentDto? codPaymentDto = null;
            if (result.Data is CODPayment codPayment)
            {
                codPaymentDto = _mapper.Map<CODPaymentDto>(codPayment);
            }

            return CreateResult(new ApiResponse<CODPaymentDto>
            {
                ErrCode = result.ErrCode,
                ErrMessage = result.ErrMessage,
                Data = codPaymentDto
            });
        }

        [Authorize(Roles = "business")]
        [HttpPost("cod/confirm")]
        public async Task<IActionResult> ConfirmCodPayment([FromQuery] int codPaymentId)
        {
            var result = await _paymentService.ConfirmCodPaymentAsync(codPaymentId);

            CODPaymentDto? codPaymentDto = null;
            if (result.Data is CODPayment codPayment)
            {
                codPaymentDto = _mapper.Map<CODPaymentDto>(codPayment);
            }

            return CreateResult(new ApiResponse<CODPaymentDto>
            {
                ErrCode = result.ErrCode,
                ErrMessage = result.ErrMessage,
                Data = codPaymentDto
            });
        }

        [Authorize(Roles = "user, business")]
        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetPaymentHistoryByUser(int userId)
        {
            var result = await _paymentService.GetPaymentsByUserIdAsync(userId);

            // Nếu trả về entity, bạn nên map sang DTO trước khi trả về FE
            List<InfoPaymentDto> dtos = new();
            if (result.Data is List<Payment> payments)
            {
                dtos = payments.Select(p => _mapper.Map<InfoPaymentDto>(p)).ToList();
            }
            else if (result.Data is List<InfoPaymentDto> infoPaymentDtos)
            {
                dtos = infoPaymentDtos;
            }

            return CreateResult(new ApiResponse<List<InfoPaymentDto>>
            {
                ErrCode = result.ErrCode,
                ErrMessage = result.ErrMessage,
                Data = dtos
            });
        }

        [Authorize(Roles = "user, business")]
        [HttpDelete("cancel/{orderId}")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var result = await _paymentService.CancelOrderAsync(orderId);

            return result.ErrCode switch
            {
                ErrorCode.Success => CreateResult(result),
                ErrorCode.NotFound => CreateResult(result),
                ErrorCode.ValidationError => CreateResult(result),
                ErrorCode.ServerError => CreateResult(result),
                _ => CreateResult(result)
            };
        }

        [Authorize(Roles = "user, business")]
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetPaymentsByRestaurant(int restaurantId)
        {
            var result = await _paymentService.GetPaymentsByRestaurantIdAsync(restaurantId);

            List<InfoPaymentDto> dtos = new();
            if (result.Data is List<Payment> payments)
            {
                dtos = payments.Select(p => _mapper.Map<InfoPaymentDto>(p)).ToList();
            }
            else if (result.Data is List<InfoPaymentDto> infoPaymentDtos)
            {
                dtos = infoPaymentDtos;
            }

            return CreateResult(new ApiResponse<List<InfoPaymentDto>>
            {
                ErrCode = result.ErrCode,
                ErrMessage = result.ErrMessage,
                Data = dtos
            });
        }

        [Authorize(Roles = "user, business")]
        [HttpGet("restaurant/pending/{restaurantId}")]
        public async Task<IActionResult> GetPendingPaymentsByRestaurant(int restaurantId)
        {
            var result = await _paymentService.GetPendingPaymentsByRestaurantIdAsync(restaurantId);

            List<InfoPaymentDto> dtos = new();
            if (result.Data is List<Payment> payments)
            {
                dtos = payments.Select(p => _mapper.Map<InfoPaymentDto>(p)).ToList();
            }
            else if (result.Data is List<InfoPaymentDto> infoPaymentDtos)
            {
                dtos = infoPaymentDtos;
            }

            return CreateResult(new ApiResponse<List<InfoPaymentDto>>
            {
                ErrCode = result.ErrCode,
                ErrMessage = result.ErrMessage,
                Data = dtos
            });
        }
    }
}
