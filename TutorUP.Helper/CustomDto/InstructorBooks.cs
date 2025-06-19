using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.CustomDto
{
    public class InstructorBooks
    {
        public int BookALessonID { get; set; }
        public int LessonID { get; set; }
        public int InstructorID { get; set; }
        public string? LernerName { get; set; }
        public string? CourseName { get; set; }
        public int LernerID { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime BookDate { get; set; }
    }
}
