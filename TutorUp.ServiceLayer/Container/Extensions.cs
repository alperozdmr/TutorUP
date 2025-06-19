using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorUp.ServiceLayer.Abstract;
using TutorUp.ServiceLayer.Concrete;
using TutorUP.DataAccessLayer.Abstract;
using TutorUP.DataAccessLayer.EntityFramework;

namespace TutorUp.ServiceLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IBookALessonService, BookALessonManager>();
            services.AddScoped<IBoookALessonDal, EfBookALessonDal>();
            
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IForumCommentService, ForumCommentManager>();
            services.AddScoped<IForumCommentDal, EfForumCommentDal>();

            services.AddScoped<IForumPostService, ForumPostManager>();
            services.AddScoped<IForumPostDal, EfForumPostDal>();

            services.AddScoped<ILessonService, LessonManager>();
            services.AddScoped<ILessonDal, EfLessonDal>();

            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<INotificationDal, EFNotificationDal>();

            services.AddScoped<IReviewService, ReviewManager>();
            services.AddScoped<IReviewDal, EfReviewDal>();



        }
    }
}
