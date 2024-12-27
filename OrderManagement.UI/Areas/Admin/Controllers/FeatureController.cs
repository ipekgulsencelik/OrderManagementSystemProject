using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.FeatureDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultFeatureDTO>>("Features");
            return View(values);
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _client.DeleteAsync($"Features/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            await _client.PostAsJsonAsync("Features", createFeatureDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateFeatureDTO>($"Features/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            await _client.PutAsJsonAsync("Features", updateFeatureDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Features/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Features/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _client.GetAsync("Features/ChangeStatus/" + id);
            return RedirectToAction("Index");
        }
    }
}