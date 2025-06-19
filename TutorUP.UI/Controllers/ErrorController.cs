using Microsoft.AspNetCore.Mvc;

namespace TutorUP.UI.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult NotFound404Page()
		{
			return View();
		}
	}
}
