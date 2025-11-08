using Microsoft.AspNetCore.Mvc;
using backend.Application.Interfaces;
using backend.Infrastructure.Elastic;
using System.Threading.Tasks;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly ElasticClientProvider _elasticProvider;

        public SearchController(ISearchService searchService, ElasticClientProvider elasticProvider)
        {
            _searchService = searchService;
            _elasticProvider = elasticProvider;
        }

        // ✅ Endpoint kiểm tra kết nối Elasticsearch
        [HttpGet("ping-elastic")]
        public async Task<IActionResult> PingElastic()
        {
            var client = _elasticProvider.GetClient();
            var pingResponse = await client.PingAsync();

            if (pingResponse.IsValid)
            {
                return Ok(new { status = "success", message = "Elasticsearch is reachable" });
            }
            else
            {
                return StatusCode(500, new
                {
                    status = "fail",
                    message = "Cannot connect to Elasticsearch",
                    error = pingResponse.OriginalException?.Message
                });
            }
        }

        [HttpGet("restaurants")]
        public async Task<IActionResult> RestaurantSuggestions([FromQuery] string query)
        {
            var result = await _searchService.GetRestaurantSuggestionsAsync(query);
            return Ok(result);
        }

        [HttpGet("dishes")]
        public async Task<IActionResult> DishSuggestions([FromQuery] string query)
        {
            var result = await _searchService.GetDishSuggestionsAsync(query);
            return Ok(result);
        }
    }
}
