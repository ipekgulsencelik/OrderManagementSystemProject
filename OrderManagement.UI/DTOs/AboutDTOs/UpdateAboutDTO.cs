﻿namespace OrderManagement.UI.DTOs.AboutDTOs
{
    public class UpdateAboutDTO
    {
        public int AboutID { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}