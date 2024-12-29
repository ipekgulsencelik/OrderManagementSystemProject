namespace OrderManagement.UI.DTOs.BasketDTOs
{
    public class ResultBasketDTO
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int RestaurantTableID { get; set; }
        public string ProductName { get; set; }
    }
}