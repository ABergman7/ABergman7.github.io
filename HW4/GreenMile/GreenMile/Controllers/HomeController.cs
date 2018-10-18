using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace GreenMile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            string mileIn = Request.QueryString["mile"];
            string selectedMeasure = Request.QueryString["measure"];

            if (mileIn != null)
            {
                double result = 0;
                double mile = Convert.ToDouble(mileIn);


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

                ViewBag.Answer = "The conversion from "+mileIn+ " mile(s) to " + selectedMeasure + "s is:" + Convert.ToString(result)+" " +selectedMeasure+"s";
            }
            return View();

        }
    }
}