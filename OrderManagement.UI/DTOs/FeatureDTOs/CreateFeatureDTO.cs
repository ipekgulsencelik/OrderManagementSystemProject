namespace OrderManagement.UI.DTOs.FeatureDTOs
{
    public class CreateFeatureDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}