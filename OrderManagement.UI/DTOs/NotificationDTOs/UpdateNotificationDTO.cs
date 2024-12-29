namespace OrderManagement.UI.DTOs.NotificationDTOs
{
    public class UpdateNotificationDTO
    {
        public int NotificationID { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? Icon { get; set; }
        public bool Status { get; set; }
    }
}