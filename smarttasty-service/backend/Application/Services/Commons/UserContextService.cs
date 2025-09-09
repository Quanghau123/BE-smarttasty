using System.Security.Claims;
using backend.Application.Interfaces.Commons;

namespace backend.Application.Services.Commons
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        public int UserId =>
            int.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id) ? id : 0;
        public string Role =>
            _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value ?? "UNKNOWN";

        public string Email =>
            _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
    }
}
