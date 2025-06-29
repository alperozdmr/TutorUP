﻿using Microsoft.AspNetCore.Identity;
using TutorUP.EntityLayer.Entity;


namespace TutorUP.UI.CustomValidations
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();
            var isNumeric = int.TryParse(user.UserName[0]!.ToString(), out _);

            if (isNumeric)
            {
                errors.Add(new() { Code = "UserNameContainFirstLEtterDiggit",
                    Description="Kullanıcı adının ilk karakteri sayısal bir karakter içeremez." });
            }
            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
