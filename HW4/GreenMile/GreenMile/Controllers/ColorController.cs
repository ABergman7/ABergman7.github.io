using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;

namespace GreenMile.Controllers
{
    public class ColorController : Controller
    {
    
        
        // POST: Color
        [HttpGet] 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string ColorOne, string ColorTwo)
        {



            Color colorOne = ColorTranslator.FromHtml(ColorOne);
            Color colorTwo = ColorTranslator.FromHtml(ColorTwo);

            Debug.WriteLine(colorOne);
            Debug.WriteLine(colorTwo);



            Color newColor = Color.FromArgb(0,0,0,0);
            
            // Tried using a switch, but didn't like the boolean comparison. 

            if ((colorOne.A + colorTwo.A) > 255)
            {
                newColor.A.Equals(255);
            }
            else if ((colorOne.R + colorTwo.R) > 255)
            {
                newColor.R.Equals(255);
            }
            else if ((colorOne.G + colorTwo.G) > 255)
            {
                newColor.G.Equals(255);
            }
            else if ((colorOne.B + colorTwo.B) > 255)
            {
                newColor.B.Equals(255);
            }
            else
            {

                newColor = Color.FromArgb((colorOne.A + colorTwo.A), (colorOne.R + colorTwo.R), (colorOne.G + colorTwo.G), (colorOne.B + colorTwo.B));
                Debug.WriteLine(newColor);
                ViewBag.NewColor = newColor; 
            }

            return View();
        }
    }
}