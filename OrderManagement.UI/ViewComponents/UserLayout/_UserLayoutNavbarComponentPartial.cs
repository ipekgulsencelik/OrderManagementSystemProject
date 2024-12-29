using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.ViewComponents.UserLayout
{
    public class _UserLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}