using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant? Restaurant { get; set; }

        public int AdultCount { get; set; }
        public int ChildCount { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        public TimeSpan ReservationTime { get; set; }

        public string? Note { get; set; }

        [Required]
        public Enums.ReservationStatus Status { get; set; } = Enums.ReservationStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<BookingCustomer>? Customers { get; set; }
    }
}
