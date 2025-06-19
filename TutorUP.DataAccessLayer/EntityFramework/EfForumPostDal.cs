using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorUP.DataAccessLayer.Abstract;
using TutorUP.DataAccessLayer.Concrete;
using TutorUP.DataAccessLayer.Repositories;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;

namespace TutorUP.DataAccessLayer.EntityFramework
{
    public class EfForumPostDal : GenericRepository<ForumPost>, IForumPostDal
    {
        public EfForumPostDal(TutorUpDbContext context) : base(context)
        {
        }

        public List<ForumPostDTO> Posts()
        {
            using (var context = new TutorUpDbContext())
            {
                var result = from f in context.ForumPosts
                             join u in context.Users
                                 on f.UserID equals u.Id
                             join c in context.Categories
                             on f.CategoryID equals c.CategoryID
                             select new ForumPostDTO
                             {
                                CategoryName = c.CategoryName,
                                ForumPostID = f.ForumPostID,
                                Title = f.Title,
                                Content = f.Content,
                                ImageUrl = f.ImageUrl,  
                                username = u.FirstName + " " + u.LastName,
                                CreateDate = f.CreateDate,
                             };
                return result.ToList();

            }
        }
    }
}
