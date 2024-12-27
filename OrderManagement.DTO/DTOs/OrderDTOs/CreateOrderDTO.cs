namespace OrderManagement.DTO.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {
        public string? TableNumber { get; set; }
        public string? Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
    }
}