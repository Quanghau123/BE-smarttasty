namespace backend.Domain.Enums.Commons.Response
{
    public enum ErrorCode
    {
        Success = 0,
        ValidationError = 1,
        NotFound = 404,
        Unauthorized = 401,
        Forbidden = 403,
        ServerError = 500,
        UnknownError = 999
    }
}
