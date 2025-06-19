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
    public class ReviewManager : IReviewService
    {
        private readonly IReviewDal _reviewDal;

        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public void TAdd(Review entity)
        {
           _reviewDal.Add(entity);
        }

        public void TDelete(Review entity)
        {
            _reviewDal.Delete(entity);
        }

        public Review TGetByID(int id)
        {
            return _reviewDal.GetByID(id);
        }

        public List<Review> TGetListAll()
        {
           return _reviewDal.GetListAll();
        }

        public List<ListReviewDto> TListByLessonId(int id)
        {
            return _reviewDal.ListByLessonId(id);
        }

        public void TUpdate(Review entity)
        {
            _reviewDal.Update(entity);
        }

        public List<Review> Where(Expression<Func<Review, bool>> expression)
        {
            return _reviewDal.Where(expression);
        }
    }
}
