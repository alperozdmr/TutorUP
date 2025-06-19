using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.Dto
{
    public class BookALessonDto
    {
        public int BookALessonID { get; set; }
        public int LessonId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }
        public int UserID { get; set; }
        public string? CancellationReason { get; set; }
        public DateTime BookDate { get; set; }
    }
}
