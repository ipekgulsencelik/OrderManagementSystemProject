namespace OrderManagement.UI.DTOs.SocialMediaDTOs
{
    public class CreateSocialMediaDTO
    {
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}