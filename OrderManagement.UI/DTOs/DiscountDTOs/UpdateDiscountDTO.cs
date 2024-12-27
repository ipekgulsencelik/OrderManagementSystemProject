namespace OrderManagement.UI.DTOs.DiscountDTOs
{
    public class UpdateDiscountDTO
    {
        public int DiscountID { get; set; }
        public string? Title { get; set; }
        public int DiscountRate { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}