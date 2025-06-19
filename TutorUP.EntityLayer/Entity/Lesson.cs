using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.EntityLayer.Entity
{
    [Serializable]
    public class Lesson
    {
        public int LessonID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey(nameof(AppUser))]
        public int UserID { get; set; }
        public AppUser AppUser { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int TakenCount { get; set; }
        public List<Review>? Review { get; set; }
        public List<BookALesson>? BookALesson { get; set; }

    }
}
