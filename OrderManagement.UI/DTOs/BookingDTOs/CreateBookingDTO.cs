namespace OrderManagement.UI.DTOs.BookingDTOs
{
    public class CreateBookingDTO
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int PersonCount { get; set; }
        public string? ReservationStatus { get; set; }
        public DateTime BookingDate { get; set; }
        public bool Status { get; set; }
    }
}