using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUP.EntityLayer.Entity;
using TutorUp.ServiceLayer.Abstract;

namespace TutorUP.UI.ViewComponents.Necessary
{
    public class _CalenderLernerComponentPartial : ViewComponent
    {
        private readonly IBookALessonService _bookalessonService;
        private readonly UserManager<AppUser> _userManager;

        public _CalenderLernerComponentPartial(IBookALessonService bookalessonService, UserManager<AppUser> userManager)
        {
            _bookalessonService = bookalessonService;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var books = _bookalessonService.TGetLernerBooks().Where(x => x.UserID == user.Id).ToList();

            return View(books);
        }
    }
}
