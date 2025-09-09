namespace backend.Application.Interfaces.Commons
{
    public interface IUserContextService
    {
        int UserId { get; }
        string Role { get; }
        string Email { get; }
    }
}
