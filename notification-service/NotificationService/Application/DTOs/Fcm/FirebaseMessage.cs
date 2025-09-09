using System.Collections.Generic;

namespace NotificationService.Application.DTOs.Fcm
{
    public class FirebaseMessage
    {
        public string? Token { get; set; } = null;
        public string? Topic { get; set; } = null;
        public FirebaseNotification Notification { get; set; } = new FirebaseNotification();
        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();
    }
}
