using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.Dto;
using TutorUp.ServiceLayer.Abstract;

namespace TutorUP.UI.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumPostService _forumPostService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public ForumController(ICategoryService categoryService, UserManager<AppUser> userManager, IForumPostService forumPostService)
        {

            _categoryService = categoryService;
            _userManager = userManager;
            _forumPostService = forumPostService;
        }
        public IActionResult Index()
        {
            var forums = _forumPostService.TPosts();
            return View(forums);
        }
        [HttpGet]
        public IActionResult CreateForum()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateForum(ForumPostDto var, IFormFile ImageFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Forum/", ImageFile.FileName);
            await using FileStream stream = new FileStream(path, FileMode.Create);
            await ImageFile.CopyToAsync(stream);
            var.ImageUrl = "/Images/Forum/" + ImageFile.FileName;

            var user = await _userManager.GetUserAsync(User);

            var Forum = new ForumPost
            {
                Title = var.Title.ToUpper(),
                Content = var.Content,
                ImageUrl = var.ImageUrl,
                CategoryID = var.CategoryID,
                UserID = user.Id,
                CreateDate = DateTime.Now,
            };
            _forumPostService.TAdd(Forum);
            return RedirectToAction("Index", "Forum");



        }
    }
}
