using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.EntityLayer.Entity
{
    [Serializable]
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public List<Lesson>? Lesson { get; set; }
        public List<ForumPost>? ForumPost { get; set; }
    }
}
