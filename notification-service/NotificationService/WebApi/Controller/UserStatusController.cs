using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace NotificationService.API.Controllers
{
    [ApiController]
    [Route("api/userstatus")]
    public class UserStatusController : ControllerBase
    {
        private readonly IUserStatusService _userStatus;

        public UserStatusController(IUserStatusService userStatus)
        {
            _userStatus = userStatus;
        }

        [HttpPost("online/{userId}")]
        public async Task<IActionResult> MarkOnline(string userId)
        {
            await _userStatus.MarkOnlineAsync(userId, DateTime.UtcNow);
            return Ok();
        }

        [HttpDelete("offline/{userId}")]
        public async Task<IActionResult> MarkOffline(string userId)
        {
            await _userStatus.MarkOfflineAsync(userId);
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> IsOnline(string userId)
        {
            var online = await _userStatus.IsOnlineAsync(userId);
            return Ok(new { userId, online });
        }
    }
}
