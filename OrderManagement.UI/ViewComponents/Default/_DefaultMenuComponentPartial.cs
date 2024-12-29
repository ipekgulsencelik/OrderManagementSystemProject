using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.CategoryDTOs;
using OrderManagement.UI.DTOs.ProductDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.ViewComponents.Default
{
    public class _DefaultMenuComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories/GetActiveCategories");
            ViewBag.categories = categories;

            var products = await _client.GetFromJsonAsync<List<ResultProductDTO>>("Products/ProductListWithCategory");            
            return View(products);
        }
    }
}