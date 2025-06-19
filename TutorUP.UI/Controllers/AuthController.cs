using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using System.Security.Principal;
using System.Threading.Tasks;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;
using TutorUP.UI.Extenisons;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace TutorUP.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto var)
        {

            if (!var.Email.EndsWith("@std.yeditepe.edu.tr",
                            StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelErrorList(new List<string>() {
                    "Kayıt için yalnızca @std.yeditepe.edu.tr uzantılı e-postalar kabul edilir." });
                return View(var);
            }
            var user = new AppUser
            {
                FirstName = var.FirstName,
                LastName = var.LastName,
                Email = var.Email,
                PhoneNumber = var.PhoneNumber,
                UserName = var.UserName,
            };

            var result = await _userManager.CreateAsync(user,var.Password);
            if (result.Succeeded) {
                TempData["Message"] = "You have successfully registered with our system. Next, you can log in to the dashboard with your account.";
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("TUTORUP Register", "tutorupinfo@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress(var.UserName, var.Email);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Welcome tutorup"; 
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = "Deneme";

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("tutorupinfo@gmail.com", "xeot jmoi jpjo wjln");

                client.Send(mimeMessage);
                client.Disconnect(true);
                return RedirectToAction(nameof(AuthController.Register));
            }
            ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto var ,string returnUrl = null )
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Lesson");

            var isUser = _userManager.Users.FirstOrDefault(x=>x.Email == var.Email);
            if (isUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(isUser.UserName, var.Password,var.RememberMe, true);
            if (result.Succeeded)
            {
                return Redirect(returnUrl);
               
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "3 Dakika boyunca giriş yapamazsınız" });
            }

            ModelState.AddModelErrorList(new List<string>() { "Email veya şifre yanlış" });
            return View();
        }
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("ExternalResponse", "Auth");
            //Google'a yapılan Login talebi neticesinde kullanıcıyı yönlendirmesini istediğimiz url'i oluşturuyoruz.
            AuthenticationProperties properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            //Bağlantı kurulacak harici platformun hangisi olduğunu belirtiyor ve bağlantı özelliklerini elde ediyoruz.
            return new ChallengeResult("Google", properties);
            //ChallengeResult; kimlik doğrulamak için gerekli olan tüm özellikleri kapsayan AuthenticationProperties nesnesini alır ve ayarlar.
        }
        

        public async Task<IActionResult> ExternalResponse()
        {
            ExternalLoginInfo loginInfo = await _signInManager.GetExternalLoginInfoAsync();
            //Kullanıcıyla ilgili dış kaynaktan gelen tüm bilgileri taşıyan nesnedir.
            //Bu nesnesnin 'LoginProvider' propertysinin değerine göz atarsanız eğer hangi dış kaynaktan geliniyorsa onun bilgisinin yazdığını göreceksiniz.
            if (loginInfo == null)
                return RedirectToAction("Login");
            else
            {
                Microsoft.AspNetCore.Identity.SignInResult loginResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
                //Giriş yapıyoruz.
                if (loginResult.Succeeded)
                    return RedirectToAction("Index", "Lesson");
                else
                {
                    if (!loginInfo.Principal.FindFirst(ClaimTypes.Email).Value.EndsWith("@std.yeditepe.edu.tr",
                           StringComparison.OrdinalIgnoreCase))
                    {
                        ModelState.AddModelErrorList(new List<string>() {
                    "Kayıt için yalnızca @std.yeditepe.edu.tr uzantılı e-postalar kabul edilir." });
                        return RedirectToAction("Register" , "Auth");
                    }
                    //Eğer ki akış bu bloğa girerse ilgili kullanıcı uygulamamıza kayıt olmadığından dolayı girişi başarısız demektir.
                    //O halde kayıt işlemini yapıp, ardından giriş yaptırmamız gerekmektedir.
                    AppUser user = new AppUser
                    {
                        Email = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value,
                        UserName = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value
                    };
                    //Dış kaynaktan gelen Claimleri uygun eşlendikleri propertylere atıyoruz.
                    IdentityResult createResult = await _userManager.CreateAsync(user);
                    //Kullanıcı kaydını yapıyoruz.
                    if (createResult.Succeeded)
                    {
                        //Eğer kayıt başarılıysa ilgili kullanıcı bilgilerini AspNetUserLogins tablosuna kaydetmemiz gerekmektedir ki
                        //bir sonraki dış kaynak login talebinde Identity mimarisi ilgili kullanıcının hangi dış kaynaktan geldiğini anlayabilsin.
                        IdentityResult addLoginResult = await _userManager.AddLoginAsync(user, loginInfo);
                        //Kullanıcı bilgileri dış kaynaktan gelen bilgileriyle AspNetUserLogins tablosunda eşleştirilmek suretiyle kaydedilmiştir.
                        if (addLoginResult.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, true);
                            //await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
                            return RedirectToAction("Index" , "Lesson");
                        }
                    }

                }
            }
            return RedirectToAction("Index", "Lesson");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Lesson");

        }
    }
}
