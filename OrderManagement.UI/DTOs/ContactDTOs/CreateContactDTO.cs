namespace OrderManagement.UI.DTOs.ContactDTOs
{
    public class CreateContactDTO
    {
        public string? Location { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FooterDescription { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}