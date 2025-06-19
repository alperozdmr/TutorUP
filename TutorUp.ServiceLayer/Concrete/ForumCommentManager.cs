using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.DataAccessLayer.Abstract;
using TutorUP.EntityLayer.Entity;

namespace TutorUp.ServiceLayer.Concrete
{
    public class ForumCommentManager : IForumCommentService
    {
        private readonly IForumCommentDal _forumCommentDal;

        public ForumCommentManager(IForumCommentDal forumCommentDal)
        {
            _forumCommentDal = forumCommentDal;
        }

        public void TAdd(ForumComment entity)
        {
           _forumCommentDal.Add(entity);
        }

        public void TDelete(ForumComment entity)
        {
           _forumCommentDal.Delete(entity);
        }

        public ForumComment TGetByID(int id)
        {
           return _forumCommentDal.GetByID(id);
        }

        public List<ForumComment> TGetListAll()
        {
            return _forumCommentDal.GetListAll();
        }

        public void TUpdate(ForumComment entity)
        {
            _forumCommentDal.Update(entity);
        }

        public List<ForumComment> Where(Expression<Func<ForumComment, bool>> expression)
        {
            return _forumCommentDal.Where(expression);
        }
    }
}
