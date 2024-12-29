using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.SliderDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SliderController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSliderDTO>>("Sliders");
            return View(values);
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _client.DeleteAsync("Sliders/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDTO createSliderDTO)
        {
            await _client.PostAsJsonAsync("Sliders", createSliderDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSliderDTO>("Sliders/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDTO updateSliderDTO)
        {
            await _client.PutAsJsonAsync("Sliders", updateSliderDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Sliders/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Sliders/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _client.GetAsync("Sliders/ChangeStatus/" + id);
            return RedirectToAction("Index");
        }
    }
}