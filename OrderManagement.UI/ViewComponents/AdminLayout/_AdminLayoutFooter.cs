using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}