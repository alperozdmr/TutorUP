using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUP.EntityLayer.Entity;
using TutorUp.ServiceLayer.Abstract;

namespace TutorUP.UI.Controllers
{
    public class CalenderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public CalenderController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            
            return View(user);
        }
    }
}
