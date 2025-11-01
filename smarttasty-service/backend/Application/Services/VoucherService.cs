using AutoMapper;
using backend.Infrastructure.Data;
using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Application.DTOs.Voucher;
using backend.Domain.Models.Requests.Voucher;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VoucherService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<VoucherDto?>> GetByCodeAsync(string code)
        {
            var voucher = await _context.Vouchers
                .Include(v => v.Promotion)
                .FirstOrDefaultAsync(v => v.Code == code);

            if (voucher == null)
                return new ApiResponse<VoucherDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Voucher not found",
                    Data = null
                };

            return new ApiResponse<VoucherDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = _mapper.Map<VoucherDto>(voucher)
            };
        }

        public async Task<ApiResponse<VoucherDto?>> CreateVoucherAsync(CreateVoucherRequest dto)
        {
            var promo = await _context.Promotions.FindAsync(dto.PromotionId);
            if (promo == null)
            {
                return new ApiResponse<VoucherDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Promotion not found",
                    Data = null
                };
            }

            var voucher = new Voucher
            {
                Code = dto.Code,
                PromotionId = dto.PromotionId,
                UserId = dto.UserId,
                IsUsed = false,
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = dto.ExpiredAt
            };

            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();

            return new ApiResponse<VoucherDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Created successfully",
                Data = _mapper.Map<VoucherDto>(voucher)
            };
        }

        public async Task<ApiResponse<List<VoucherDto>>> GetUserVouchersAsync(int userId)
        {
            var list = await _context.Vouchers
                .Where(v => v.UserId == userId || v.UserId == null)
                .Include(v => v.Promotion)
                .ToListAsync();

            var data = _mapper.Map<List<VoucherDto>>(list);

            return new ApiResponse<List<VoucherDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = data
            };
        }

        public async Task<ApiResponse<object>> MarkAsUsedAsync(int id)
        {
            var voucher = await _context.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Voucher not found",
                    Data = null
                };
            }

            if (voucher.IsUsed)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.ValidationError,
                    ErrMessage = "Voucher already used",
                    Data = null
                };
            }

            voucher.IsUsed = true;
            await _context.SaveChangesAsync();

            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Voucher marked as used",
                Data = null
            };
        }
        public async Task RemoveExpiredVouchersAsync()
        {
            var now = DateTime.UtcNow;
            var expiredVouchers = await _context.Vouchers
                .Where(v => v.ExpiredAt < now)
                .ToListAsync();

            if (expiredVouchers.Any())
            {
                _context.Vouchers.RemoveRange(expiredVouchers);
                await _context.SaveChangesAsync();
            }
        }
    }
}
