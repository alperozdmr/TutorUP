using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.CustomDto
{
    public class ForumPostDTO
    {
        public int ForumPostID { get; set; }
        public string username { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public string CategoryName { get; set; }
    }
}
