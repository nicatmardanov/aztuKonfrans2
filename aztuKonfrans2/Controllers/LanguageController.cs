using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aztuKonfrans2.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Change(string id, string redirectUrl)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(id);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(id);

            HttpCookie cookie = new HttpCookie("lang");
            cookie.Value = id;
            Response.Cookies.Add(cookie);

            return Redirect(redirectUrl);
        }
    }
}