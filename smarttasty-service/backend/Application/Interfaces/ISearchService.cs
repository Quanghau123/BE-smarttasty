using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Application.Interfaces
{
    public interface ISearchService
    {
        Task<List<string>> GetRestaurantSuggestionsAsync(string query);
        Task<List<string>> GetDishSuggestionsAsync(string query);
    }
}
