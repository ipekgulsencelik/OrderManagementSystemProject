using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}