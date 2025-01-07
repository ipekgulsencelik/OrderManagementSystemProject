namespace OrderManagement.UI.DTOs.TastyDTO
{
    public class RootTastyDTO
    {
        public List<ResultTastyDTO> Results { get; set; }
    }

    public class ResultTastyDTO
    {
        public string Name { get; set; }
        public string original_video_url { get; set; }
        public int total_time_minutes { get; set; }
        public string thumbnail_url { get; set; }
    }
}