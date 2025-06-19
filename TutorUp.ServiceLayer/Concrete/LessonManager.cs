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
    public class LessonManager : ILessonService
    {
        private readonly ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public void TAdd(Lesson entity)
        {
            _lessonDal.Add(entity);
        }

        public void TDelete(Lesson entity)
        {
            _lessonDal.Delete(entity);
        }

        public Lesson TGetByID(int id)
        {
            return _lessonDal.GetByID(id);
        }

        public List<LessonViewDto> TGetLessons()
        {
            return _lessonDal.GetLessons();
        }

        public List<Lesson> TGetListAll()
        {
           return _lessonDal.GetListAll();
        }

        public void TUpdate(Lesson entity)
        {
            _lessonDal.Update(entity);
        }

        public List<Lesson> Where(Expression<Func<Lesson, bool>> expression)
        {
            return _lessonDal.Where(expression);
        }
    }
}
