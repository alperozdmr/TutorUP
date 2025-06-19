using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TutorUP.DataAccessLayer.Abstract;
using TutorUP.DataAccessLayer.Concrete;
using TutorUP.DataAccessLayer.Repositories;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.DataAccessLayer.EntityFramework
{
    public class EFNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EFNotificationDal(TutorUpDbContext context) : base(context)
        {
        }

        public void MarkAsRead(int id)
        {
            using var context = new TutorUpDbContext();
            var message = context.Notifications.FirstOrDefault(x => x.NotificationID == id);
            message.Status = true;
            context.SaveChanges();
        }
    }
}
