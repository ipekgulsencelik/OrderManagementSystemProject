namespace OrderManagement.UI.DTOs.FeatureDTOs
{
    public class ResultFeatureDTO
    {
        public int FeatureID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}