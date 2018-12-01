using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Art.Models;

namespace Art.Controllers
{
    public class ClassesController : Controller
    {
        private ArtContext db = new ArtContext();

        // GET: Classes
        public ActionResult Index()
        {
            var classes = db.Classes.Include(C => C.ArtWork).Include(C => C.Genre);
            return View(classes.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
