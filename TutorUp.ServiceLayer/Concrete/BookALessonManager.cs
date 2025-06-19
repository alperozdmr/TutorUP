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
    public class BookALessonManager : IBookALessonService
    {
        private readonly IBoookALessonDal _boookALessonDal;

        public BookALessonManager(IBoookALessonDal boookALessonDal)
        {
            _boookALessonDal = boookALessonDal;
        }

        public void TAdd(BookALesson entity)
        {
            _boookALessonDal.Add(entity);
        }

        public void TDelete(BookALesson entity)
        {
            _boookALessonDal.Delete(entity);
        }

        public BookALesson TGetByID(int id)
        {
            return _boookALessonDal.GetByID(id);
        }

        public List<InstructorBooks> TGetInstructorBooks()
        {
            return _boookALessonDal.GetInstructorBooks();
        }

        public List<LernerBooks> TGetLernerBooks()
        {
            return _boookALessonDal.GetLernerBooks();
        }

        public List<BookALesson> TGetListAll()
        {
            return _boookALessonDal.GetListAll();
        }

        public void TUpdate(BookALesson entity)
        {
            _boookALessonDal.Update(entity);
        }

        public List<BookALesson> Where(Expression<Func<BookALesson, bool>> expression)
        {
            return _boookALessonDal.Where(expression);
        }
    }
}
