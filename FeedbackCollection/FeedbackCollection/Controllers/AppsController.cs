using Feedback.Core.BusinessLayer.Interface;
using Feedback.Core.BusinessLayer.Manager;
using Feedback.Core.Models;
using Feedback.Core.Models.Common;
using Feedback.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedbackCollection.Controllers
{
    public class AppsController : BaseController
    {
        private readonly IUserManager _applicationUser;
        private readonly IPostManager _postManager;
        private readonly IPostCommentManager _postCommentManger;
        private readonly ICommentStatusManager _commentStatusManager;
        public AppsController()
        {
            _applicationUser = new UserManager();
            _postManager = new PostManager();
            _postCommentManger = new PostCommentManager();
            _commentStatusManager = new CommentStatusManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePost()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(Post model)
        {            
            var message = _postManager.Add(model);
            TempData["Message"] = message;
            return RedirectToAction("CreatePost");
        }

        public ActionResult CommentPost()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            var posts = _postManager.GetAll().OrderByDescending(o=>o.PostId).ToList();
            return View(posts);
        }

        public ActionResult ReadPost(int postId)
        {
            var post = _postManager.GetById(postId);
            return View(post);
        }

        [HttpPost]
        public ActionResult CommentPost(PostComment model)
        {
            var message = _postCommentManger.Add(model);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllComments(int postId)
        {
            var postComments = _postCommentManger.GetAll().Where(o => o.PostId == postId).ToList();
            List<PostCommentViewModel> CommentList = new List<PostCommentViewModel>();
            if (postComments.Count() > 0)
            {
                foreach (var item in postComments)
                {
                    PostCommentViewModel model = new PostCommentViewModel();
                    model.Comment = item.Comments;
                    model.Date = item.CommentsDate.ToString("dd-MMM-yyyy");
                    model.CommentId = item.CommentId;
                    CommentList.Add(model);
                }
            }
            return Json(CommentList.OrderByDescending(o=>o.CommentId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CommLike(CommentsStatu model)
        {
            model.IsLike = true;
            model.IsDislike = false;
            var message = _commentStatusManager.Add(model);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CommDisLike(CommentsStatu model)
        {
            model.IsLike = false;
            model.IsDislike = true;
            var message = _commentStatusManager.Add(model);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewPost()
        {
            var posts = _postManager.GetAll().OrderByDescending(o => o.PostId).ToList();
            return View(posts);
        }


    }
}