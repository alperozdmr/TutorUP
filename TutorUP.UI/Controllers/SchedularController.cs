using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.UI.Controllers
{
    public class SchedularController : Controller
    {
        private readonly IBookALessonService _bookalessonService;
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;

        public SchedularController(IBookALessonService bookalessonService, INotificationService notificationService, UserManager<AppUser> userManager)
        {
            _bookalessonService = bookalessonService;
            _notificationService = notificationService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        
        public async Task<IActionResult> Cancel(int id)
        {
            // Notification gönderilcek
            var value = _bookalessonService.TGetByID(id);
            //var user = await _userManager.GetUserAsync(User);
            
            //var notificatrion = new Notification
            //{
            //    ToID = value.Lesson.UserID,
            //    Date = DateTime.Now,
            //    Title = " Dersi iptal etti",
            //    Description = " ",
            //    SenderName= user.FirstName +" "+user.LastName,
            //    Status = false,
            //};
            //_notificationService.TAdd(notificatrion);
            value.IsCancelled = true;
            _bookalessonService.TUpdate(value);
            return RedirectToAction("Index");

        }
        
        public async Task<IActionResult> Approve(int id)
        {
            // Notification gönderilcek
            var value = _bookalessonService.TGetByID(id);
            //var user = await _userManager.GetUserAsync(User);
            //var notificatrion = new Notification
            //{
            //    ToID = value.Lesson.UserID,
            //    Date = DateTime.Now,
            //    Title = " Dersi onayladı etti",
            //    Description = " ",
            //    SenderName = user.FirstName + " " + user.LastName,
            //    Status = false,
            //};
            //_notificationService.TAdd(notificatrion);
            value.IsApproved = true;
            _bookalessonService.TUpdate(value);
            return RedirectToAction("Index");

        }
    }
}
