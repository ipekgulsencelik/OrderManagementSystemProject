using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.ContactDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDTO>>("Contacts");
            return View(values);
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _client.DeleteAsync($"Contacts/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDTO createContactDTO)
        {
            await _client.PostAsJsonAsync("Contacts", createContactDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateContactDTO>($"Contacts/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDTO updateContactDTO)
        {
            await _client.PutAsJsonAsync("Contacts", updateContactDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Contacts/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Contacts/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _client.GetAsync("Contacts/ChangeStatus/" + id);
            return RedirectToAction("Index");
        }
    }
}