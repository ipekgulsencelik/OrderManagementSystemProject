namespace OrderManagement.Entity.Entitles
{
    public class RestaurantTable
    {
        public int RestaurantTableID { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}