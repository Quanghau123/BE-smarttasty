using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class BookingCustomer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ReservationId { get; set; }

        [ForeignKey("ReservationId")]
        public Reservation? Reservation { get; set; }

        [Required]
        public string ContactName { get; set; } = "";

        [Required]
        public string Phone { get; set; } = "";

        public string? Email { get; set; }
    }
}
