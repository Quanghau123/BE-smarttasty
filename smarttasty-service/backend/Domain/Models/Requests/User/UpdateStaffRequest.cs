namespace backend.Domain.Models.Requests.User
{
    public class UpdateStaffRequest
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
    }
}