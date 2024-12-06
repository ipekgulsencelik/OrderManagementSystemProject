﻿namespace OrderManagement.Entity.Entitles
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string? Location { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FooterDescription { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}