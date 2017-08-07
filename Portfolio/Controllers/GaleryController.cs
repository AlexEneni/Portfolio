using Portfolio.DAL;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        public ActionResult Index()
        {
            return View(GaleryList());
        }
        private List<GaleryPostModels> GaleryList()
        {
            List<GaleryPostModels> result = new List<GaleryPostModels>();

            using(DataBaseContext db = new DataBaseContext())
            {
                result = db.GaleryPost.OrderByDescending(m => m.date).ToList();
            }
            return result;
        }
    }
}