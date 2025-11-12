namespace backend.Application.DTOs.User
{
    public class StaffDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? BusinessOwnerId { get; set; }
        public string? BusinessOwnerName { get; set; }

        public List<RestaurantSimpleDto> Restaurants { get; set; } = new();
    }

    public class RestaurantSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
