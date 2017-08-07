using Portfolio.DAL;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HomeBlogPart()
        {
            return PartialView("_HomeBlogPart", ListBlogPostForHome());
        }
        private List<BlogPostModels> ListBlogPostForHome()
        {
            List<BlogPostModels> result = new List<BlogPostModels>();
            using(DataBaseContext db = new DataBaseContext())
            {
                result = db.BlogPost.OrderByDescending(m => m.date).Take(2).ToList();
            }
            return result;
        }

        public PartialViewResult HomeGaleryPart()
        {
            return PartialView("_HomeGaleryPart", ListGaleryPostForHome());
        }
        private List<GaleryPostModels> ListGaleryPostForHome()
        {
            List<GaleryPostModels> result = new List<GaleryPostModels>();

            using(DataBaseContext db = new DataBaseContext())
            {
                result = db.GaleryPost.OrderByDescending(m => m.date).Take(3).ToList();
            }

            return result;
        }

        public PartialViewResult HomeSM()
        {
            return PartialView("_HomeSM", HomePageSMList());
        }
        private List<SmModels> HomePageSMList()
        {
            List<SmModels> result = new List<SmModels>();
            using(DataBaseContext db = new DataBaseContext())
            {
                result = db.Sm.Where(m => m.onHomePage && m.active).ToList();
            }
            return result;
        }
    }
}