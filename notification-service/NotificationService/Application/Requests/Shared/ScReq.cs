namespace NotificationService.Application.Requests.Shared
{
    public class ScReq
    {
        public List<string>? Channels { get; set; }
        public Dictionary<string, object>? Params { get; set; }
    }
}