using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.BookingDTOs;
using OrderManagement.UI.DTOs.ContactDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _client.GetFromJsonAsync<ResultContactDTO>("Contacts/GetContact");
            string map = value.Location.ToString();
            ViewBag.location = map;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookTable(CreateBookingDTO createBookingDTO)
        {
            var value = await _client.GetFromJsonAsync<ResultContactDTO>("Contacts/GetContact");
            string map = value.Location.ToString();
            ViewBag.location = map;

            createBookingDTO.ReservationStatus = "Rezervasyon Alındı";
            createBookingDTO.Status = true;
            var responseMessage = await _client.PostAsJsonAsync("Bookings", createBookingDTO);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View();
            }
        }
    }
}