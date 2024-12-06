﻿namespace OrderManagement.DTO.DTOs.BookingDTOs
{
    public class UpdateBookingDTO
    {
        public int BookingID { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int PersonCount { get; set; }
        public string? ReservationStatus { get; set; }
        public DateTime BookingDate { get; set; }
        public bool Status { get; set; }
    }
}