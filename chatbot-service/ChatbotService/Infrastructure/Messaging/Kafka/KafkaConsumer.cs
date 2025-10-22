using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ChatbotService.Application.DTOs.Kafka;
using System.Threading;
using System.Threading.Tasks;

namespace ChatbotService.Infrastructure.Messaging.Kafka
{
    public class KafkaConsumerService : BackgroundService
    {
        private readonly ILogger<KafkaConsumerService> _logger;
        private readonly IConsumer<string, string> _consumer;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly string[] _topics;

        public KafkaConsumerService(IConfiguration config, ILogger<KafkaConsumerService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _topics = config.GetSection("Kafka:Topics").Get<string[]>() ?? new[] { "notifications" };

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = config["Kafka:BootstrapServers"],
                GroupId = config["Kafka:GroupId"],
                AutoOffsetReset = Enum.TryParse(config["Kafka:Consumer:AutoOffsetReset"], out AutoOffsetReset reset) ? reset : AutoOffsetReset.Earliest,
                EnableAutoCommit = bool.TryParse(config["Kafka:Consumer:EnableAutoCommit"], out bool autoCommit) && autoCommit
            };

            _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();

            try
            {
                _consumer.Subscribe(_topics);
                _logger.LogInformation("Kafka consumer subscribed to topics: {Topics}", string.Join(",", _topics));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kafka subscribe failed");
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Kafka consumer started");

            // Cho host ASP.NET mở cổng trước khi vòng lặp blocking chạy
            await Task.Yield();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Dùng CancellationToken để không block
                    var result = _consumer.Consume(stoppingToken);

                    if (result?.Message == null) continue;

                    var envelope = JsonSerializer.Deserialize<KafkaEnvelope<JsonElement>>(result.Message.Value);
                    if (envelope == null) continue;

                    using var scope = _scopeFactory.CreateScope();
                    var dispatcher = scope.ServiceProvider.GetRequiredService<KafkaDispatcher>();
                    await dispatcher.DispatchAsync(envelope.Event, envelope.Payload, envelope.TxId);

                    _consumer.Commit(result);
                }
                catch (OperationCanceledException)
                {
                    // service đang stop → thoát vòng lặp
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Kafka consumer error");
                }
            }

            _logger.LogInformation("Kafka consumer stopped");
        }

        public override void Dispose()
        {
            try
            {
                _consumer.Close();
                _consumer.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error disposing Kafka consumer");
            }

            base.Dispose();
        }
    }
}
