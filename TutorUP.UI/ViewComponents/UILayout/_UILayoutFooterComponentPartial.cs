using Microsoft.AspNetCore.Mvc;

namespace TutorUP.UI.ViewComponents.UILayout
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
