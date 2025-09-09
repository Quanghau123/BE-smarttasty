using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Models.Requests.User
{
	public class LoginRequest
	{
		[Required, EmailAddress]
		public string Email { get; set; } = null!;

		[Required]
		public string UserPassword { get; set; } = null!;
	}
}
