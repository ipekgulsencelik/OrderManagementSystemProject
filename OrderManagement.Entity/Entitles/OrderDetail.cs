namespace OrderManagement.Entity.Entitles
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get { return Quantity * UnitPrice; } set { } }
        public bool Status { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}