using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aztuKonfrans2.Models;

namespace aztuKonfrans2.Controllers
{
    [Authorize]
    public class PaperController : Controller
    {
        // GET: Paper

        [AllowAnonymous]
        public ActionResult Submission()
        {
            if ((User.Identity.IsAuthenticated && Classes.PaperDeadline.deadlineValue >= 0) || User.IsInRole("Admin"))
            {
                aztuKonfransEntities konfEntities = new aztuKonfransEntities();
                User _user = konfEntities.Users.FirstOrDefault(x => x.email == User.Identity.Name);
                return View(_user);
            }

            if (Classes.PaperDeadline.deadlineValue < 0)
            {
                ViewBag.DeadLine = 1;
            }

            return View();
        }


        [HttpPost]
        public JsonResult AddPaper(string title, string topic_id, string[] authorsFullName, string[] authorsTitle, string[] authorsDegree, string[] authorsCountry, string[] authorsEmail, string[] authorsPhone, string[] authorsInstitution, string[] authorsPosition, HttpPostedFileBase paperFile)
        {

            if (Classes.PaperDeadline.deadlineValue >= 0 || User.IsInRole("Admin"))
            {
                aztuKonfransEntities konfEntities = new aztuKonfransEntities();
                var paper_file = Request.Files[0];

                Paper _paper = new Paper();
                var l = Request.Files[0];
                _paper.title = title;
                _paper.topic_id = byte.Parse(topic_id);
                _paper.user_id = konfEntities.Users.FirstOrDefault(x => x.email == User.Identity.Name).id;

                string paper_path = "/Content/papers/" + Guid.NewGuid() + _paper.user_id + System.IO.Path.GetExtension(paper_file.FileName);
                string email_path = "http://az-tr-conference2019.com" + paper_path;

                paper_file.SaveAs(Server.MapPath(paper_path));

                _paper.file_path = paper_path;
                _paper.submit_date = DateTime.Now;
                _paper.isVisible = 1;

                if (konfEntities.Users.FirstOrDefault(x => x.email == User.Identity.Name).role_id == 1)
                    _paper.isApproved = 0;
                else
                    _paper.isApproved = 1;

                konfEntities.Papers.Add(_paper);
                konfEntities.SaveChanges();

                if (authorsFullName != null)
                {
                    Author _author; Paper_Author p_author;
                    for (int i = 0; i < authorsFullName.Length; i++)
                    {
                        _author = new Author();
                        _author.full_name = authorsFullName[i];
                        _author.title_id = byte.Parse(authorsTitle[i]);
                        _author.degree_id = byte.Parse(authorsDegree[i]);
                        _author.country_id = byte.Parse(authorsCountry[i]);
                        _author.email = authorsEmail[i];
                        _author.phone = authorsPhone[i];
                        _author.institution = authorsInstitution[i];
                        _author.position = authorsPosition[i];
                        _author.isVisible = 1;
                        konfEntities.Authors.Add(_author);
                        konfEntities.SaveChanges();

                        p_author = new Paper_Author();
                        p_author.paper_id = _paper.id;
                        p_author.author_id = _author.id;
                        p_author.isVisible = 1;
                        konfEntities.Paper_Author.Add(p_author);
                        konfEntities.SaveChanges();
                    }
                }
                else
                {
                    Paper_Author p_author = new Paper_Author();
                    p_author.paper_id = _paper.id;
                    p_author.isVisible = 1;
                    konfEntities.Paper_Author.Add(p_author);
                    konfEntities.SaveChanges();
                }
            }


            return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(int paper_id, string title, string topic_id, string[] edit_arr, string[] authorsFullName, string[] authorsTitle, string[] authorsDegree, string[] authorsCountry, string[] authorsEmail, string[] authorsPhone, string[] authorsInstitution, string[] authorsPosition, HttpPostedFileBase paperFile, string fileHave)
        {
            aztuKonfransEntities konfEntities = new aztuKonfransEntities();
            Paper _paper = konfEntities.Papers.FirstOrDefault(x => x.id == paper_id);
            if ((Classes.PaperDeadline.deadlineValue >= 0 && _paper.User.email == User.Identity.Name) || User.IsInRole("Admin"))
            {
                int[] edited_author;

                _paper.title = title;
                _paper.topic_id = byte.Parse(topic_id);
                if (fileHave == null)
                {
                    var paper_file = Request.Files[0];
                    string paper_path = "/Content/papers/" + Guid.NewGuid() + _paper.user_id + System.IO.Path.GetExtension(paper_file.FileName);
                    paper_file.SaveAs(Server.MapPath(paper_path));
                    _paper.file_path = paper_path;
                }

                konfEntities.SaveChanges();

                var passed_paper_count = 0;
                if (edit_arr != null)
                {
                    var iter = 0;
                    edited_author = new int[edit_arr.Length];

                    for (int i = 0; i < edit_arr.Length; i++)
                    {
                        edited_author[i] = int.Parse(edit_arr[i]);
                    }

                    passed_paper_count = edited_author.Count(x => x > 0);
                    int remove_author_id;

                    for (int i = 0; i < edit_arr.Length; i++)
                    {
                        if (edited_author[i] < 0)
                        {
                            remove_author_id = -edited_author[i];
                            //konfEntities.Paper_Author.Remove(_paper.Paper_Author.FirstOrDefault(x => x.author_id == remove_author_id));
                            //konfEntities.Authors.Remove(konfEntities.Authors.FirstOrDefault(x => x.id == remove_author_id));
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == remove_author_id).isVisible = 0;
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == remove_author_id).Author.isVisible = 0;
                        }
                        else if (edited_author[i] > 0)
                        {
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == edited_author[i]).Author.full_name = authorsFullName[iter];
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == edited_author[i]).Author.title_id = byte.Parse(authorsTitle[iter]);
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == edited_author[i]).Author.degree_id = byte.Parse(authorsDegree[iter]);
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == edited_author[i]).Author.country_id = byte.Parse(authorsCountry[iter]);
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == edited_author[i]).Author.email = authorsEmail[iter];
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == edited_author[i]).Author.phone = authorsPhone[iter];
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == edited_author[i]).Author.institution = authorsInstitution[iter];
                            _paper.Paper_Author.FirstOrDefault(x => x.author_id == edited_author[i]).Author.position = authorsPosition[iter];
                            iter++;
                        }

                        konfEntities.SaveChanges();
                    }
                }

                if (authorsFullName != null)
                {
                    if (authorsFullName.Length > passed_paper_count)
                    {
                        if (passed_paper_count == 0)
                            konfEntities.Paper_Author.FirstOrDefault(x => x.Author == null).isVisible = 0;
                        //konfEntities.Paper_Author.Remove(_paper.Paper_Author.FirstOrDefault(x => x.Author == null));

                        Author _author; Paper_Author p_author;
                        for (int i = passed_paper_count; i < authorsFullName.Length; i++)
                        {
                            _author = new Author();
                            _author.full_name = authorsFullName[i];
                            _author.title_id = byte.Parse(authorsTitle[i]);
                            _author.degree_id = byte.Parse(authorsDegree[i]);
                            _author.country_id = byte.Parse(authorsCountry[i]);
                            _author.email = authorsEmail[i];
                            _author.phone = authorsPhone[i];
                            _author.institution = authorsInstitution[i];
                            _author.position = authorsPosition[i];
                            _author.isVisible = 1;
                            konfEntities.Authors.Add(_author);
                            konfEntities.SaveChanges();

                            p_author = new Paper_Author();
                            p_author.paper_id = _paper.id;
                            p_author.author_id = _author.id;
                            p_author.isVisible = 1;
                            konfEntities.Paper_Author.Add(p_author);
                            konfEntities.SaveChanges();
                        }
                    }
                }
            }




            return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "Moderator, Admin")]
        public ActionResult AllPapers(short id)
        {
            aztuKonfransEntities konfEntities = new aztuKonfransEntities();
            ViewBag.PaperType = 1;
            ViewBag.PageId = id;

            var _paper = konfEntities.Papers.Where(x => x.isVisible == 1).ToList();

            double page = (double)_paper.Count / 10;
            if (page % 1 > 0)
            {
                page++;
            }

            ViewBag.MaxPage = (int)page;


            return View(_paper.Skip((id - 1) * 10).Take(10));

        }

        public PartialViewResult NewAuthor()
        {
            return PartialView();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult NonApprovedPapers()
        {
            Models.aztuKonfransEntities konfEntities = new Models.aztuKonfransEntities();
            ViewBag.PaperType = 0;

            var _paper = konfEntities.Papers.Where(x => x.isVisible == 1 && x.isApproved == 0).OrderBy(x => x.User.first_name).ThenBy(x => x.User.middle_name).ThenBy(x => x.User.last_name).ThenBy(x => x.id);
            ViewBag.paperCount = _paper.Count();

            return View(_paper);
        }

        public PartialViewResult MorePapers(object sender)
        {
            return PartialView(sender);
        }

        [Authorize(Roles = "Moderator, Admin")]
        public JsonResult Paper_Approve(int id)
        {
            aztuKonfransEntities konfEntities = new aztuKonfransEntities();
            var _paper = konfEntities.Papers.FirstOrDefault(x => x.id == id);
            _paper.isApproved = 1;
            konfEntities.SaveChanges();

            var _us = _paper.User;
            string subject = "ICEST " + Resources.Resource.paper_approve;
            string body = Resources.Resource.dear + ", " + _us.first_name + " " + _us.last_name + "!<br>&quot;" + _paper.title + "&quot; " + Resources.Resource.paper_approved_text;
            Classes.EMail.SendMail(_us.email, subject, body);



            return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Moderator, Admin")]
        public JsonResult Paper_DApprove(int id)
        {
            aztuKonfransEntities konfEntities = new aztuKonfransEntities();
            var _paper = konfEntities.Papers.FirstOrDefault(x => x.id == id);
            _paper.isApproved = 0;
            konfEntities.SaveChanges();
            return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            if (Classes.PaperDeadline.deadlineValue >= 0 || User.IsInRole("Admin"))
            {
                aztuKonfransEntities konfEntities = new aztuKonfransEntities();
                var paper = konfEntities.Papers.FirstOrDefault(x => x.id == id);

                if ((paper.User.email == User.Identity.Name && paper.isApproved == 0 && paper.isVisible == 1) || User.IsInRole("Admin"))
                    return View(paper);
            }

            return RedirectToAction("Index", "Error");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeletePaper()
        {
            Models.aztuKonfransEntities konfEntities = new Models.aztuKonfransEntities();
            ViewBag.PaperType = 3;

            var _paper = konfEntities.Papers.Where(x => x.isVisible == 1).OrderBy(x => x.User.first_name).ThenBy(x => x.User.middle_name).ThenBy(x => x.User.last_name).ThenBy(x => x.id);

            ViewBag.paperCount = _paper.Count();

            return View("NonApprovedPapers", _paper);
        }

        [Authorize(Roles = "Admin")]
        public JsonResult RemovePaper(int id)
        {
            aztuKonfransEntities konfEntities = new aztuKonfransEntities();

            var _paper = konfEntities.Papers.FirstOrDefault(x => x.id == id);
            _paper.isVisible = 0;
            konfEntities.SaveChanges();
            return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin")]
        public JsonResult UndoPaper(int id)
        {
            aztuKonfransEntities konfEntities = new aztuKonfransEntities();

            var _paper = konfEntities.Papers.FirstOrDefault(x => x.id == id);
            _paper.isVisible = 1;
            konfEntities.SaveChanges();
            return Json(new { res = "1" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Moderator, Admin")]
        public ActionResult SearchedPaperResult(int page, string id, byte type)
        {
            ViewBag.PageId = page;
            ViewBag.PaperType = type;
            ViewBag.SearchedItem = id;
            id = id.ToLower();

            aztuKonfransEntities konfEntities = new aztuKonfransEntities();
            var _paper = konfEntities.Papers.Where(x => x.User.first_name.ToLower().Contains(id) || x.User.middle_name.ToLower().Contains(id) || x.User.last_name.ToLower().Contains(id) || x.title.ToLower().Contains(id));

            var _p = konfEntities.Papers.Select(x => x.Paper_Author.Where(k => k.Author.isVisible == 1 && k.Author.full_name.Contains(id))).Where(x => x.Count() > 0);


            var s = _paper.ToList();



            foreach (var item in _p)
            {
                foreach (var i in item)
                {
                    if (s.FirstOrDefault(x => x.id == i.paper_id) == null)
                        s.Add(i.Paper);
                }
            }

            IEnumerable<Paper> l = s.Where(x => x.isVisible == 1);

            if (type == 0)
                l = l.Where(x => x.isApproved == type);

            if (l.Count() > 0)
            {

                double maxPage = (double)l.Count() / 10;
                if (maxPage % 1 > 0)
                {
                    maxPage++;
                }

                ViewBag.MaxPage = (int)maxPage;

                if (type == 0 || type == 3)
                {
                    l = l.OrderBy(x => x.User.first_name).ThenBy(x => x.User.middle_name).ThenBy(x => x.User.last_name).ThenBy(x => x.id);
                    ViewBag.paperCount = l.Count();
                    return View("NonApprovedPapers", l.AsQueryable());
                }

                return View("AllPapers", l.Skip((page - 1) * 10).Take(10).ToList());
            }
            return View("AllPapers", new List<Models.Paper>());
        }
    }
}