using AutoMapper;
using backend.Infrastructure.Data;
using backend.Application.Interfaces;
using backend.Application.Interfaces.Commons;
using backend.Domain.Models;
using backend.Application.DTOs.Promotion;
using backend.Domain.Models.Requests.Promotion;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;

namespace backend.Application.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContext;
        private readonly IPhotoService _photoService;
        private readonly IImageHelper _imageHelper;

        public PromotionService(ApplicationDbContext context, IMapper mapper, IUserContextService userContext, IPhotoService photoService, IImageHelper imageHelper)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
            _photoService = photoService;
            _imageHelper = imageHelper;
        }

        public async Task<ApiResponse<PromotionDto?>> CreatePromotionAsync(CreatePromotionRequest dto, IFormFile? file)
        {
            if (_userContext.Role != "business")
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User is not authorized to create promotions",
                    Data = null
                };

            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == dto.RestaurantId);
            if (restaurant == null)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Restaurant not found",
                    Data = null
                };

            if (restaurant.OwnerId != _userContext.UserId)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User does not own the restaurant",
                    Data = null
                };

            var promotion = new Promotion
            {
                VoucherCode = dto.VoucherCode,
                RestaurantId = dto.RestaurantId,
                Title = dto.Title,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                DiscountType = dto.DiscountType,
                DiscountValue = dto.DiscountValue,
                TargetType = dto.TargetType
            };

            if (file != null)
            {
                var uploadedPublicId = await _photoService.UploadPhotoAsync(file, "promotions");
                if (uploadedPublicId == null)
                {
                    return new ApiResponse<PromotionDto?>
                    {
                        ErrCode = ErrorCode.ServerError,
                        ErrMessage = "Failed to upload image",
                        Data = null
                    };
                }
                promotion.Image = uploadedPublicId;
            }

            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();

            await _context.Entry(promotion).Reference(p => p.Restaurant).LoadAsync();

            var dtoOut = _mapper.Map<PromotionDto>(promotion);
            if (dtoOut != null && !string.IsNullOrEmpty(dtoOut.Image))
                dtoOut.ImageUrl = _imageHelper.GetImageUrl(dtoOut.Image);

            return new ApiResponse<PromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Created successfully",
                Data = dtoOut
            };
        }

        public async Task<ApiResponse<List<PromotionDto>>> GetPromotionsByRestaurantIdAsync(int restaurantId)
        {
            var promos = await _context.Promotions
                .Where(p => p.RestaurantId == restaurantId)
                .Include(p => p.Restaurant)
                .ToListAsync();

            var data = _mapper.Map<List<PromotionDto>>(promos);

            if (data != null)
            {
                foreach (var d in data)
                {
                    if (!string.IsNullOrEmpty(d.Image))
                        d.ImageUrl = _imageHelper.GetImageUrl(d.Image);
                }
            }

            return new ApiResponse<List<PromotionDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = data
            };
        }

        public async Task<ApiResponse<PromotionDto?>> GetPromotionByIdAsync(int id)
        {
            var promo = await _context.Promotions
                .Include(p => p.Restaurant)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (promo == null)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Promotion not found",
                    Data = null
                };

            var dtoOut = _mapper.Map<PromotionDto>(promo);
            if (dtoOut != null && !string.IsNullOrEmpty(dtoOut.Image))
                dtoOut.ImageUrl = _imageHelper.GetImageUrl(dtoOut.Image);

            return new ApiResponse<PromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = dtoOut
            };
        }

        public async Task<ApiResponse<List<PromotionDto>>> GetAllPromotionsAsync()
        {
            var promos = await _context.Promotions
                .Include(p => p.Restaurant)
                .OrderByDescending(p => p.StartDate)
                .ToListAsync();

            var data = _mapper.Map<List<PromotionDto>>(promos);

            if (data != null)
            {
                foreach (var d in data)
                {
                    if (!string.IsNullOrEmpty(d.Image))
                        d.ImageUrl = _imageHelper.GetImageUrl(d.Image);
                }
            }

            return new ApiResponse<List<PromotionDto>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = data
            };
        }

        public async Task<ApiResponse<PromotionDto?>> UpdatePromotionAsync(int id, Promotion updated, IFormFile? file)
        {
            if (_userContext.Role != "business")
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User is not authorized to update promotions",
                    Data = null
                };

            var promo = await _context.Promotions
                .Include(p => p.Restaurant)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (promo == null)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Promotion not found",
                    Data = null
                };

            if (promo?.Restaurant?.OwnerId != _userContext.UserId)
                return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User does not own the restaurant",
                    Data = null
                };

            promo.Title = updated.Title;
            promo.Description = updated.Description;
            promo.StartDate = updated.StartDate;
            promo.EndDate = updated.EndDate;
            promo.DiscountType = updated.DiscountType;
            promo.DiscountValue = updated.DiscountValue;
            promo.TargetType = updated.TargetType;
            promo.VoucherCode = updated.VoucherCode;

            if (file != null)
            {
                if (!string.IsNullOrEmpty(promo.Image))
                {
                    await _photoService.DeletePhotoAsync(promo.Image);
                }

                var uploadedPublicId = await _photoService.UploadPhotoAsync(file, "promotions");
                if (uploadedPublicId == null) return new ApiResponse<PromotionDto?>
                {
                    ErrCode = ErrorCode.ServerError,
                    ErrMessage = "Failed to upload image",
                    Data = null
                };
                promo.Image = uploadedPublicId;
            }

            await _context.SaveChangesAsync();

            var dtoOut = _mapper.Map<PromotionDto>(promo);
            if (dtoOut != null && !string.IsNullOrEmpty(dtoOut.Image))
                dtoOut.ImageUrl = _imageHelper.GetImageUrl(dtoOut.Image);

            return new ApiResponse<PromotionDto?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Updated successfully",
                Data = dtoOut
            };
        }

        public async Task<ApiResponse<object>> DeletePromotionAsync(int id)
        {
            if (_userContext.Role != "business")
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User is not authorized to delete promotions",
                    Data = null
                };

            var promo = await _context.Promotions
                .Include(p => p.Restaurant)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (promo == null)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Promotion not found",
                    Data = null
                };

            if (promo?.Restaurant?.OwnerId != _userContext.UserId)
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.Forbidden,
                    ErrMessage = "User does not own the restaurant",
                    Data = null
                };

            if (!string.IsNullOrEmpty(promo.Image))
            {
                var deleted = await _photoService.DeletePhotoAsync(promo.Image);
                if (!deleted)
                    return new ApiResponse<object>
                    {
                        ErrCode = ErrorCode.ServerError,
                        ErrMessage = "Failed to delete image",
                        Data = null
                    };
            }

            _context.Promotions.Remove(promo);
            await _context.SaveChangesAsync();
            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Deleted successfully",
                Data = null
            };
        }

        public async Task RemoveExpiredPromotionsAsync()
        {
            var now = DateTime.UtcNow;
            var expiredPromotions = await _context.Promotions
                .Where(p => p.EndDate < now)
                .ToListAsync();

            if (expiredPromotions.Any())
            {
                _context.Promotions.RemoveRange(expiredPromotions);
                await _context.SaveChangesAsync();
            }
        }
    }
}
