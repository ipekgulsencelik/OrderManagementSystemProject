using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.MessageDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        
        public IActionResult Index()
        {
            var values = _client.GetFromJsonAsync<List<ResultMessageDTO>>("Messages");
            return View(values);
        }
    }
}