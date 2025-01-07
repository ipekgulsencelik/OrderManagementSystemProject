using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.ContactDTOs;
using OrderManagement.UI.DTOs.MessageDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var value = await _client.GetFromJsonAsync<ResultContactDTO>("Contacts/GetContact");
            string map = value.Location.ToString();
            ViewBag.location = map;
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {
            await _client.PostAsJsonAsync("Messages", createMessageDTO);
            return NoContent();
        }
    }
}