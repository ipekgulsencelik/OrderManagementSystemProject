using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DTO.DTOs.DiscountDTOs
{
    public class CreateDiscountDTO
    {
        public string? Title { get; set; }
        public int DiscountRate { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}