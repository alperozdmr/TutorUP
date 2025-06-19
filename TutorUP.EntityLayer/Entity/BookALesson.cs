using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.EntityLayer.Entity
{
    [Serializable]
    public class BookALesson
    {
        public int BookALessonID { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsApproved { get; set; }
        [ForeignKey(nameof(AppUser))]
        public int UserID { get; set; }
        public AppUser AppUser { get; set; }
        public string? CancellationReason { get; set; }
        public DateTime BookDate { get; set; }
    }
}
