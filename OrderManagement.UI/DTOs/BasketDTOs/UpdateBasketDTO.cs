using OrderManagement.UI.DTOs.ProductDTOs;
using OrderManagement.UI.DTOs.RestaurantTableDTOs;

namespace OrderManagement.DTO.DTOs.BasketDTOs
{
    public class UpdateBasketDTO
    {
        public int BasketID { get; set; }
        public int Quantity { get; set; }
    }
}