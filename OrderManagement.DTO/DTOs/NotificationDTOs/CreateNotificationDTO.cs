namespace OrderManagement.DTO.DTOs.NotificationDTOs
{
    public class CreateNotificationDTO
    {
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? Icon { get; set; }
        public bool Status { get; set; }
    }
}