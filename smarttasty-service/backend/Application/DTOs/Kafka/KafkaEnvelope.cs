namespace backend.Application.DTOs.Kafka
{
    public class KafkaEnvelope<T>
    {
        public string TxId { get; set; } = Guid.NewGuid().ToString();
        public string Source { get; set; } = "smarttasty-service";
        public string Target { get; set; } = string.Empty;
        public string Event { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public T Payload { get; set; } = default!;
    }
}
