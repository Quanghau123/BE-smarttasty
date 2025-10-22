using MongoDB.Driver;
using NotificationService.Application.DTOs.KafkaPayload;
using System.Threading.Tasks;
using NotificationService.Application.Interfaces.Repositories;

namespace NotificationService.Infrastructure.Persistence.Repositories
{
    public class OfflineNotificationRepository : IOfflineNotificationRepository
    {
        private readonly IMongoCollection<NotificationPayload> _collection;

        public OfflineNotificationRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<NotificationPayload>("offline_notifications");
        }

        public async Task SaveAsync(string userId, NotificationPayload payload)
        {
            payload.Metadata ??= new();
            payload.Metadata["userId"] = userId;
            if (!payload.Metadata.ContainsKey("txId"))
            {
                payload.Metadata["txId"] = Guid.NewGuid().ToString();
            }
            await _collection.InsertOneAsync(payload);
        }

        public async Task<List<NotificationPayload>> GetPendingAsync(string userId)
        {
            var filter = Builders<NotificationPayload>.Filter.Eq("Metadata.userId", userId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task DeleteAsync(string userId, string notificationId)
        {
            var filter = Builders<NotificationPayload>.Filter.And(
                Builders<NotificationPayload>.Filter.Eq("Metadata.userId", userId),
                Builders<NotificationPayload>.Filter.Eq("Metadata.txId", notificationId)
            );
            await _collection.DeleteOneAsync(filter);
        }
    }
}