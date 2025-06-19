using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.Dto
{
    public class LessonDto
    {
        public int LessonID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int UserID { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public int TakenCount { get; set; }

    }
}
