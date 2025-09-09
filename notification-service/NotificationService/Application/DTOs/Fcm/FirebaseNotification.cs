namespace NotificationService.Application.DTOs.Fcm
{
   using Newtonsoft.Json;
public class FirebaseNotification
{
    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("body")]
    public string Body { get; set; } = string.Empty;
}
}
