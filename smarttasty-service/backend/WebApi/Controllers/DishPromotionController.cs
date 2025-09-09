using backend.Application.DTOs.DishPromotion;
using backend.Domain.Models.Requests.DishPromotion;
using backend.Application.Interfaces;
using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using Microsoft.AspNetCore.Mvc;

namespace backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishPromotionsController : ControllerBase
    {
        private readonly IDishPromotionService _service;

        public DishPromotionsController(IDishPromotionService service)
        {
            _service = service;
        }

        private IActionResult CreateResult<T>(ApiResponse<T> res)
        {
            return StatusCode(MapErrorCodeToStatus(res.ErrCode), res);
        }

        private int MapErrorCodeToStatus(ErrorCode code) => code switch
        {
            ErrorCode.Success => 200,
            ErrorCode.NotFound => 404,
            ErrorCode.ValidationError => 400,
            ErrorCode.Forbidden => 403,
            _ => 500
        };

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllAsync();
            return CreateResult(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _service.GetByIdAsync(id);
            return CreateResult(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDishPromotionRequest request)
        {
            var res = await _service.CreateAsync(request);
            return CreateResult(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDishPromotionRequest request)
        {
            var res = await _service.UpdateAsync(id, request);
            return CreateResult(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.DeleteAsync(id);
            return CreateResult(res);
        }
    }
}
