using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.EntityLayer.Entity
{
    public class AppUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsInstructor { get; set; }
        public string Biography { get; set; } = "";
        public string ProfileImage { get; set; } = "";
        public string Major { get; set; } = "";
        public int VerificationCode { get; set; } 


        public List<Lesson>? Lesson { get; set; }
        public List<Review>? Review   { get; set; }
        public List<ForumPost>? ForumPost   { get; set; }
        public List<ForumComment>? ForumComment   { get; set; }
        public List<Notification>? Notification   { get; set; }
        public List<BookALesson>? BookALessons   { get; set; }


    }
}
