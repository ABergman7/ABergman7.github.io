using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CampusApartments.DAL;
using CampusApartments.Models;

namespace CampusApartments.Controllers
{
    public class TenantsController : Controller
    {
        private TenantContext db = new TenantContext();

        /// <summary>
        /// GET: Tenant
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Tenants.ToList());
        }

        /// <summary>
        /// Get Tenant/Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View of Tenants</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ID,Firstname,LastName,Reason,DateReq,PhoneNum")] Tenant tenant)
        {
            if(ModelState.IsValid)
            {
                db.Tenants.Add(tenant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }

    }

}