using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.UI.ViewComponents.Default
{
    public class _DefaultBookATableComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}