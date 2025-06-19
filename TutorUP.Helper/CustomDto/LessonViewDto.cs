using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.CustomDto
{
    public class LessonViewDto
    {
        public int LessonID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string İnstructor { get; set; }
        public int UserId { get; set; }
        public string? ImageUrl { get; set; }
        public string Contact { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
    }
}
