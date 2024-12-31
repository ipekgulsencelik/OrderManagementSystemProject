using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.BookingDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookTable(CreateBookingDTO createBookingDTO)
        {
            createBookingDTO.ReservationStatus = "Rezervasyon Alındı";
            createBookingDTO.Status = true;
            await _client.PostAsJsonAsync("Bookings", createBookingDTO);
            return NoContent();
        }
    }
}