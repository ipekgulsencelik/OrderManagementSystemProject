using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.FeatureDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.ViewComponents.Default
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var features = await _client.GetFromJsonAsync<List<ResultFeatureDTO>>("Features/GetLast3Features");
            return View(features);
        }
    }
}