using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagement.UI.DTOs.CategoryDTOs;
using OrderManagement.UI.DTOs.ProductDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductDTO>>("Products/ProductListWithCategory");
            return View(values);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _client.DeleteAsync("Products/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories");

            ViewBag.categories = new List<SelectListItem>(from x in categories
                                                          select new SelectListItem
                                                          {
                                                              Text = x.CategoryName,
                                                              Value = x.CategoryID.ToString()
                                                          }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _client.PostAsJsonAsync("Products", createProductDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories");

            ViewBag.categories = new List<SelectListItem>(from x in categories
                                                          select new SelectListItem
                                                          {
                                                              Text = x.CategoryName,
                                                              Value = x.CategoryID.ToString()
                                                          }).ToList();

            var value = await _client.GetFromJsonAsync<UpdateProductDTO>("Products/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDTO updateProductDTO)
        {
            await _client.PutAsJsonAsync("Products", updateProductDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Products/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Products/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _client.GetAsync("Products/ChangeStatus/" + id);
            return RedirectToAction("Index");
        }
    }
}