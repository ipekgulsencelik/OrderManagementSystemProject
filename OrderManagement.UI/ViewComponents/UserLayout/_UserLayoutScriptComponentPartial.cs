using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.ViewComponents.UserLayout
{
    public class _UserLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}