using OrderManagement.DTO.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DTO.DTOs.ProductDTOs
{
    public class ResultProductDTO
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }
        public ResultCategoryDTO Category { get; set; }
    }
}