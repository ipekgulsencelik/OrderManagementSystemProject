using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DTO.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        public string? CategoryName { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}