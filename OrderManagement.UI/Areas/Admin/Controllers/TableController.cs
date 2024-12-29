using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.RestaurantTableDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class TableController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultRestaurantTableDTO>>("RestaurantTables");
            return View(values);
        }

        public async Task<IActionResult> DeleteTable(int id)
        {
            await _client.DeleteAsync("RestaurantTables/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateTable()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateRestaurantTableDTO createRestaurantTableDTO)
        {
            await _client.PostAsJsonAsync("RestaurantTables", createRestaurantTableDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTable(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateRestaurantTableDTO>($"RestaurantTables/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTable(UpdateRestaurantTableDTO updateRestaurantTableDTO)
        {
            await _client.PutAsJsonAsync("RestaurantTables", updateRestaurantTableDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TableListByStatus()
        {
            var values = await _client.GetFromJsonAsync<List<ResultRestaurantTableDTO>>("RestaurantTables");
            return View(values);
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _client.GetAsync("RestaurantTables/ChangeStatus/" + id);
            return RedirectToAction("Index");
        }
    }
}