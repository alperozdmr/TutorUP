﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TutorUp.ServiceLayer.Abstract;
using TutorUP.DataAccessLayer.Abstract;
using TutorUP.EntityLayer.Entity;

namespace TutorUp.ServiceLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public Notification TGetByID(int id)
        {
           return _notificationDal.GetByID(id);
        }

        public List<Notification> TGetListAll()
        {
            return _notificationDal.GetListAll();
        }

        public void TMarkAsRead(int id)
        {
            _notificationDal.MarkAsRead(id);
        }

        public void TUpdate(Notification entity)
        {
           _notificationDal.Update(entity);
        }

        public List<Notification> Where(Expression<Func<Notification, bool>> expression)
        {
            return _notificationDal.Where(expression);
        }
    }
}
