using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.EntityLayer.Entity
{
    [Serializable]
    public class ForumPost
    {
        public int ForumPostID { get; set; }
        [ForeignKey(nameof(AppUser))]
        public int UserID { get; set; }
        public AppUser AppUser { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<ForumComment>? ForumComment { get; set; }
    }
}
