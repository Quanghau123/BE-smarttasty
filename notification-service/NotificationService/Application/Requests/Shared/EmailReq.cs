namespace NotificationService.Application.Requests.Shared
{
    public class EmailReq
    {
        public string Subject { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<string>? EmailCC { get; set; }
        public List<string>? EmailBCC { get; set; }

        public string EmailTemplate { get; set; } = string.Empty;
        public List<FileAttach>? FileAttachments { get; set; }
        public Dictionary<string, object>? Params { get; set; }
    }

    public class FileAttach
    {
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string Cid { get; set; } = string.Empty;
    }
}
