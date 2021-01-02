using Feedback.Core.BusinessLayer.Interface;
using Feedback.Core.BusinessLayer.Manager;
using Feedback.Core.Models;
using Feedback.Core.Models.Common;
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
            var posts = _postManager.GetAll();
            return View(posts);
        }

        public ActionResult ViewPost()
        {
            return View();
        }


    }
}