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
            Color colorOne;
            Color colorTwo;
            
                colorOne = (Color)ColorConverter.ConvertFromString(ColorOne);
                colorTwo = (Color)ColorConverter.ConvertFromString(ColorTwo);
            
            Debug.WriteLine(colorOne);
            Debug.WriteLine(colorTwo);
            Color newColor = Color.Add(colorOne,colorTwo);


            Debug.WriteLine(newColor);

            ViewBag.NewColor = newColor;
            ViewBag.ColorA = colorOne;
            ViewBag.ColorB = colorTwo;
           
            return View();


        }
    }
}