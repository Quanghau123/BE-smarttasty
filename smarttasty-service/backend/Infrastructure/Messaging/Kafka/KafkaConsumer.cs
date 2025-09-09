using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace backend.Infrastructure.Messaging.Kafka
{
    public class KafkaConsumerService : BackgroundService
    {
        private readonly KafkaDispatcher _dispatcher;
        private readonly IConfiguration _config;

        public KafkaConsumerService(IConfiguration config, KafkaDispatcher dispatcher)
        {
            _config = config;
            _dispatcher = dispatcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // TODO: thêm xử lý Kafka sau này

            await Task.CompletedTask;
        }

        public override void Dispose()
        {
            // TODO: dispose các resource nếu cần

            base.Dispose();
        }
    }
}
