using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
