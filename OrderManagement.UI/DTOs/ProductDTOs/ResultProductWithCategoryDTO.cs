using OrderManagement.UI.DTOs.CategoryDTOs;

namespace OrderManagement.UI.DTOs.ProductDTOs
{
    public class ResultProductWithCategoryDTO
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
        public string? CategoryName { get; set; }
        public ResultCategoryDTO CategoryDTO { get; set; }
    }
}