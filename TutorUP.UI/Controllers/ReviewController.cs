using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;
using TutorUP.Helper.Dto;

namespace TutorUP.UI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ILessonService _lessonService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ReviewController(IReviewService reviewService, ILessonService lessonService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _reviewService = reviewService;
            _lessonService = lessonService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult AddReview(int id)
        {
            TempData["id"] = id;
            var value = _lessonService.TGetLessons().FirstOrDefault(x => x.LessonID == id);
            ViewBag.v = value?.Title;
            ViewBag.Instructor = value?.İnstructor;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewDto var)
        {
            int LessonId = int.Parse(TempData["id"].ToString());
            var user = await _userManager.GetUserAsync(User);

            var review = new ReviewDto
            {
                Rating = var.Rate,
                Comment = var.Comment,
                UserID = user.Id,
                Date = DateTime.Now,
                LessonID = LessonId,
            };

            _reviewService.TAdd(_mapper.Map<Review>(review));
            return RedirectToAction("Index", "Lesson");
        }
        public IActionResult Reviews(int id)
        {
            var values = _reviewService.TListByLessonId(id);
            var lesson = _lessonService.TGetByID(id);
            int SumRate = values.Select(x=>x.Rating).Sum();
            if(values.Count != 0)
            {
                double avgRate = SumRate / values.Count();
                ViewBag.rate = avgRate;
            }
            ViewBag.courseName = lesson.Title.ToUpper();
            TempData["InstructorId"] = lesson?.UserID;
            return View(values);
        }
    }
}
