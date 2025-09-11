namespace NotificationService.Application.Requests.Shared
{
    public class PushNotiReq
    {
        public string? Topic { get; set; }
        public Dictionary<string, object>? Params { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<string>? DisableNotifyDeviceIds { get; set; }
    }
}
