using Microsoft.AspNetCore.Mvc;
using backend.Application.Interfaces;
using backend.Domain.Models.Requests.Reservation;
using backend.Domain.Enums;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Authorization;

namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationRequest request)
        {
            var res = await _reservationService.CreateReservationAsync(request);
            return CreateResult(res);
        }

        [Authorize(Roles = "business")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] ReservationStatus status, [FromQuery] int changedBy, [FromQuery] string? note)
        {
            var res = await _reservationService.UpdateStatusAsync(id, status, changedBy, note);
            return CreateResult(res);
        }

        [Authorize(Roles = "business")]
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetByRestaurant(int restaurantId)
        {
            var res = await _reservationService.GetReservationsByRestaurantAsync(restaurantId);
            return CreateResult(res);
        }

        [Authorize(Roles = "business,user")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var res = await _reservationService.GetReservationsByUserAsync(userId);
            return CreateResult(res);
        }

        [Authorize(Roles = "user")]
        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> Delete(int reservationId, [FromQuery] int userId)
        {
            var res = await _reservationService.DeleteReservationAsync(reservationId, userId);
            return CreateResult(res);
        }

        [Authorize(Roles = "business")]
        [HttpDelete("business/{reservationId}")]
        public async Task<IActionResult> DeleteReservationForBusiness(int reservationId, [FromQuery] int userId)
        {
            var res = await _reservationService.DeleteReservationForBusinessAsync(reservationId, userId);
            return CreateResult(res);
        }

    }
}
