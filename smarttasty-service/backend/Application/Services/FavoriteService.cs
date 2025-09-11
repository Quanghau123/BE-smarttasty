using backend.Application.Interfaces;
using backend.Domain.Models;
using backend.Domain.Models.Requests.Favorite;
using backend.Infrastructure.Data;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Enums.Commons.Response;

namespace backend.Application.Services;

public class FavoriteService : IFavoriteService
{
    private readonly ApplicationDbContext _context;

    public FavoriteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<object>> CreateFavoriteAsync(CreateFavoriteRequest request)
    {
        var favorite = new Favorite
        {
            UserId = request.UserId,
            RestaurantId = request.RestaurantId,
            CreatedAt = DateTime.UtcNow
        };

        _context.Favorites.Add(favorite);
        await _context.SaveChangesAsync();

        await _context.Entry(favorite).Reference(r => r.User).LoadAsync();
        await _context.Entry(favorite).Reference(r => r.Restaurant).LoadAsync();

        return new ApiResponse<object>
        {
            ErrCode = ErrorCode.Success,
            ErrMessage = "OK",
            Data = new
            {
                favorite = new
                {
                    favorite.Id,
                    favorite.UserId,
                    favorite.RestaurantId,
                    favorite.CreatedAt
                }
            }
        };
    }

    public async Task<ApiResponse<object>> DeleteAsync(int id)
    {
        var favorite = await _context.Favorites.FindAsync(id);
        if (favorite == null)
        {
            return new ApiResponse<object>
            {
                ErrCode = ErrorCode.NotFound,
                ErrMessage = "Favorite not found",
                Data = null
            };
        }

        _context.Favorites.Remove(favorite);
        await _context.SaveChangesAsync();
        return new ApiResponse<object>
        {
            ErrCode = ErrorCode.Success,
            ErrMessage = "Deleted successfully",
            Data = null
        };
    }
}
