namespace backend.Domain.Models.Requests.Reservation
{
    public class CreateReservationRequest
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public string? Note { get; set; }

        // Thông tin khách đặt
        public string ContactName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string? Email { get; set; }
    }
}
