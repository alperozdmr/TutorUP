using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        void MarkAsRead(int id);
        //void ApprovedNotification(int lessonId);
        //void CancelledNotification(int lessonId);
    }
}
