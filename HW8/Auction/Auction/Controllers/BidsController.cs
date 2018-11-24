using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction.DAL;

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

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ITEMID,BIDID,PRICE,BUYERID,TIMESTAMP")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.BUYERID = new SelectList(db.Buyers, "BUYERID", "BUYERNAME", bid.BUYERID);
            ViewBag.ITEMID = new SelectList(db.Items, "ITEMID", "ITEMNAME", bid.ITEMID);
            return View(bid);
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
