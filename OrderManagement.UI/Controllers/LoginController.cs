using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Entity.Entitles;
using OrderManagement.UI.DTOs.IdentityDTOs;

namespace OrderManagement.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDTO loginDTO, string? returnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Yanlış");
                return View();
            }
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Login");
        }

        public IActionResult Get()
        {
            return View();
        }
    }
}