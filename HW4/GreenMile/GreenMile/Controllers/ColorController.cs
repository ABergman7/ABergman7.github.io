using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
namespace GreenMile.Controllers
{
    public class ColorController : Controller
    {
        // POST: Color

        [HttpPost]
        public ActionResult Create(string ColorOne, string ColorTwo)
        {
            return View();
        }
    }
}