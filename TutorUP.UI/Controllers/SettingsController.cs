using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Data;
using MailKit.Net.Smtp;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;

namespace TutorUP.UI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ProfileSetting() {
            
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> ProfileSetting(AppUser user, IFormFile ImageFile) {
            var currentUser = await _userManager.GetUserAsync(User);
            if (ImageFile != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Profile/", ImageFile.FileName);
                await using FileStream stream = new FileStream(path, FileMode.Create);
                await ImageFile.CopyToAsync(stream);
                currentUser.ProfileImage = "/Images/Profile/" + ImageFile.FileName;
            }
           
            currentUser.ProfileImage = currentUser.ProfileImage;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Email = user.Email;
            currentUser.Major = user.Major;
            currentUser.Biography = user.Biography;
            var result = await _userManager.UpdateAsync(currentUser);
            if (result.Succeeded) { 
                return RedirectToAction("Index","Settings");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            currentUser.IsInstructor = !currentUser.IsInstructor;
            var result = await _userManager.UpdateAsync(currentUser);
         
            if (result.Succeeded)
            {
                var referer = Request.Headers["Referer"].ToString();
                if (!string.IsNullOrWhiteSpace(referer))
                    return Redirect(referer);

                return RedirectToAction("Index", "Lesson");
            }

            var errorReferer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrWhiteSpace(errorReferer))
                return Redirect(errorReferer);

            return RedirectToAction("NotFound404Page", "Error");
        }

        public async Task<IActionResult> ForgetPassword()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var rnd = new Random();
            int number = rnd.Next(100000, 1000000);
            currentUser.VerificationCode = number;
            var result = await _userManager.UpdateAsync(currentUser);
            if (result.Succeeded)
            {
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("TUTORUP renew password", "tutorupinfo@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress(currentUser.UserName, currentUser.Email);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "6 digit code " + number;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = "New Password";

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("tutorupinfo@gmail.com", "xeot jmoi jpjo wjln");

                client.Send(mimeMessage);
                client.Disconnect(true);
            }
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPassword var)
        {
            if (var.Password == var.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, var.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Settings");
            }
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Auth");
            
            

            var result = await _userManager.ChangePasswordAsync(
                user,
                model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                    ModelState.AddModelError(string.Empty, err.Description);
                return View(model);
            }
            TempData["StatusMessage"] = "Şifreniz başarıyla değiştirildi.";
            return View();
        }
    }
}
