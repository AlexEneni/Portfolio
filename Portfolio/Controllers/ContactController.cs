using Portfolio.DAL;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Form()
        {
            return PartialView("_ContactForm");
        }

        [HttpPost]
        public ActionResult Form(Message dane)
        {
            if(ModelState.IsValid)
            {
                using(DataBaseContext db = new DataBaseContext())
                {
                    dane.wasDisplayed = false;
                    dane.dateOfSend = DateTime.Now;
                    db.Messages.Add(dane);
                    db.SaveChanges();
                }
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View("Index", dane);
            }

        }

        public PartialViewResult RightBarContact()
        {
            return PartialView("_RightBarContact");
        }

        public PartialViewResult ContactOnBar()
        {
            return PartialView("_ContactOnBar", ContactList());
        }
        private List<ContactSMModels> ContactList()
        {
            List<ContactSMModels> result = new List<ContactSMModels>();
            using (DataBaseContext db = new DataBaseContext())
            {
                result = db.Contact.Where(m => m.active).ToList();
            }
            return result;
        }

        public PartialViewResult SMOnBar()
        {
            return PartialView("_SMOnBar", SMList());
        }
        private List<SmModels> SMList()
        {
            List<SmModels> result = new List<SmModels>();
            using (DataBaseContext db = new DataBaseContext())
            {
                result = db.Sm.Where(m => m.active).ToList();
            }
            return result;
        }
    }
}