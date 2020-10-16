using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aztuKonfrans2.Models;

namespace aztuKonfrans2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        aztuKonfransEntities konf_entities = new aztuKonfransEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Models.User _user)
        {
            if (!User.Identity.IsAuthenticated)
            {
                string email = _user.email;
                string password = _user.password;
                Models.User us = konf_entities.Users.FirstOrDefault(x => x.email == email && x.password == password);
                if (us != null)
                {
                    System.Web.Security.FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(1, us.email, DateTime.Now, DateTime.Now.AddMinutes(System.Web.Security.FormsAuthentication.Timeout.TotalMinutes), true, us.Role.role_name);

                    HttpCookie ck = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName);
                    if (ticket.IsPersistent)
                    {
                        ck.Expires = ticket.Expiration;
                    }
                    System.Web.Security.FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(ck);
                    System.Web.Security.FormsAuthentication.SetAuthCookie(us.email, true);
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(us.email, true);

                    return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { res = "0" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { res = "2" }, JsonRequestBehavior.AllowGet);
        }

        

        [HttpPost]
        public JsonResult Forgot(Models.User _user)
        {
            var _us = konf_entities.Users.FirstOrDefault(x => x.email == _user.email && x.phone == _user.phone);

            if (_us != null)
            {
                string subject = "ICEST " + Resources.Resource.password;
                string body = Resources.Resource.dear + ", " + _us.first_name + " " + _us.last_name + "!<br>" + Resources.Resource.your_pass + ": " + _us.password;
                Classes.EMail.SendMail(_us.email, subject, body);

                return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { res = "0" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut(string redirectUrl)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return Redirect(redirectUrl);
        }

    }
}