using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.AboutDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.ViewComponents.Default
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = await _client.GetFromJsonAsync<ResultAboutDTO>("Abouts/GetAbout");
            return View(abouts);
        }
    }
}