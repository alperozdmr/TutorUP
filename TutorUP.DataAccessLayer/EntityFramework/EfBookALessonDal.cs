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
    public class EfBookALessonDal : GenericRepository<BookALesson>, IBoookALessonDal
    {
        public EfBookALessonDal(TutorUpDbContext context) : base(context)
        {
        }

        public List<InstructorBooks> GetInstructorBooks()
        {
            using (var context = new TutorUpDbContext())
            {
                var result = from l in context.Lessons
                             join u in context.Users
                                 on l.UserID equals u.Id
                             join b in context.BookALessons
                             on l.LessonID equals b.LessonId
                             select new InstructorBooks
                             {
                                 BookALessonID = b.BookALessonID,
                                 LessonID = l.LessonID,
                                 InstructorID = l.UserID,
                                 CourseName = l.Title,
                                 LernerName = b.AppUser.FirstName + " " + b.AppUser.LastName,
                                 IsApproved = b.IsApproved,
                                 IsCancelled = b.IsCancelled,
                                 LernerID = b.UserID,
                                 BookDate = b.BookDate,

                             };
                return result.ToList();

            }
        }

        public List<LernerBooks> GetLernerBooks()
        {
            using (var context = new TutorUpDbContext())
            {
                var result = from b in context.BookALessons
                             join u in context.Users
                                 on b.UserID equals u.Id
                             join l in context.Lessons
                             on b.LessonId equals l.LessonID
                             select new LernerBooks
                             {
                                 BookALessonID=b.BookALessonID,
                                 LessonID = l.LessonID,
                                 InstructorID = l.UserID,
                                 CourseName = l.Title,
                                 IsApproved = b.IsApproved,
                                 IsCancelled = b.IsCancelled,
                                 UserID = b.UserID,
                                 BookDate = b.BookDate,
                                 
                             };
                return result.ToList();

            }
        }
    }
}
