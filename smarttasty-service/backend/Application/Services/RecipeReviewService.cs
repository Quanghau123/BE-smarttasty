using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Data;
using backend.Application.DTOs.RecipeReview;
using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Models.Requests.RecipeReview;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;

namespace backend.Application.Services
{
    public class RecipeReviewService : IRecipeReviewService
    {
        private readonly ApplicationDbContext _context;

        public RecipeReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<RecipeReviewDTO>> CreateRecipeReviewAsync(CreateRecipeReviewRequest request)
        {
            var recipereview = new RecipeReview
            {
                UserId = request.UserId,
                RecipeId = request.RecipeId,
                Rating = request.Rating,
                Comment = request.Comment,
                CreatedAt = DateTime.UtcNow
            };

            _context.RecipeReviews.Add(recipereview);
            await _context.SaveChangesAsync();

            await _context.Entry(recipereview).Reference(r => r.User).LoadAsync();
            await _context.Entry(recipereview).Reference(r => r.Recipe).LoadAsync();

            return new ApiResponse<RecipeReviewDTO>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Created successfully",
                Data = MapToDTO(recipereview)
            };
        }

        public async Task<ApiResponse<List<RecipeReviewDTO>>> GetAllAsync()
        {
            var recipereviews = await _context.RecipeReviews
                .Include(r => r.User)
                .Include(r => r.Recipe)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            var data = recipereviews.Select(r => MapToDTO(r)).ToList();

            return new ApiResponse<List<RecipeReviewDTO>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = data
            };
        }

        public async Task<ApiResponse<RecipeReviewDTO?>> GetByIdAsync(int id)
        {
            var recipereview = await _context.RecipeReviews
                .Include(r => r.User)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipereview == null)
            {
                return new ApiResponse<RecipeReviewDTO?>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "RecipeReview not found",
                    Data = null
                };
            }

            return new ApiResponse<RecipeReviewDTO?>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = MapToDTO(recipereview)
            };
        }

        public async Task<ApiResponse<List<RecipeReviewDTO>>> SearchAsync(string keyword)
        {
            var recipereviews = await _context.RecipeReviews
                .Include(r => r.User)
                .Include(r => r.Recipe)
                .Where(r => r.Comment.Contains(keyword))
                .ToListAsync();

            var data = recipereviews.Select(r => MapToDTO(r)).ToList();

            return new ApiResponse<List<RecipeReviewDTO>>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "OK",
                Data = data
            };
        }

        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            var recipereview = await _context.RecipeReviews.FindAsync(id);
            if (recipereview == null)
            {
                return new ApiResponse<object>
                {
                    ErrCode = ErrorCode.NotFound,
                    ErrMessage = "RecipeReview not found",
                    Data = null
                };
            }

            _context.RecipeReviews.Remove(recipereview);
            await _context.SaveChangesAsync();
            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.Success,
                ErrMessage = "Deleted successfully",
                Data = null
            };
        }

        private RecipeReviewDTO MapToDTO(RecipeReview r)
        {
            return new RecipeReviewDTO
            {
                Id = r.Id,
                UserId = r.UserId,
                UserName = r.User?.UserName,
                RecipeId = r.RecipeId,
                Title = r.Recipe?.Title,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            };
        }
    }
}
