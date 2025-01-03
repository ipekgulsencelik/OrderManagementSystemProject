using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Entity.Entitles;
using OrderManagement.UI.DTOs.IdentityDTOs;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SettingController(UserManager<AppUser> _userManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEditDto = new UserEditDTO()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName
            };
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDTO userEditDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var passwordCheck = await _userManager.CheckPasswordAsync(user, userEditDTO.OldPassword);
                if (passwordCheck == false)
                {
                    ModelState.AddModelError("", "Şu Anki Şifrenizi Yanlış Girdiniz!");
                    return View();
                }
                user.Name = userEditDTO.Name;
                user.Surname = userEditDTO.Surname;
                user.Email = userEditDTO.Email;
                user.UserName = userEditDTO.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDTO.Password);

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["userEditInfo"] = "Bilgileriniz Güncellendi Lütfen Tekrar Giriş Yapın";
                    return RedirectToAction("Logout", "Login", new { area = "" });
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View(item);
                }
            }
            return View();
        }
    }
}