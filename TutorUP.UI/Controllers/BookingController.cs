using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;
using TutorUP.Helper.Dto;

namespace TutorUP.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookALessonService _bookalessonService;
        private readonly ILessonService _lessonService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public BookingController(IBookALessonService bookalessonService, ILessonService lessonService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _bookalessonService = bookalessonService;
            _lessonService = lessonService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult CreateBooking(int id)
        {
            TempData["id"] = id;
            var value = _lessonService.TGetLessons().FirstOrDefault(x => x.LessonID == id);
            ViewBag.v = value?.Title;
            ViewBag.Instructor = value?.İnstructor;
            ViewBag.Description =value?.Description;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookLessonDto var )
        {
            int LessonId = int.Parse(TempData["id"].ToString());
            var user = await _userManager.GetUserAsync(User);

            var lesson = new BookALessonDto
            {
                LessonId = LessonId,
                IsCancelled = false,
                UserID = user.Id,
                CancellationReason = " ",
                BookDate = var.BookedDate,
            };

            _bookalessonService.TAdd(_mapper.Map<BookALesson>(lesson));
            return RedirectToAction("Index", "Lesson");
        }
    }
}
