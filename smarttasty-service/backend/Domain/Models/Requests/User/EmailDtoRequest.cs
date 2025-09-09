using System.ComponentModel.DataAnnotations;


namespace backend.Domain.Models.Requests.User
{
    public class EmailDtoRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
