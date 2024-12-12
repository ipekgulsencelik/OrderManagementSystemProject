using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutScripts : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}