using Portfolio.DAL;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        #region MainPage
        
        public ActionResult Index()
        {
            return View();
        }

        #endregion
        #region HomePage
        
        public ActionResult HomeSetting()
        {
            return View();
        }
        public PartialViewResult SocialMedia()
        {
            return PartialView("_SMSettings", ListOfSM());
        }
        private List<SmModels> ListOfSM()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.Sm.ToList();
            }
        }
        
        public ActionResult EditSM(int id = 0)
        {
            if (id == 0) return RedirectToAction("HomeSetting");
            var temp = new SmModels();
            using (DataBaseContext db = new DataBaseContext())
            {
                temp = db.Sm.FirstOrDefault(m => m.ID == id);
            }
            return View(temp);
        }
        [HttpPost]
        
        public ActionResult SMSave(SmModels model)
        {
            if (ModelState.IsValid && model != null)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var temp = db.Sm.FirstOrDefault(m => m.ID == model.ID);
                    temp.active = model.active;
                    temp.url = model.url;
                    temp.onHomePage = model.onHomePage;
                    temp.Name = model.Name;
                    db.SaveChanges();
                }
                return RedirectToAction("HomeSetting");
            }
            else
            {
                return RedirectToAction("EditSM", new { id = model.ID });
            }
        }

        public PartialViewResult Contact()
        {
            return PartialView("_ContactSettings", ListOfContact());
        }
        private List<ContactSMModels> ListOfContact()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.Contact.ToList();
            }
        }
        
        public ActionResult EditContact(int id = 0)
        {
            if (id == 0) return RedirectToAction("HomeSetting");
            var temp = new ContactSMModels();
            using (DataBaseContext db = new DataBaseContext())
            {
                temp = db.Contact.FirstOrDefault(m => m.Id == id);
            }
            return View(temp);
        }
        public ActionResult ContactSave(ContactSMModels model)
        {
            if (ModelState.IsValid && model != null)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var temp = db.Contact.FirstOrDefault(m => m.Id == model.Id);
                    temp.active = model.active;
                    temp.value = model.value;
                    temp.symbol = model.symbol;
                    temp.Name = model.Name;
                    db.SaveChanges();
                }
                return RedirectToAction("HomeSetting");
            }
            else
            {
                return RedirectToAction("EditContact", new { id = model.Id });
            }
        }
        
        public ActionResult HomeContent()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult HomeContentDesc(string desc)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(Server.MapPath("~/Resources/desc.txt")))
                {
                    sr.Write(desc);
                    return RedirectToAction("HomeContent");
                }
            }
            catch
            {
                return RedirectToAction("HomeContent");
            }
        }
        [HttpPost]
        
        public ActionResult HomeContentName(string name)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(Server.MapPath("~/Resources/name.txt")))
                {
                    sr.Write(name);
                    return RedirectToAction("HomeContent");
                }
            }
            catch
            {
                return RedirectToAction("HomeContent");
            }
        }
        [HttpPost]
        
        [ValidateInput(false)]
        public ActionResult HomeContentSubDesc(string subdesc, int id = 0)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(Server.MapPath($"~/Resources/subDesc{id}.txt")))
                {
                    sr.Write(subdesc);
                    return RedirectToAction("HomeContent");
                }
            }
            catch
            {
                return RedirectToAction("HomeContent");
            }
        }
        #endregion
        #region Contact
        
        public ActionResult ContactContent()
        {
            return View();
        }
        
        public ActionResult MessageList(int id = 0)
        {
            if (id == 0)
            {
                return View(GetMessageList());
            }
            else
            {
                return View("MessageView", GetMessage(id));
            }
        }
        private List<Message> GetMessageList()
        {
            List<Message> result = new List<Message>();
            using (DataBaseContext db = new DataBaseContext())
            {
                result = db.Messages.ToList();
            }
            return result;
        }
        private Message GetMessage(int x)
        {
            Message result = new Message();
            using (DataBaseContext db = new DataBaseContext())
            {
                result = db.Messages.FirstOrDefault(m => m.ID == x);
            }
            return result;
        }

        public void SetDisplayed(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var result = db.Messages.FirstOrDefault(m => m.ID == id);
                result.wasDisplayed = true;
                db.SaveChanges();
            }
        }
        
        public ActionResult MessageDelete(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                db.Messages.Remove(db.Messages.FirstOrDefault(m => m.ID == id));
                db.SaveChanges();
            }
            return RedirectToAction("MessageList");
        }

        #endregion
        #region Galery
        
        public ActionResult GaleryArtList()
        {
            return View();
        }
        public PartialViewResult GaleryArtListList()
        {

            return PartialView("_GaleryArtListList", GetGaleryArtList());
        }
        private List<GaleryPostModels> GetGaleryArtList()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.GaleryPost.ToList();
            }
        }
        
        public ActionResult EditGaleryArt(int id = 0)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                if (!db.GaleryPost.Where(m => m.ID == id).Any())
                {
                    return RedirectToAction("GaleryArtList");
                }
                return View(db.GaleryPost.FirstOrDefault(m => m.ID == id));
            }
        }
        
        public ActionResult EditGaleryArtForm(GaleryPostModels model, string txt, string imgLocalPath)
        {
            if (ModelState.IsValid)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var temp = db.GaleryPost.FirstOrDefault(m => m.ID == model.ID);
                    temp.title = model.title;
                    db.SaveChanges();
                }
                try
                {
                    using (StreamWriter sr = new StreamWriter(model.descUrl))
                    {
                        sr.Write(txt);
                    }

                }
                catch
                {
                    return RedirectToAction("EditGaleryArt", new { id = model.ID });
                }
                /* code -> file reupload */
                return RedirectToAction("GaleryArtList");
            }
            else
            {
                return RedirectToAction("EditGaleryArt", new { id = model.ID });
            }
        }
        
        public ActionResult GaleryArtDelete(int id = 0)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                if (!db.GaleryPost.Where(m => m.ID == id).Any())
                {
                    return RedirectToAction("GaleryArtList");
                }
                return View(db.GaleryPost.FirstOrDefault(m => m.ID == id));
            }
        }
        [HttpPost]
        
        public ActionResult GaleryArtDeleteForm(GaleryPostModels model)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var temp = db.GaleryPost.FirstOrDefault(m => m.ID == model.ID);
                model = temp;
                db.GaleryPost.Remove(temp);
                db.SaveChanges();
            }
            if (System.IO.File.Exists(@"" + model.descUrl))
            {

                FileInfo f = new FileInfo(model.descUrl);
                try
                {
                    f.Delete();
                }
                catch
                {
                    //error message
                    //ViewBag.error = "";
                }
            }
            /* code -> delete img */
            return RedirectToAction("GaleryArtList");
        }
        
        public ActionResult GaleryArtCreate()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult GaleryArtCreate(GaleryPostModels model, string txt, HttpPostedFileBase imgLocal)
        {



            /* code -> upload img from imgLocalPath to model.imageUrl
             * and add file */
            try
            {
                model.imageUrl = Server.MapPath("~/Resources/images/");
                if (imgLocal.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(imgLocal.FileName);
                    string _path = model.imageUrl + _FileName;
                    imgLocal.SaveAs(_path);
                }
                using (DataBaseContext db = new DataBaseContext())
                {
                    var temp = new GaleryPostModels();
                    temp.title = model.title;
                    temp.date = DateTime.Now;
                    temp.descUrl = Server.MapPath("~/Resources/images/") +
                        $"{temp.date.Year}{temp.date.DayOfYear}" +
                        $"{temp.date.Second}{temp.date.Minute}{temp.date.Hour}.txt";
                    temp.imageUrl = model.imageUrl;

                    db.GaleryPost.Add(temp);
                    db.SaveChanges();
                    model.descUrl = temp.descUrl;
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                using (StreamWriter sr = new StreamWriter(model.descUrl))
                {
                    sr.Write(txt);
                }
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }

            return RedirectToAction("GaleryArtList");
        }
        #endregion
        #region Blog
        
        public ActionResult BlogPostList()
        {
            return View();
        }
        public PartialViewResult BlogPostListList()
        {
            return PartialView("_BlogPostListList", GetBlogPostList());
        }
        private List<BlogPostModels> GetBlogPostList()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.BlogPost.ToList();
            }
        }
        
        public ActionResult EditBlogPost(int id = 0)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                if (!db.BlogPost.Where(m => m.ID == id).Any())
                {
                    return RedirectToAction("BlogPostList");
                }
                return View(db.BlogPost.FirstOrDefault(m => m.ID == id));
            }
        }
        [HttpPost]
        
        [ValidateInput(false)]
        public ActionResult BlogPostForm(BlogPostModels model, string txt = "")
        {
            if (ModelState.IsValid)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var temp = db.BlogPost.FirstOrDefault(m => m.ID == model.ID);
                    temp.author = model.author;
                    temp.Title = model.Title;
                    db.SaveChanges();
                }
                try
                {
                    using (StreamWriter sr = new StreamWriter(model.textFileUrl))
                    {
                        sr.Write(txt);
                    }

                }
                catch
                {
                    return RedirectToAction("EditBlogPost", new { id = model.ID });
                }
                return RedirectToAction("BlogPostList");
            }
            else
            {
                return RedirectToAction("EditBlogPost", new { id = model.ID });
            }
        }
        
        public ActionResult BlogPostCreate()
        {
            return View();
        }
        [HttpPost]
        
        [ValidateInput(false)]
        public ActionResult BlogPostCreateForm(BlogPostModels model, string txt = "")
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var temp = new BlogPostModels();
                temp.author = model.author;
                temp.Title = model.Title;
                temp.date = DateTime.Now;
                temp.textFileUrl = Server.MapPath("~/Resources/") +
                    $"{temp.date.Year}{temp.date.DayOfYear}" +
                    $"{temp.date.Second}{temp.date.Minute}{temp.date.Hour}.txt";
                db.BlogPost.Add(temp);
                db.SaveChanges();
                model.textFileUrl = temp.textFileUrl;
            }

            using (StreamWriter sr = new StreamWriter(model.textFileUrl))
            {
                sr.Write(txt);
            }

            return RedirectToAction("BlogPostList");

        }
        
        public ActionResult BlogPostDelete(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                if (!db.BlogPost.Where(m => m.ID == id).Any())
                {
                    return RedirectToAction("BlogPostList");
                }
                return View(db.BlogPost.FirstOrDefault(m => m.ID == id));
            }
        }
        [HttpPost]
        
        public ActionResult BlogPostDeleteForm(BlogPostModels model)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var temp = db.BlogPost.FirstOrDefault(m => m.ID == model.ID);
                db.BlogPost.Remove(temp);
                db.SaveChanges();
            }
            if (System.IO.File.Exists(@"C:\Users\Public\DeleteTest\test.txt"))
            {

                FileInfo f = new FileInfo(model.textFileUrl);
                try
                {
                    f.Delete();
                }
                catch
                {
                    //error message
                    //ViewBag.error = "";
                }
            }
            return RedirectToAction("BlogPostList");

        }
        #endregion
    }
}