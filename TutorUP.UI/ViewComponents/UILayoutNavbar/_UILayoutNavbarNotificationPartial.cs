using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUP.EntityLayer.Entity;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.Helper.Dto;

namespace TutorUP.UI.ViewComponents.UILayoutNavbar
{
    public class _UILayoutNavbarNotificationPartial : ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public _UILayoutNavbarNotificationPartial(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _notificationService = notificationService;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var notifications = _notificationService.Where(x => x.ToID == user.Id && x.Status == false);

            return View(_mapper.Map<List<NotificationDto>>(notifications));
        }
    }
}
