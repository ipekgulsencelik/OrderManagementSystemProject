namespace OrderManagement.DTO.DTOs.TestimonialDTOs
{
    public class CreateTestimonialDTO
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}