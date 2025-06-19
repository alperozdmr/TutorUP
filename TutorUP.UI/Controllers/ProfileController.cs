using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> AuthenticatedUser()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        public async Task<IActionResult> OtherUsers(int id)
        {
            TempData["OtherUser"] = id;
            var user = await _userManager.Users.FirstOrDefaultAsync(x=>x.Id == id);
            return View(user);
        }
    }
}
