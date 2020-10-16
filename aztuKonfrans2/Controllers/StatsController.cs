using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aztuKonfrans2.Models;

namespace aztuKonfrans2.Controllers
{
    [Authorize(Roles ="Admin")]
    public class StatsController : Controller
    {
        // GET: Stats
        aztuKonfransEntities konfransEntities = new aztuKonfransEntities();
        public ActionResult Index()
        {
            ViewBag.Paper = konfransEntities.Papers.Where(x => x.isVisible == 1);
            return View(konfransEntities.Users.Where(x => x.Papers.Where(y => y.isVisible == 1).Count() > 0));
        }

        public ActionResult UserInfo(int id)
        {
            ViewBag.Id = id;
            return View(konfransEntities.Papers.Where(x => x.isVisible == 1 && x.User.country_id == id).ToList());
        }

        public ActionResult ApprovedPapersUser()
        {
            ViewBag.Id = 0;
            return View("UserInfo", konfransEntities.Papers.Where(x=>x.isVisible==1 && x.isApproved==1).ToList());
        }
    }
}