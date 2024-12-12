using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.CategoryDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories");
            return View(values);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _client.DeleteAsync("Categories/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            await _client.PostAsJsonAsync("Categories", createCategoryDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateCategoryDTO>("Categories/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            await _client.PutAsJsonAsync("Categories", updateCategoryDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Categories/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Categories/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _client.GetAsync("Categories/ChangeStatus/" + id);
            return RedirectToAction("Index");
        }
    }
}