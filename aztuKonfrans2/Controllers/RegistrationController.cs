using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aztuKonfrans2.Models;

namespace aztuKonfrans2.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration

        aztuKonfransEntities konfEntities = new aztuKonfransEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(Models.User _user)
        {

            if (checkUser(_user.email))
                return Json(new { res = "0" }, JsonRequestBehavior.AllowGet);

            if (_user.password.Length < 6)
                return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);

            _user.role_id = 1;
            _user.registration_date = DateTime.Now;
            konfEntities.Users.Add(_user);
            konfEntities.SaveChanges();

            return Json(new { res = "2" }, JsonRequestBehavior.AllowGet);
        }

        public bool checkUser(string email)
        {
            Models.User _user = konfEntities.Users.FirstOrDefault(x => x.email == email);
            if (_user != null)
                return true;

            return false;

        }
    }
}