namespace OrderManagement.DTO.DTOs.SliderDTOs
{
    public class ResultSliderDTO
    {
        public int SliderID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}