using OrderManagement.DTO.DTOs.OrderDetailDTOs;

namespace OrderManagement.DTO.DTOs.OrderDTOs
{
    public class ResultOrderDTO
    {
        public int OrderID { get; set; }
        public string? TableNumber { get; set; }
        public string? Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }

        public List<ResultOrderDetailDTO> OrderDetails { get; set; }
    }
}