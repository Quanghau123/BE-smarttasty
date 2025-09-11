using System.Text.Json;

namespace backend.Infrastructure.Messaging.Kafka
{
    public class KafkaDispatcher
    {
        public KafkaDispatcher()
        {
        }

        public async Task DispatchAsync(string @event, JsonElement payload, string txId, string? topic = null)
        {
            // TODO: thêm xử lý tuỳ ý sau này

            await Task.CompletedTask;
        }
    }
}
