using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.CustomDto;

namespace TutorUp.ServiceLayer.Abstract
{
    public interface ILessonService : IGenericService<Lesson>
    {
        List<LessonViewDto> TGetLessons();
    }
}
