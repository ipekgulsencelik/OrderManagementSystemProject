using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.DiscountDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DiscountController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultDiscountDTO>>("Discounts");
            return View(values);
        }

        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _client.DeleteAsync("Discounts/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDTO createDiscountDTO)
        {
            await _client.PostAsJsonAsync("Discounts", createDiscountDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateDiscountDTO>("Discounts/" + id);
            return View(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDTO updateDiscountDTO)
        {
            await _client.PutAsJsonAsync("Discounts", updateDiscountDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Discounts/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Discounts/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _client.GetAsync("Discounts/ChangeStatus/" + id);
            return RedirectToAction("Index");
        }
    }
}