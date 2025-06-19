using AutoMapper;
using TutorUP.EntityLayer.Entity;
using TutorUP.Helper.Dto;

namespace TutorUP.UI.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<BookALesson,BookALessonDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<ForumPost,ForumPostDto>().ReverseMap();
            CreateMap<ForumComment,ForumCommentDto>().ReverseMap();
            CreateMap<Lesson,LessonDto>().ReverseMap();
            CreateMap<Notification,NotificationDto>().ReverseMap();
            CreateMap<Review,ReviewDto>().ReverseMap();
        }
    }
}
