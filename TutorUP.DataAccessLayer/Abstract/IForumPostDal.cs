using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;

namespace TutorUP.DataAccessLayer.Abstract
{
    public interface IForumPostDal : IGenericDal<ForumPost>
    {
        List<ForumPostDTO> Posts();
    }
}
