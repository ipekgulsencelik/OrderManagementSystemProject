namespace OrderManagement.UI.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}