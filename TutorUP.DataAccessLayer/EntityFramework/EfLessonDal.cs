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
    public class EfLessonDal : GenericRepository<Lesson>, ILessonDal
    {
        public EfLessonDal(TutorUpDbContext context) : base(context)
        {
        }

        public List<LessonViewDto> GetLessons()
        {
            using (var context = new TutorUpDbContext())
            {
                var result = from l in context.Lessons
                             join u in context.Users
                                 on l.UserID equals u.Id
                             join c in context.Categories
                             on l.CategoryID equals c.CategoryID
                             select new LessonViewDto
                             {
                                 LessonID = l.LessonID,
                                 Title = l.Title,
                                 Description = l.Description,
                                 İnstructor = u.FirstName + " " + u.LastName,
                                 ImageUrl = l.ImageUrl,
                                 UserId = u.Id,
                                 Contact = u.Email,
                                 Price = l.Price,
                                 CategoryName= c.CategoryName
                             };
                return result.ToList();

            }
        }
    }
}
