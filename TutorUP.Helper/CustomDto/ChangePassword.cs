using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TutorUP.Helper.CustomDto
{
  

    public class ChangePassword
    {
        [Required]
        [DataType(DataType.Password)]
        
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        
        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }

}
