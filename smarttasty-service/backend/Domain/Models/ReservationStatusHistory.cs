using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Models
{
    public class ReservationStatusHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ReservationId { get; set; }

        [ForeignKey("ReservationId")]
        public Reservation? Reservation { get; set; }

        [Required]
        public Enums.ReservationStatus Status { get; set; }

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        public int ChangedBy { get; set; }

        public string? Note { get; set; }
    }
}
