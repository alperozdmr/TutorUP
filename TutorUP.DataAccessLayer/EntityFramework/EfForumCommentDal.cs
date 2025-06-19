using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorUP.DataAccessLayer.Abstract;
using TutorUP.DataAccessLayer.Concrete;
using TutorUP.DataAccessLayer.Repositories;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.DataAccessLayer.EntityFramework
{
    public class EfForumCommentDal : GenericRepository<ForumComment>, IForumCommentDal
    {
        public EfForumCommentDal(TutorUpDbContext context) : base(context)
        {
        }
    }
}
