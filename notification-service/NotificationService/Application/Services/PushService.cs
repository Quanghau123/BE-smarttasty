/*delete*/

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text.Json;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Logging;
// using NotificationService.Application.DTOs.Fcm;
// using NotificationService.Application.DTOs.Kafka;
// using NotificationService.Application.DTOs.Notification;
// using NotificationService.Application.Interfaces.Services;
// using NotificationService.Infrastructure.Messaging.Kafka;
// using NotificationService.Domain.Enums;

// namespace NotificationService.Application.Services
// {
//     public class PushService
//     {
//         private readonly IFcmNotificationService _fcmService;
//         private readonly ILogger<PushService> _logger;
//         private readonly IConfiguration _config;
//         private readonly KafkaProducerService _kafkaProducer;

//         public PushService(
//             IFcmNotificationService fcmService,
//             ILogger<PushService> logger,
//             IConfiguration config,
//             KafkaProducerService kafkaProducer)
//         {
//             _fcmService = fcmService;
//             _logger = logger;
//             _config = config;
//             _kafkaProducer = kafkaProducer;
//         }

//         public async Task SendNotificationToUser(string txId, int userId, string title, string content, Dictionary<string, object>? data = null)
//         {
//             try
//             {
//                 if (!_config.GetValue<bool>("Firebase:Enable"))
//                 {
//                     _logger.LogInformation("PushService disabled, TxId={TxId}", txId);
//                     return;
//                 }

//                 // Tạo payload notification
//                 var notifPayload = new NotificationPayload
//                 {
//                     Title = title,
//                     Body = content,
//                     ReceiverType = ReceiverType.user,
//                     ReceiverIds = new List<string> { userId.ToString() },
//                     Data = data?.ToDictionary(k => k.Key, v => v.Value?.ToString() ?? "")
//                 };

//                 // Bọc payload vào KafkaEnvelope
//                 var envelope = new KafkaEnvelope<NotificationPayload>
//                 {
//                     TxId = txId,
//                     Source = "notification-service",
//                     Target = userId.ToString(),
//                     Event = "SendNotification",
//                     Timestamp = DateTime.UtcNow,
//                     Payload = notifPayload
//                 };

//                 // Gửi message qua Kafka
//                 await _kafkaProducer.SendMessageAsync(envelope);

//                 _logger.LogInformation("Push notification request sent to Kafka for user {UserId}, TxId={TxId}", userId, txId);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Error SendNotificationToUser, TxId={TxId}, UserId={UserId}", txId, userId);
//             }
//         }

//         public async Task SendNotificationToAll(string txId, string title, string content, Dictionary<string, object>? data = null)
//         {
//             try
//             {
//                 if (!_config.GetValue<bool>("Firebase:Enable"))
//                 {
//                     _logger.LogInformation("PushService disabled, TxId={TxId}", txId);
//                     return;
//                 }

//                 var notifPayload = new NotificationPayload
//                 {
//                     Title = title,
//                     Body = content,
//                     ReceiverType = ReceiverType.all,
//                     ReceiverIds = new List<string>(),
//                     Data = data?.ToDictionary(k => k.Key, v => v.Value?.ToString() ?? "")
//                 };

//                 var envelope = new KafkaEnvelope<NotificationPayload>
//                 {
//                     TxId = txId,
//                     Source = "notification-service",
//                     Target = "all",
//                     Event = "SendNotification",
//                     Timestamp = DateTime.UtcNow,
//                     Payload = notifPayload
//                 };

//                 await _kafkaProducer.SendMessageAsync(envelope);

//                 _logger.LogInformation("Broadcast push notification request sent to Kafka, TxId={TxId}", txId);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Error SendNotificationToAll, TxId={TxId}", txId);
//             }
//         }
//     }
// }
