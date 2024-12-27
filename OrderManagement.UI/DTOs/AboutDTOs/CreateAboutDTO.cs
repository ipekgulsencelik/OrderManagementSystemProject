namespace OrderManagement.UI.DTOs.AboutDTOs
{
    public class CreateAboutDTO
    {
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}