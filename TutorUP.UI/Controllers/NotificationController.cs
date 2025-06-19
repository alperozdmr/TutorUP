using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.Dto;
using TutorUP.UI.Extenisons;

namespace TutorUP.UI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _notificationService = notificationService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await  _userManager.GetUserAsync(User);
            var notifications = _notificationService.Where(x => x.ToID == user.Id);

            return View(_mapper.Map<List<NotificationDto>>(notifications));
        }

        public IActionResult SendNotification(int id) {
        
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["id"] = id;
            ViewBag.userName = user?.FirstName + " " + user?.LastName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendNotificationAsync(NotificationDto var)
        {
            int userID = int.Parse(TempData["id"].ToString());
            var sender = await _userManager.GetUserAsync(User);
            //User kendine mesaj atamıycak validasyon lazım buraya
            if(userID != sender.Id)
            {
                var.ToID = userID;
                var.Status = false;
                var.Date = DateTime.Now;
                var.SenderName = sender.FirstName + " " + sender.LastName;

                _notificationService.TAdd(_mapper.Map<Notification>(var));
                return RedirectToAction("Index", "Lesson");
            }
            ModelState.AddModelErrorList(new List<string>() { "Kullanıcı Kendine Mesaj Atamaz" });
            return View();

        }
        [HttpDelete]
        public IActionResult Delete(int id) {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return View();
        }
        //[HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            _notificationService.TMarkAsRead(id);
            return RedirectToAction("Index");
        }
    }
}
