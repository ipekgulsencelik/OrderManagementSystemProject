namespace OrderManagement.Entity.Entitles
{
    public class Basket
    {
        public int BasketID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get => Quantity * Product.Price; }
        public int ProductID { get; set; }
        public Product Product { get; set; }    
        public int RestaurantTableID { get; set; }
        public RestaurantTable RestaurantTable { get; set; }
    }
}