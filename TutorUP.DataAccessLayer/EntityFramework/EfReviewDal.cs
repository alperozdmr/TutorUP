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
    public class EfReviewDal : GenericRepository<Review>, IReviewDal
    {
        public EfReviewDal(TutorUpDbContext context) : base(context)
        {
        }

        public List<ListReviewDto> ListByLessonId(int id)
        {
            using (var context = new TutorUpDbContext())
            {
                var result = from r in context.Reviews
                             join l in context.Lessons
                                 on r.LessonID equals l.LessonID
                             join u in context.Users
                             on r.UserID equals u.Id
                             select new ListReviewDto
                             {
                                 LessonID = l.LessonID,
                                 ReviewID = r.ReviewID,
                                 InstructurID = l.UserID,
                                 UserID = u.Id,
                                 UserName = u.FirstName + " " + u.LastName,
                                 UserImage = u.ProfileImage,
                                 Comment = r.Comment,
                                 Rating = r.Rating,
                             };
                return result.Where(x => x.LessonID == id).ToList();
            }
        }
    }
}
