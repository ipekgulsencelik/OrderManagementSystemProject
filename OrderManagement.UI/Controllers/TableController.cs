using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.RestaurantTableDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Controllers
{
    [AllowAnonymous]
    public class TableController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultRestaurantTableDTO>>("RestaurantTables");
            return View(values);
        }
    }
}