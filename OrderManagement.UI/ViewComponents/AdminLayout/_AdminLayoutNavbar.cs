using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavbar : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.unread = await _httpClient.GetStringAsync("Notifications/UnreadNotificationCount");
            return View();
        }
    }
}