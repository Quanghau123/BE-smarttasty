using Nest;
using Microsoft.Extensions.Configuration;

namespace backend.Infrastructure.Elastic
{
    public class ElasticClientProvider
    {
        private readonly IConfiguration _config;
        private readonly Lazy<ElasticClient> _client;

        public ElasticClientProvider(IConfiguration config)
        {
            _config = config;
            _client = new Lazy<ElasticClient>(CreateClient);
        }

        private ElasticClient CreateClient()
        {
            var uriString = _config["ElasticSettings:Uri"];
            if (string.IsNullOrWhiteSpace(uriString))
                throw new InvalidOperationException("ElasticSettings:Uri is not configured in appsettings.");

            if (!Uri.TryCreate(uriString, UriKind.Absolute, out var uri))
                throw new InvalidOperationException($"ElasticSettings:Uri value '{uriString}' is not a valid absolute URI.");

            var settings = new ConnectionSettings(uri);

            // optional basic auth if provided in config
            var username = _config["ElasticSettings:Username"];
            var password = _config["ElasticSettings:Password"];
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                settings = settings.BasicAuthentication(username, password);

            var defaultIndex = _config["ElasticSettings:DefaultIndex"];
            if (!string.IsNullOrWhiteSpace(defaultIndex))
                settings = settings.DefaultIndex(defaultIndex);

            // Do not use ThrowExceptions(alwaysThrow: true) in production; enable only for debugging.
            return new ElasticClient(settings);
        }

        public ElasticClient GetClient() => _client.Value;

        // return non-null defaults to satisfy nullable analysis
        public string RestaurantsIndex => _config["ElasticSettings:RestaurantsIndex"] ?? "restaurants";
        public string DishesIndex => _config["ElasticSettings:DishesIndex"] ?? "dishes";
    }
}