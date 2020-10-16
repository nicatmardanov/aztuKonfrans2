using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aztuKonfrans2.Models;
using System.Web.Security;

namespace aztuKonfrans2.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        aztuKonfransEntities konfEntities = new aztuKonfransEntities();

        [Authorize(Roles = "Moderator, Admin")]
        public ActionResult AllUsers(int id)
        {
            ViewBag.PageId = id;
            ViewBag.PaperAuthors = konfEntities.Authors.ToList();
            var _user = konfEntities.Users.ToList();

            //var _authors = new User();

            //for (int i = 0; i < konfEntities.User.Count(); i++)
            //{
            //    _authors.na
            //}

            double page = (double)_user.Count / 10;
            if (page % 1 > 0)
            {
                page++;
            }

            ViewBag.MaxPage = (int)page;

            return View(_user.Skip((id - 1) * 10).Take(10));
        }

        public ActionResult MyProfile() => View(konfEntities.Users.FirstOrDefault(x => x.email == User.Identity.Name));

        public ActionResult EditProfile() => View(konfEntities.Users.FirstOrDefault(x => x.email == User.Identity.Name));

        [HttpPost]
        public JsonResult EditProfile(User _us)
        {
            var _user = konfEntities.Users.FirstOrDefault(x => x.email == User.Identity.Name);
            _user.first_name = _us.first_name;
            _user.middle_name = _us.middle_name;
            _user.last_name = _us.last_name;
            _user.phone = _us.phone;
            _user.country_id = _us.country_id;
            _user.title_id = _us.title_id;
            _user.degree_id = _us.degree_id;
            _user.topic_id = _us.topic_id;
            _user.institution = _us.institution;
            _user.position = _us.position;

            konfEntities.SaveChanges();

            return Json(new { res = "0" }, JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "Moderator, Admin")]
        public PartialViewResult UserInfo(short id)
        {
            return PartialView(konfEntities.Users.FirstOrDefault(x => x.id == id));
        }

        [Authorize(Roles = "Moderator, Admin")]
        public ActionResult SearchedUsersResult(int page, string id)
        {
            konfEntities.Configuration.ProxyCreationEnabled = false;
            var _user = konfEntities.Users.Where(x => x.first_name.ToLower().Contains(id) || x.middle_name.ToLower().Contains(id) || x.last_name.ToLower().Contains(id));
            ViewBag.PageId = page;
            ViewBag.SearchedItem = id;
            id = id.ToLower();


            if (_user.Count() > 0)
            {
                double max_page = (double)_user.Count() / 10;
                if (max_page % 1 > 0)
                {
                    max_page++;
                }

                ViewBag.MaxPage = (int)max_page;
                return View("AllUsers", _user.ToList().Skip((page - 1) * 10).Take(10));
            }
            return View("AllUsers", new List<Models.User>());
        }
        [Authorize(Roles = "Moderator, Admin")]
        public JsonResult ChangeRole(int id, int type)
        {
            var _user = konfEntities.Users.FirstOrDefault(x => x.id == id);
            //Roles.AddUserToRole(_user.email, "User");

            if (type == 0)
            {
                Roles.AddUserToRole(_user.email, "Admin");
                Roles.RemoveUserFromRole(_user.email, "User");
            }
            else if (type == 1)
            {
                Roles.AddUserToRole(_user.email, "User");
                Roles.RemoveUserFromRole(_user.email, "Admin");
            }


            return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);
        }


    }
}