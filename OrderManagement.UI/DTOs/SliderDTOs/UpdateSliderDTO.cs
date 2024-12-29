namespace OrderManagement.UI.DTOs.SliderDTOs
{
    public class UpdateSliderDTO
    {
        public int SliderID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}