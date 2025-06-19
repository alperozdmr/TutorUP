using Microsoft.AspNetCore.Mvc;

namespace TutorUP.UI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
