namespace OrderManagement.UI.DTOs.RestaurantTableDTOs
{
    public class UpdateRestaurantTableDTO
    {
        public int RestaurantTableID { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }
}