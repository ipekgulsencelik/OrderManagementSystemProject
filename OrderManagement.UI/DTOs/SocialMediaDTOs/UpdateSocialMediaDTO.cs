using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DTO.DTOs.SocialMediaDTOs
{
    public class UpdateSocialMediaDTO
    {
        public int SocialMediaID { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public bool IsShown { get; set; }
        public bool Status { get; set; }
    }
}