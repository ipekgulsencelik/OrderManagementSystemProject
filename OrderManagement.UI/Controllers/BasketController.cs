using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.BasketDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Controllers
{
    public class BasketController : Controller
    {
        private readonly HttpClient client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var values = await client.GetFromJsonAsync<List<ResultBasketDTO>>("Baskets/GetBasketListByTableWithProductName/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(int id)
        {
            var createBasketDTO = new CreateBasketDTO();
            createBasketDTO.ProductID = id;
            createBasketDTO.RestaurantTableID = 4;
            createBasketDTO.Quantity = 1;
            var result = await client.PostAsJsonAsync("Baskets", createBasketDTO);
            if (result.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return Json(createBasketDTO);
        }

        public async Task<IActionResult> RemoveBasketItem(int id)
        {
            await client.DeleteAsync($"Baskets/{id}");
            return RedirectToAction("Index");
        }
    }
}