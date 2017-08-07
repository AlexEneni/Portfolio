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
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View(BlogPostList());
        }
        private List<BlogPostModels> BlogPostList()
        {
            List<BlogPostModels> result = new List<BlogPostModels>();
            using(DataBaseContext db = new DataBaseContext())
            {
                result = db.BlogPost.OrderByDescending(m => m.date).ToList();
            }
            return result;
        }
    }
}