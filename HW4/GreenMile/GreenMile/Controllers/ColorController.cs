using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Media;

namespace GreenMile.Controllers
{
    public class ColorController : Controller
    {

        /// <summary>
        /// The HTTP Get ActionResult for the Create page
        /// </summary>
        /// <returns>view for Create.cshtml</returns>
        // GET: Color
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// After POST take color strings from form and convert to color for addition
        /// </summary>
        /// <param name="ColorOne"></param>
        /// <param name="ColorTwo"></param>
        /// <returns>View with new color plus first and second color</returns>
        [HttpPost]
        public ActionResult Create(string ColorOne, string ColorTwo)
        {
            Color colorOne = (Color)ColorConverter.ConvertFromString(ColorOne);
            Color colorTwo = (Color)ColorConverter.ConvertFromString(ColorTwo);

            Debug.WriteLine(colorOne);
            Debug.WriteLine(colorTwo);

            //Add the two colors
            Color newColor = Color.Add(colorOne,colorTwo);


            Debug.WriteLine(newColor);

            //Return all three colors in their own ViewBag
            ViewBag.NewColor = newColor;
            ViewBag.ColorA = colorOne;
            ViewBag.ColorB = colorTwo;
           
            return View();


        }
    }
}