using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using backend.Application.DTOs.Kafka;
using backend.Application.DTOs.KafkaPayload;

namespace backend.Infrastructure.Messaging.Kafka
{
    public class KafkaProducerService
    {
        private readonly IProducer<string, string> _producer;
        private readonly ILogger<KafkaProducerService> _logger;
        private readonly string[] _topics;

        public KafkaProducerService(IConfiguration config, ILogger<KafkaProducerService> logger)
        {
            _logger = logger;

            var kafkaConfig = new ProducerConfig
            {
                BootstrapServers = config["Kafka:BootstrapServers"],
                Acks = Enum.TryParse(config["Kafka:Producer:Acks"], out Acks acks) ? acks : Acks.All,
                MessageTimeoutMs = int.TryParse(config["Kafka:Producer:TimeoutMs"], out int timeout) ? timeout : 60000
            };

            _producer = new ProducerBuilder<string, string>(kafkaConfig).Build();
            _topics = config.GetSection("Kafka:Topics").Get<string[]>() ?? new[] { "default-topic" };
        }

        public async Task SendMessageAsync<T>(KafkaEnvelope<T> envelope, string? topic = null)
        {
            var targetTopic = string.IsNullOrEmpty(topic) ? _topics[0] : topic;

            var key =
                !string.IsNullOrEmpty(envelope.Target) ? envelope.Target :
                envelope.Payload is UserLoggedInPayload up && !string.IsNullOrEmpty(up.UserId) ? up.UserId :
                envelope.TxId;

            var value = JsonSerializer.Serialize(envelope);

            try
            {
                var result = await _producer.ProduceAsync(targetTopic, new Message<string, string> { Key = key, Value = value });
                _logger.LogInformation("Kafka sent to {Topic} [p={Partition}, o={Offset}] TxId={TxId}, Key={Key}",
                    targetTopic, result.Partition, result.Offset, envelope.TxId, key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending Kafka message");
            }
        }
    }
}
