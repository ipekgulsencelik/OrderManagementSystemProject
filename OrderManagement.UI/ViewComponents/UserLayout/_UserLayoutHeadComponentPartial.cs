using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.ViewComponents.UserLayout
{
    public class _UserLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}