using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.CustomDto
{
    public class ForgetPassword
    {
        public int Code { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
