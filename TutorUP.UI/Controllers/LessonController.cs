using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;
using TutorUP.Helper.Dto;

namespace TutorUP.UI.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public LessonController(ILessonService lessonService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _lessonService = lessonService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var lessons = _lessonService.TGetLessons();

            return View(lessons);
        }

        [HttpGet]
        public IActionResult CreateLesson()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLesson(LessonDto var, IFormFile ImageFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Lesson/", ImageFile.FileName);
            await using FileStream stream = new FileStream(path, FileMode.Create);
            await ImageFile.CopyToAsync(stream);
            var.ImageUrl = "/Images/Lesson/" + ImageFile.FileName;

            var user = await _userManager.GetUserAsync(User);

            var lesson = new Lesson
            {
                Title = var.Title.ToUpper(),
                Description = var.Description,
                ImageUrl = var.ImageUrl,
                Price = var.Price,
                CategoryID = var.CategoryID,
                UserID = user.Id,
                TakenCount = 0
            };
            _lessonService.TAdd(lesson);
            return RedirectToAction("Index","Lesson");



        }
    }
}
