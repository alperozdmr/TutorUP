using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUP.EntityLayer.Entity;
using TutorUp.ServiceLayer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace TutorUP.UI.ViewComponents.Necessary
{
    public class _OtherUsersLessonPartial: ViewComponent
    {
        private readonly ILessonService _lessonService;
        private readonly UserManager<AppUser> _userManager;

        public _OtherUsersLessonPartial(ILessonService lessonService, UserManager<AppUser> userManager)
        {
            _lessonService = lessonService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int userId = int.Parse(TempData["OtherUser"].ToString());
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var Lessons = _lessonService.TGetLessons().Where(x => x.UserId == user.Id).ToList();
            //ViewBag.count =Lessons.Count;
            if (Lessons.Any())
            {
                
                return View(Lessons);
            }
            ViewBag.error = "There are no any lessons";
            return View(Lessons);
        }
    }
}
