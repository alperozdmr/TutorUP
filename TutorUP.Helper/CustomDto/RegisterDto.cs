using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.CustomDto
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email alanı boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Email formatı yanlıştır")]
        [RegularExpression(
        @"^[^@\s]+@std\.yeditepe\.edu\.tr$",
        ErrorMessage = "Sadece @std.yeditepe.edu.tr uzantılı e-postalar kabul edilir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kullanıcı ad alanı boş bırakılamaz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz")]
        public string PhoneNumber { get; set; }
    }
}
