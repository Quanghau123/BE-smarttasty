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

namespace backend.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
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

            return new ApiResponse<ReviewDTO>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Review created successfully",
                Data = MapToDTO(review)
            };
        }

        public async Task<ApiResponse<List<ReviewDTO>>> GetAllAsync()
        {
            var reviews = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Restaurant)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return new ApiResponse<List<ReviewDTO>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Fetched all reviews",
                Data = reviews.Select(r => MapToDTO(r)).ToList()
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

        public async Task<ApiResponse<List<ReviewDTO>>> GetByRestaurantIdAsync(int id)
        {
            var reviews = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Restaurant)
                .Where(r => r.RestaurantId == id)
                .ToListAsync();

            if (reviews == null || !reviews.Any())
            {
                return new ApiResponse<List<ReviewDTO>>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "No reviews found",
                    Data = new List<ReviewDTO>()
                };
            }

            return new ApiResponse<List<ReviewDTO>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Reviews found",
                Data = reviews.Select(MapToDTO).ToList()
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
