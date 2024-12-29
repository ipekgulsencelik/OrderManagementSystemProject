namespace OrderManagement.DTO.DTOs.BasketDTOs
{
    public class UpdateBasketDTO
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int RestaurantTableID { get; set; }
    }
}