using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.Dto
{
    public class ForumCommentDto
    {
        public int ForumCommentID { get; set; }
        public int ForumPostID { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
