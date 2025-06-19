using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.UI.ViewComponents.Necessary
{
    public class _AuthenticatedUserLessonPartial : ViewComponent
    {
        private readonly ILessonService _lessonService;
        private readonly UserManager<AppUser> _userManager;

        public _AuthenticatedUserLessonPartial(ILessonService lessonService, UserManager<AppUser> userManager)
        {
            _lessonService = lessonService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var Lessons = _lessonService.TGetLessons().Where(x=>x.UserId == user.Id).ToList();
            return View(Lessons);
        }
    }
}
