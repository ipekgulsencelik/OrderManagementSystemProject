using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.ContactDTOs;
using OrderManagement.UI.DTOs.SocialMediaDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.ViewComponents.UserLayout
{
    public class _UserLayoutFooterComponentPartial : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<ResultContactDTO>("Contacts/GetContact");

            ViewBag.socialMedias = await _client.GetFromJsonAsync<List<ResultSocialMediaDTO>>("SocialMedias/GetActiveSocialMedias");

            return View(values);
        }
    }
}