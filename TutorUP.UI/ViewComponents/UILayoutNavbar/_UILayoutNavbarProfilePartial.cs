using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.UI.ViewComponents.UILayoutNavbar
{
    public class _UILayoutNavbarProfilePartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _UILayoutNavbarProfilePartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }
    }
}
