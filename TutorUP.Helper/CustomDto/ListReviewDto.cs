using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.CustomDto
{
    public class ListReviewDto
    {
        public int ReviewID { get; set; }
        public int LessonID { get; set; }
        public int InstructurID { get; set; }
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? UserImage { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
