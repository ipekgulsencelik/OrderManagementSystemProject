using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProgressBarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
