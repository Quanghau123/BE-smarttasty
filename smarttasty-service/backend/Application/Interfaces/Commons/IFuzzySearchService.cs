namespace backend.Application.Interfaces.Commons
{
    public interface IFuzzySearchService
    {
        Task<List<T>> SearchAsync<T>(string tableName, string query, string[] columns, int limit = 30)
            where T : class;

        Task<List<string>> GetSuggestionsAsync(string tableName, string column, string query, int limit = 10);
    }
}