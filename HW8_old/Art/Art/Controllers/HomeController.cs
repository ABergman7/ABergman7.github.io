using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Art.Models;

namespace Art.Controllers
{
    public class HomeController : Controller
    {
        private ArtContext db = new ArtContext();



        public ActionResult Index()
        {
           
            return View(db.Genres.ToList());
        }

        public JsonResult GenreResult(int id)
        {
            var artwork = db.Genres.Where(g => g.GENREID == id).Select(c => c.Classes).FirstOrDefault()
                .Select(a => new {a.ArtWork.ARTWORKTITLE, a.ArtWork.Artist.ARTISTNAME})
                .OrderByDescending(a => a.ARTWORKTITLE).ToList();

            return Json(artwork,JsonRequestBehavior.AllowGet);

        }

    }
}