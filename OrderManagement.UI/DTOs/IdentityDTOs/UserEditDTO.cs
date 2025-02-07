﻿using System.ComponentModel.DataAnnotations;

namespace OrderManagement.UI.DTOs.IdentityDTOs
{
    public class UserEditDTO
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? OldPassword { get; set; }
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler birbiri ile uyumlu değil.")]
        public string? ConfirmPassword { get; set; }
    }
}