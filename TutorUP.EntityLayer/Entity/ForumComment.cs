using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.EntityLayer.Entity
{
    [Serializable]
    public class ForumComment
    {
        public int ForumCommentID { get; set; }
        [ForeignKey(nameof(ForumPost))]
        public int ForumPostID { get; set; }
        public ForumPost ForumPost { get; set; }
        
        public string UserName { get; set; }
       
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
