namespace OrderManagement.Entity.Entitles
{
    public class Order
    {
        public int OrderID { get; set; }
        public string? TableNumber { get; set; }
        public string? Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}