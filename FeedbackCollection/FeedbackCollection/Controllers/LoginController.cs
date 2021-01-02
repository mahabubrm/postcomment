using Feedback.Core.BusinessLayer.Interface;
using Feedback.Core.BusinessLayer.Manager;
using Feedback.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedbackCollection.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserManager _applicationUser;

        public LoginController()
        {
            _applicationUser = new UserManager();
        }

        // GET: Login
        public ActionResult Index()
        {
            var message = new ReturnMessage();
            if (TempData[AppSetting.LoginError] != null)
            {
                message = TempData[AppSetting.LoginError] as ReturnMessage;
            }
            ViewBag.Message = message;

            return View();
        }
        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            var loginResult = _applicationUser.Login(userName, password);
            if (loginResult.MessageType == MessageTypes.Success)
            {
                return RedirectToAction("Index", "Apps");
            }
            else
            {
                TempData[AppSetting.LoginError] = loginResult;
                return RedirectToAction("Index", "Login");
            }

        }


        public ActionResult Logout()
        {
            Session[AppSetting.Session] = null;
            Session["Session"] = null;
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }
    }
}