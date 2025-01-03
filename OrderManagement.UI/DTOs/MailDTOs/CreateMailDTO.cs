namespace OrderManagement.UI.DTOs.MailDTOs
{
    public class CreateMailDTO
    {
        public string? ReceiverMail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}