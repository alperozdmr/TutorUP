using Microsoft.AspNetCore.Identity;

namespace TutorUP.UI.CustomValidations
{
    public class LocalizationIdentityErrorDescriber:IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = "DuplicateUserName", Description = $"Bu {userName} daha önce başka bir kullanıcı tarafından alınmıştır" };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DuplicateEmail", Description = $"Bu {email} daha önce başka bir kullanıcı tarafından alınmıştır" };
        }
    }
}
