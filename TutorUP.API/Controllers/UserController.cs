using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;

namespace TutorUP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto var)
        {
            var user = new AppUser
            {
                FirstName = var.FirstName,
                LastName = var.LastName,
                Email = var.Email,
                UserName = var.UserName,
                PhoneNumber = var.PhoneNumber,
            };
            await _userManager.CreateAsync(user,var.Password);
            return Ok();
        }
        [HttpGet]
        public IActionResult list()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> SignInAsync(LoginDto var)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Email == var.Email);
            var result = await _signInManager.PasswordSignInAsync(user!, var.Password,false,false);
            if (result.Succeeded) {
                return Ok("Giriş Yapıldı");
            }
            return BadRequest();
        }

    }
}
