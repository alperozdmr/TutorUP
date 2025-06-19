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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(TutorUpDbContext context) : base(context)
        {
        }

        public int GetIDByName(string name)
        {
            using var context = new TutorUpDbContext();
            var value = context.Categories.FirstOrDefault(x => x.CategoryName == name);
            return value!.CategoryID;
        }
    }
}
