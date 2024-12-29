using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.DiscountDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.ViewComponents.Default
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var discounts = await _client.GetFromJsonAsync<List<ResultDiscountDTO>>("Discounts/GetActiveDiscounts");
            return View(discounts);
        }
    }
}