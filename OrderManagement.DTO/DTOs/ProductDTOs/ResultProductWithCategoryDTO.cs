using OrderManagement.DTO.DTOs.CategoryDTOs;

namespace OrderManagement.DTO.DTOs.ProductDTOs
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