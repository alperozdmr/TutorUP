using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorUP.EntityLayer.Entity;

namespace TutorUp.ServiceLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        void TMarkAsRead(int id);
    }
}
