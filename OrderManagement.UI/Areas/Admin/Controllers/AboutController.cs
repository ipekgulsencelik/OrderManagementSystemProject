using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.AboutDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var value = await _client.GetFromJsonAsync<ResultAboutDTO>("Abouts/GetAbout");

            if (value.AboutID == null)
                ViewBag.flag = false;
            else
                ViewBag.flag = true;

            return View(value);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
        {
            await _client.PostAsJsonAsync("Abouts", createAboutDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateAboutDTO>($"Abouts/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            await _client.PutAsJsonAsync("Abouts", updateAboutDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}