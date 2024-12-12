using OrderManagement.UI.DTOs.ProductDTOs;

namespace OrderManagement.UI.DTOs.CategoryDTOs
{
    public class ResultCategoryDTO
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
        public List<ResultProductDTO>? Products { get; set; }
    }
}