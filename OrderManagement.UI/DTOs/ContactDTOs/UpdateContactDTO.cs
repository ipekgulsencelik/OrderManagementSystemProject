﻿namespace OrderManagement.UI.DTOs.ContactDTOs
{
    public class UpdateContactDTO
    {
        public int ContactID { get; set; }
        public string? Location { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FooterDescription { get; set; }
    }
}