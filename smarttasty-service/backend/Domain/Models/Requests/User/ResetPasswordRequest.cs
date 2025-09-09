using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Models.Requests.User
{
	public class ResetPasswordRequest
	{
		[Required]
		public string Token { get; set; } = null!;

		[Required]
		public string NewPassword { get; set; } = null!;
	}
}
