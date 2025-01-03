using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace OrderManagement.UI.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult NotFound404()
        {
            return View();
        }
    }
}