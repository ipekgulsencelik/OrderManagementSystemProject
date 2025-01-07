using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.CategoryDTOs;
using OrderManagement.UI.DTOs.ProductDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Message = "Geçersiz masa ID." });
            }

            ViewBag.tableId = id;

            try
            {
                // Kategorileri getir
                var categoriesTask = _client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories/GetActiveCategories");
                // Ürünleri getir
                var productsTask = _client.GetFromJsonAsync<List<ResultProductDTO>>("Products/ProductListWithCategory");

                await Task.WhenAll(categoriesTask, productsTask);

                var categories = await categoriesTask;
                var products = await productsTask;

                ViewBag.categories = categories;
                return View(products);
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya mesaj döndür
                ViewBag.ErrorMessage = "Menü yüklenirken bir hata oluştu.";
                ViewBag.ErrorDetails = ex.Message;
                return View(new List<ResultProductDTO>());
            }
        }
    }
}