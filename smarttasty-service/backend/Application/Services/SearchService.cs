using Nest;
using backend.Application.Interfaces;
using backend.Infrastructure.Elastic;
using backend.Application.DTOs.Search;
using backend.Infrastructure.Helpers;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace backend.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly ElasticClientProvider _elasticProvider;

        public SearchService(ElasticClientProvider elasticProvider)
        {
            _elasticProvider = elasticProvider;
        }

        public async Task<List<string>> GetRestaurantSuggestionsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<string>();

            var normalizedQuery = TextHelper.RemoveDiacritics(query.ToLower());
            var client = _elasticProvider.GetClient();
            var index = _elasticProvider.RestaurantsIndex;

            var response = await client.SearchAsync<RestaurantSearchDto>(s => s
                .Index(index)
                .Size(10)
                .Query(q => q
                    .Bool(b => b
                        .Should(
                            sh => sh.Match(m => m
                                .Field(f => f.Name)
                                .Query(normalizedQuery)
                                .Fuzziness(Fuzziness.Auto)
                                .Boost(3)
                            ),
                            sh => sh.Prefix(p => p
                                .Field(f => f.NameNoAccent)
                                .Value(normalizedQuery)
                                .Boost(2)
                            )
                        )
                    )
                )
                .Sort(srt => srt
                    .Descending(SortSpecialField.Score)
                    .Descending(f => f.Popularity)
                    .Descending(f => f.Frequency)
                )
            );

            return response.Hits.Select(h => h.Source.Name).ToList();
        }

        public async Task<List<string>> GetDishSuggestionsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<string>();

            var normalizedQuery = TextHelper.RemoveDiacritics(query.ToLower());
            var client = _elasticProvider.GetClient();
            var index = _elasticProvider.DishesIndex;

            var response = await client.SearchAsync<DishSearchDto>(s => s
                .Index(index)
                .Size(10)
                .Query(q => q
                    .Bool(b => b
                        .Should(
                            sh => sh.Match(m => m
                                .Field(f => f.NameNoAccent)
                                .Query(normalizedQuery)
                                .Fuzziness(Fuzziness.Auto)
                                .Boost(3)
                            ),
                            sh => sh.Prefix(p => p
                                .Field(f => f.NameNoAccent)
                                .Value(normalizedQuery)
                                .Boost(2)
                            )
                        )
                    )
                )
                .Sort(srt => srt
                    .Descending(SortSpecialField.Score)
                    .Descending(f => f.Popularity)
                    .Descending(f => f.Frequency)
                )
            );

            return response.Hits.Select(h => h.Source.Name).ToList();
        }
    }
}
