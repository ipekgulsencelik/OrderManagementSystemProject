using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.Controllers
{
    public class DefaultSignalRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}