using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.DataAccessLayer.Abstract;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;

namespace TutorUp.ServiceLayer.Concrete
{
    public class ForumPostManager : IForumPostService
    {
        private readonly IForumPostDal _forumPostDal;

        public ForumPostManager(IForumPostDal forumPostDal)
        {
            _forumPostDal = forumPostDal;
        }

        public void TAdd(ForumPost entity)
        {
            _forumPostDal.Add(entity);
        }

        public void TDelete(ForumPost entity)
        {
           _forumPostDal.Delete(entity);
        }

        public ForumPost TGetByID(int id)
        {
            return _forumPostDal.GetByID(id);  
        }

        public List<ForumPost> TGetListAll()
        {
            return _forumPostDal.GetListAll();
        }

        public List<ForumPostDTO> TPosts()
        {
            return _forumPostDal.Posts();
        }

        public void TUpdate(ForumPost entity)
        {
           _forumPostDal.Update(entity);
        }

        public List<ForumPost> Where(Expression<Func<ForumPost, bool>> expression)
        {
            return _forumPostDal.Where(expression);
        }
    }
}
