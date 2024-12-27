using OrderManagement.DTO.DTOs.OrderDTOs;
using OrderManagement.DTO.DTOs.ProductDTOs;

namespace OrderManagement.DTO.DTOs.OrderDetailDTOs
{
    public class ResultOrderDetailDTO
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public ResultProductDTO Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get => Quantity * UnitPrice; }
        public bool Status { get; set; }
        public int OrderID { get; set; }
        public ResultOrderDTO Order { get; set; }
    }
}