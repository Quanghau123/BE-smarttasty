namespace backend.Domain.Models.Requests.User
{
    public class CreateStaffRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Password { get; set; }
    }
}