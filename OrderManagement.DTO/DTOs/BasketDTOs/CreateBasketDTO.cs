namespace OrderManagement.DTO.DTOs.BasketDTOs
{
    public class CreateBasketDTO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int RestaurantTableID { get; set; }
    }
}