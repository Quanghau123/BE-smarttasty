using backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using backend.Application.Interfaces.Commons;

namespace backend.Application.Services.Commons
{
    public class FuzzySearchService : IFuzzySearchService
    {
        private readonly ApplicationDbContext _context;

        public FuzzySearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> SearchAsync<T>(string tableName, string query, string[] columns, int limit = 30)
            where T : class
        {
            if (string.IsNullOrWhiteSpace(query) || columns == null || columns.Length == 0)
                return new List<T>();

            var queryParam = query.ToLower();

            // Build WHERE clause: similarity(col, query) > 0.2 OR ...
            var similarityConditions = string.Join(" OR ", columns.Select(c =>
                $"similarity(immutable_unaccent(lower(\"{c}\")), immutable_unaccent({{0}})) > 0.2"));

            // Build ORDER BY clause: GREATEST(...)
            var orderByClause = $"GREATEST({string.Join(",", columns.Select(c =>
                $"similarity(immutable_unaccent(lower(\"{c}\")), immutable_unaccent({{0}}))"))}) DESC";

            var sql = $@"
                SELECT * FROM ""{tableName}""
                WHERE {similarityConditions}
                ORDER BY {orderByClause}
                LIMIT {limit}";

            return await _context.Set<T>()
                .FromSqlRaw(sql, queryParam)
                .ToListAsync();
        }

        public async Task<List<string>> GetSuggestionsAsync(string tableName, string column, string query, int limit = 10)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<string>();

            var sql = $@"
        SELECT ""{column}"" FROM (
            SELECT ""{column}"", similarity(immutable_unaccent(lower(""{column}"")), immutable_unaccent(@p0)) AS sim
            FROM ""{tableName}""
        ) AS t
        WHERE sim > 0.2
        ORDER BY sim DESC
        LIMIT {limit}";

            using var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            var param = cmd.CreateParameter();
            param.ParameterName = "@p0";
            param.Value = query.ToLower();
            cmd.Parameters.Add(param);

            var results = new List<string>();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                if (!reader.IsDBNull(0))
                    results.Add(reader.GetString(0));
            }

            return results;
        }
    }
}
