using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MileToMetricController : Controller
    {
        // GET: MileToMetric
            [HttpGet]
            [ActionName("Page 1")]
        public ActionResult Converter()
        {
            double measure = Convert.ToDouble(Request.Form["measure"]);
            
            if 


            return View();
        }
    }
}