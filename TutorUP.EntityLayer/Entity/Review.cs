using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.EntityLayer.Entity
{
    [Serializable]
    public class Review
    {
        public int ReviewID { get; set; }
        public int LessonID { get; set; }
        public Lesson Lesson { get; set; }
        [ForeignKey(nameof(AppUser))]
        public int UserID { get; set; }
        public AppUser AppUser { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
