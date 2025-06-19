using Microsoft.AspNetCore.Mvc;

namespace TutorUP.UI.ViewComponents.UILayout
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
