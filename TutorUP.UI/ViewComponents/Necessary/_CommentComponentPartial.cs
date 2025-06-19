//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using TutorUp.ServiceLayer.Abstract;

//namespace TutorUP.UI.ViewComponents.Necessary
//{
//    public class _CommentComponentPartial : ViewComponent
//    {
//        private readonly IForumCommentService _forumCommentService;

//        public _CommentComponentPartial(IForumCommentService forumCommentService)
//        {
//            _forumCommentService = forumCommentService;
//        }
//        public IViewComponentResult InvokeAsync(int forumID)
//        {
//            var comments = _forumCommentService.TGetListAll().Where(x => x.ForumPostID == forumID);
//            return View(comments);
//        }
//    }
//}
