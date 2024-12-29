using OrderManagement.UI.DTOs.ProductDTOs;
using OrderManagement.UI.DTOs.RestaurantTableDTOs;

namespace OrderManagement.DTO.DTOs.BasketDTOs
{
    public class UpdateBasketDTO
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public ResultProductDTO Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get => Quantity * Price; }
        public int RestaurantTableID { get; set; }
        public ResultRestaurantTableDTO RestaurantTable { get; set; }
    }
}