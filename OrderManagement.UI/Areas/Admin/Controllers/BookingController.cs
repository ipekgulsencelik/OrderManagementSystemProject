using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.DTOs.BookingDTOs;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BookingController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBookingDTO>>("Bookings");
            return View(values);
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _client.DeleteAsync("Bookings/" + id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDTO createBookingDTO)
        {
            await _client.PostAsJsonAsync("Bookings", createBookingDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBookingDTO>("Bookings/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDTO updateBookingDTO)
        {
            await _client.PutAsJsonAsync("Bookings", updateBookingDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Approve(int id)
        {
            await _client.GetAsync("Bookings/BookingApproved/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Cancel(int id)
        {
            await _client.GetAsync("Bookings/BookingCancelled/" + id);
            return RedirectToAction("Index");
        }
    }
}