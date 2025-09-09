using backend.Domain.Enums.Commons.Response;

namespace backend.Infrastructure.Helpers.Commons.Response
{
    public class ApiResponse<T>
    {
        public ErrorCode ErrCode { get; set; }
        public string ErrMessage { get; set; } = "";
        public T? Data { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? TraceId { get; set; }
        public string Status => ErrCode == ErrorCode.Success ? "success" : "error";

        public ApiResponse() { }

        public ApiResponse(ErrorCode code, string message, T? data = default, string? traceId = null)
        {
            ErrCode = code;
            ErrMessage = message;
            Data = data;
            TraceId = traceId;
        }
    }
}
