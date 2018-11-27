using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using Auction.Models;
using System.Diagnostics;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        public AuctionContext db = new AuctionContext();

        public ActionResult Index()
        {
            return View(db.Bids.OrderByDescending(x => x.Timestamp).Take(10).ToList());
        }

    }
}