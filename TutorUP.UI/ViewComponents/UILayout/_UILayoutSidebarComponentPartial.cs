using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.UI.ViewComponents.UILayout
{
    public class _UILayoutSidebarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _UILayoutSidebarComponentPartial(UserManager<AppUser> userManager)
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
