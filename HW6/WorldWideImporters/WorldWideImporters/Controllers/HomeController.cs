using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using WorldWideImporters.DAL;
using System.Web.Mvc;
using WorldWideImporters.Models;
using WorldWideImporters.Models.ViewModels;

namespace WorldWideImporters.Controllers
{
    public class HomeController : Controller
    {
        private WWIContext db = new WWIContext();

        /// <summary>
        /// Base Index page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Reads input from search bar then generates names
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View(model></returns>
        [HttpPost]
        public ActionResult Index(PersonDashboardVM model)
        {

            model.PersonResults = db.People
                .Where(temp => temp.FullName.Contains(model.Name))
                .Select(p => new PersonSearchVM
                {
                    Name = p.FullName,
                    Alias = p.PreferredName,
                }
                ).ToList();


            db.Dispose();
            return View(model);

        }


        /// <summary>
        /// Generatesa detail page about a person
        /// </summary>
        /// <param name="result"></param>
        /// <returns>View(customers)</returns>
        [HttpGet]
        public ActionResult Details(string result)

        {
            List<PersonSearchVM> PersonDetails = db.People
                .Where(p => p.FullName == result)
                .Select(p => new PersonSearchVM
                {
                    Name = p.FullName,
                    Alias = p.PreferredName,
                    PhoneNumber = p.PhoneNumber,
                    FaxNum = p.FaxNumber,
                    EmailAdd = p.EmailAddress,
                    ValidFrom = p.ValidFrom

                }).ToList();

            if (PersonDetails.FirstOrDefault() == null)
            {
                return RedirectToAction("Index");
            }

            var CustomerDetails = db.People
                .Where(p => p.FullName == result)
                .Include("PrimaryContactPersonID")
                .SelectMany(p => p.Customers2).ToList();

            if (CustomerDetails.Count == 0)
            {
                return View(PersonDetails);
            }
            else
            {
                // Query to get itemdetails starting from dbo.People
                // traverse relations to pull out selected information
                var ItemDetails = db.People
                    .Where(p => p.FullName.Contains(result)).Include("PrimaryContactPersonID")
                    .SelectMany(x => x.Customers2).Include("CustomerID")
                    .SelectMany(x => x.Orders).Include("OrderID").Include("CustomerID")
                    .SelectMany(x => x.Invoices).Include("InvoiceID")
                    .SelectMany(x => x.InvoiceLines)
                    .OrderByDescending(x => x.LineProfit).Take(10)
                    .ToList();

                //Query for getting sales person information
                var SalesRepDetails = db.People
                    .Where(p => p.FullName.Contains(result)).Include("PrimaryContactPersonID")
                    .SelectMany(x => x.Customers2).Include("CustomerID")
                    .SelectMany(x => x.Orders).Include("OrderID").Include("CustomerID")
                    .SelectMany(x => x.Invoices).Include("InvoiceID")
                    .SelectMany(x => x.InvoiceLines)
                    .OrderByDescending(x => x.LineProfit).Take(10)
                    .Include("InvoiceID")
                    .Select(x => x.Invoice).Include("SalespersonID")
                    .Select(x => x.Person4).ToList();

                //Create Items list
                List<ItemSearchVM> Items = new List<ItemSearchVM>();



                {
                    //add to Items list
                    for (int i = 0; i < 10; i++)

                    {
                        Items.Add(new ItemSearchVM
                        {
                            StockItemID = ItemDetails.ElementAt(i).StockItemID,
                            ItemDescription = ItemDetails.ElementAt(i).Description,
                            LineProfit = ItemDetails.ElementAt(i).LineProfit,
                            SalesPerson = SalesRepDetails.ElementAt(i).FullName

                        });
                    }
                }

                List<PersonSearchVM> Customers = new List<PersonSearchVM>
                {
                    new PersonSearchVM
                    {
                        //Base details about any person in gerneral
                        Name = PersonDetails.First().Name,
                        Alias = PersonDetails.First().Alias,
                        PhoneNumber = PersonDetails.First().PhoneNumber,
                        FaxNum = PersonDetails.First().FaxNum,
                        EmailAdd = PersonDetails.First().EmailAdd,
                        ValidFrom = PersonDetails.First().ValidFrom,

                        //Company details
                        CompanyName = CustomerDetails.First().CustomerName,
                        CompPhoneNumber = CustomerDetails.First().PhoneNumber,
                        CompFaxNumber = CustomerDetails.First().FaxNumber,
                        Website = CustomerDetails.First().WebsiteURL,
                        CompValidFrom = CustomerDetails.First().ValidFrom,

                        //Previous History of purchases
                        Orders = db.People
                            .Where(p => p.FullName.Contains(result)).Include("PrimaryContactPersonID" )
                            .SelectMany(x => x.Customers2).Include("CustomerID")
                            .SelectMany(x => x.Orders).Count(),
                        // Gross Sales
                        Sales = db.People
                            .Where(p => p.FullName.Contains(result)).Include("PrimaryContactPersonID")
                            .SelectMany(x => x.Customers2).Include("CustomerID")
                            .SelectMany(x => x.Orders).Include("OrderID").Include("CustomerID")
                            .SelectMany(x => x.Invoices).Include("InvoiceID")
                            .SelectMany(x => x.InvoiceLines).Sum(x => x.ExtendedPrice),

                        //Gross profit
                        Profits = db.People
                            .Where(p => p.FullName.Contains(result)).Include("PrimaryContactPersonID")
                            .SelectMany(x => x.Customers2).Include("CustomerID")
                            .SelectMany(x => x.Orders).Include("OrderID").Include("CustomerID")
                            .SelectMany(x => x.Invoices).Include("InvoiceID")
                            .SelectMany(x => x.InvoiceLines).Sum(x => x.LineProfit),

                        Items = Items



                    }

                };

                return View(Customers);

            }


            
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
