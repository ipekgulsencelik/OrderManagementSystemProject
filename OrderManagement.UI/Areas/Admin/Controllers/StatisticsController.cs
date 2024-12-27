using Microsoft.AspNetCore.Mvc;
using OrderManagement.UI.Helpers;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class StatisticsController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}