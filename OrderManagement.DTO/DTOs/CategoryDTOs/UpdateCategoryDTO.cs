﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DTO.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}