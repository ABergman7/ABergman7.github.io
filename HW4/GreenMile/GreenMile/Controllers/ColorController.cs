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


        // POST: Color
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


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