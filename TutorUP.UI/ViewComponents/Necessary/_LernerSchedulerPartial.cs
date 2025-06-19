using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.UI.ViewComponents.Necessary
{
    public class _LernerSchedulerPartial : ViewComponent
    {
        private readonly IBookALessonService _bookalessonService;
        private readonly UserManager<AppUser> _userManager;

        public _LernerSchedulerPartial(IBookALessonService bookalessonService, UserManager<AppUser> userManager)
        {
            _bookalessonService = bookalessonService;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var books = _bookalessonService.TGetLernerBooks().Where(x=>x.UserID == user.Id && x.BookDate >= DateTime.Now).ToList();
            return View(books);
        }
    }
}
