using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace GreenMile.Controllers
{
    /// <summary>
    /// Controller for Index.cshtml and Controler.cshtml
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// View for Homepage 
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// HTTP GET conversion from mile to metric
        /// </summary>
        /// <returns>Metric Conversion</returns>
        [HttpGet]
        public ActionResult Converter()
        {
            string mileIn = Request.QueryString["mile"];
            string selectedMeasure = Request.QueryString["measure"];

            //Check for bad input 
            if (mileIn != null)
            {
                double result = 0;
                double mile = Convert.ToDouble(mileIn);

                //Check for which radio button was selected
                switch (selectedMeasure)
                {
                    case "Millimeter":
                        result = mile * 1609344;
                        break;
                    case "Centimeter":
                        result = mile * 160934;
                        break;
                    case "Meter":
                        result = mile * 1609.34;
                        break;
                    case "Kilometer":
                        result = mile * 1.60934;
                        break;
                }

                Debug.WriteLine(selectedMeasure);
                Debug.WriteLine(result);

                //Fancy string for output
                ViewBag.Answer = "The conversion from "+mileIn+ " mile(s) to " + selectedMeasure + "s is:" + Convert.ToString(result)+" " +selectedMeasure+"s";
            }
            return View();

        }
    }
}