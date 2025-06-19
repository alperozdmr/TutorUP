using Microsoft.AspNetCore.Mvc;

namespace TutorUP.UI.ViewComponents.UILayout
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
