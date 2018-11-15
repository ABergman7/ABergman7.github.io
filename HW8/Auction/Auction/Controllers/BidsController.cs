using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction.Models;

namespace Auction.Controllers
{
    public class BidsController : Controller
    {
        private AuctionContext db = new AuctionContext();

      
        // GET: Bids/Create
        public ActionResult Create()
        {
            ViewBag.BUYERID = new SelectList(db.Buyers, "BUYERID", "BUYERNAME");
            ViewBag.ITEMID = new SelectList(db.Items, "ITEMID", "ITEMNAME");
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
