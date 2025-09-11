using System.ComponentModel.DataAnnotations;
using backend.Domain.Enums;

namespace backend.Domain.Models.Requests.User
{
    public class CreateUserRequest
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string UserPassword { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        public UserRole Role { get; set; } = UserRole.user;
    }
}
