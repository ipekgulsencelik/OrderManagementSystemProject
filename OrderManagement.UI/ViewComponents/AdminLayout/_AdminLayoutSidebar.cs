using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}