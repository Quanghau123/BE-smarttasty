using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Data;
using backend.Application.DTOs.Review;
using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Review;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Messaging.Kafka;
using backend.Application.DTOs.Kafka;
using backend.Application.DTOs.KafkaPayload;
using backend.Application.DTOs.Commons;
using backend.Application.Interfaces.Commons;
using backend.Domain.Models.Requests.Filters;

namespace backend.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IPaginationService _paginationService;

        public ReviewService(ApplicationDbContext context, KafkaProducerService kafkaProducer, IPaginationService paginationService)
        {
            _context = context;
            _kafkaProducer = kafkaProducer;
            _paginationService = paginationService;
        }

        public async Task<ApiResponse<ReviewDTO>> CreateReviewAsync(CreateReviewRequest request)
        {
            var review = new Review
            {
                UserId = request.UserId,
                RestaurantId = request.RestaurantId,
                Rating = request.Rating,
                Comment = request.Comment,
                CreatedAt = DateTime.UtcNow
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            await _context.Entry(review).Reference(r => r.User).LoadAsync();
            await _context.Entry(review).Reference(r => r.Restaurant).LoadAsync();

            var avgRating = await _context.Reviews
                .Where(r => r.RestaurantId == request.RestaurantId)
                .AverageAsync(r => r.Rating);
            var totalReviews = await _context.Reviews
                .CountAsync(r => r.RestaurantId == request.RestaurantId);

            var restaurant = await _context.Restaurants.FindAsync(request.RestaurantId);
            if (restaurant != null)
            {
                restaurant.AverageRating = avgRating;
                await _context.SaveChangesAsync();
            }

            var payload = new RatingUpdatedPayload
            {
                RestaurantId = request.RestaurantId,
                AverageRating = avgRating,
                TotalReviews = totalReviews
            };

            var envelope = new KafkaEnvelope<RatingUpdatedPayload>
            {
                Event = "restaurant.rating.updated",
                Payload = payload,
                Target = "socket-service"
            };

            await _kafkaProducer.SendMessageAsync(envelope, "rating-topic");

            return new ApiResponse<ReviewDTO>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Review created and restaurant rating updated successfully",
                Data = MapToDTO(review)
            };
        }

        public async Task<ApiResponse<PagedDto<ReviewDTO>>> GetAllAsync(PagedRequest filter)
        {
            var query = _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Restaurant)
                .OrderByDescending(r => r.CreatedAt)
                .AsQueryable();

            var paged = await _paginationService.GetPagedResultAsync(query, filter);

            var dtoList = paged.Data.Select(MapToDTO).ToList();

            return new ApiResponse<PagedDto<ReviewDTO>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Fetched paginated reviews",
                Data = new PagedDto<ReviewDTO>(dtoList, paged.TotalRecords, paged.PageNumber, paged.PageSize)
            };
        }

        public async Task<ApiResponse<ReviewDTO?>> GetByIdAsync(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Restaurant)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (review == null)
            {
                return new ApiResponse<ReviewDTO?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Review not found",
                    Data = null
                };
            }

            return new ApiResponse<ReviewDTO?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Review found",
                Data = MapToDTO(review)
            };
        }

        public async Task<ApiResponse<PagedDto<ReviewDTO>>> GetByRestaurantIdAsync(int id, PagedRequest filter)
        {
            var query = _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Restaurant)
                .Where(r => r.RestaurantId == id)
                .OrderByDescending(r => r.CreatedAt)
                .AsQueryable();

            var paged = await _paginationService.GetPagedResultAsync(query, filter);

            var dtoList = paged.Data.Select(MapToDTO).ToList();

            return new ApiResponse<PagedDto<ReviewDTO>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Fetched paginated reviews for restaurant",
                Data = new PagedDto<ReviewDTO>(dtoList, paged.TotalRecords, paged.PageNumber, paged.PageSize)
            };
        }

        public async Task<ApiResponse<List<ReviewDTO>>> SearchAsync(string keyword)
        {
            var reviews = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Restaurant)
                .Where(r => r.Comment.Contains(keyword))
                .ToListAsync();

            return new ApiResponse<List<ReviewDTO>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = $"Found {reviews.Count} review(s) with keyword '{keyword}'",
                Data = reviews.Select(r => MapToDTO(r)).ToList()
            };
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return new ApiResponse<bool>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "Review not found",
                    Data = false
                };
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return new ApiResponse<bool>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Review deleted successfully",
                Data = true
            };
        }

        private ReviewDTO MapToDTO(Review r)
        {
            return new ReviewDTO
            {
                Id = r.Id,
                UserId = r.UserId,
                UserName = r.User?.UserName,
                RestaurantId = r.RestaurantId,
                RestaurantName = r.Restaurant?.Name,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            };
        }
    }
}
