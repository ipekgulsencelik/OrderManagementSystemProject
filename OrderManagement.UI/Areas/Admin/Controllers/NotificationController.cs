using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.NotificationDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class NotificationController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultNotificationDTO>>("Notifications");
            return View(values);
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _client.DeleteAsync("Notifications/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDTO createNotificationDTO)
        {
            await _client.PostAsJsonAsync("Notifications", createNotificationDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateNotificationDTO>($"Notifications/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDTO updateNotificationDTO)
        {
            await _client.PutAsJsonAsync("Notifications", updateNotificationDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _client.GetAsync($"Notifications/MarkAsRead/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MarkAsUnread(int id)
        {
            await _client.GetAsync($"Notifications/MarkAsUnread/" + id);
            return RedirectToAction("Index");
        }
    }
}