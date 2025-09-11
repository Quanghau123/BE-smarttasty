namespace backend.Domain.Models.Requests.Notifications
{
    public class SendNotificationRequest
    {
        public List<string>? TargetUserIds { get; set; }
        public List<string>? TargetRoles { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, string>? Metadata { get; set; }
    }
}