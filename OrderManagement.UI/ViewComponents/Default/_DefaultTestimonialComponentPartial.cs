using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.TestimonialDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.ViewComponents.Default
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _client.GetFromJsonAsync<List<ResultTestimonialDTO>>("Testimonials/GetActiveTestimonials");
            return View(testimonials);
        }
    }
}