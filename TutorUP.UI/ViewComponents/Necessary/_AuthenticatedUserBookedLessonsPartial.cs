using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;

namespace TutorUP.UI.ViewComponents.Necessary
{
    public class _AuthenticatedUserBookedLessonsPartial :ViewComponent
    {
        private readonly IBookALessonService _bookALessonService;
        private readonly ILessonService _lessonService;
        private readonly UserManager<AppUser> _userManager;

        public _AuthenticatedUserBookedLessonsPartial(IBookALessonService bookALessonService, ILessonService lessonService, UserManager<AppUser> userManager)
        {
            _bookALessonService = bookALessonService;
            _lessonService = lessonService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var bookings = _bookALessonService.Where(x => x.UserID == user.Id && x.BookDate <= DateTime.Now);
            List<LessonViewDto> lessons = new List<LessonViewDto>();
            foreach (var booking in bookings) {
                var lesson = _lessonService.TGetLessons().FirstOrDefault(x=>x.LessonID == booking.LessonId);
                lessons.Add(lesson!);
            }

            if(lessons.Any())
            {
                return View(lessons);
            }
            ViewBag.error = "There are no any past lessons";
            return View(lessons);
        }
    }
}
