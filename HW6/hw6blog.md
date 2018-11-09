---
title: Homework 6
layout: default
---
# Software Engineering Homework

## Homework 6

For this homework we were tasked with making an MVC 5 web application using a relational database. With 2 features.

1. [Assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW6_1819.html)
2. [Repository](https://github.com/ABergman7/ABergman7.github.io/tree/master/HW6/WorldWideImporters) 

3. [Video](https://youtu.be/CdD9A6Hhw1Y)


## Setup

For setting up the database we were given a backup image of a pre-existing data that we had to restore in Sql Server Management Studios. After restoring the database, we then imported the database into Visual Studios to generate models from.

Here is a picture of the models that were generated:

![Pictures](/Hw6/Pictures/Models.png)

After generating the models, it was obvious that we were going to need to make our own model that was going to use only the data we needed to send to the view. Below is the ViewModels that that I wrote to use all of the data:

```csharp
 public class PersonSearchVM
    {
        // Data needed from Person.cs
        public string Name { get; set; }
        public string Alias { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNum { get; set; }
        public string EmailAdd { get; set; }
        public DateTime ValidFrom { get; set; }
        public byte [] Photo { get; set; }


        //Computation for purchases
        public double Orders { get; set; }
        public decimal Profits { get; set; }
        public decimal Sales { get; set; }

        //From Company
        public string CompanyName { get; set; }
        public string CompPhoneNumber { get; set; }
        public string CompFaxNumber { get; set; }
        public string Website { get; set; }
        public DateTime CompValidFrom { get; set; }

        public DbGeography DeliveryLocation { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public IEnumerable<ItemSearchVM> Items { get; set; }
    }

```
The PersonSearch view model was made as an overall place holder for just the data that I needed to generate information about an individual person. On top of the individual elements, the person would have to hold a list of the top 10 items that they purchase. Thus, an items view model had to be made and passed into the person view model.

## Controllers and Computation

For this assignment we were only coding to one view, in this case I just re-wrote the home controller and view. For the first feature, we had to return a table of people that have an name that contains the string that is being searched. Here is the code that I used for the first feature:

```csharp
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
```

As for the second feature we had to setup a different page, in this case I used details, that would return specific information about someone after their name has been clicked from the table. I'm not going to post the entire action method, but I will post one of the Linq queiries that I used for finding data related to a specific individual. In this case here is a query of finding a sales representative associated with a customer.

```csharp
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

```

Upon finishing the assignment We had to make a table of the top 10 items that the person bought. For future refrence to myself, I wanted to post the foreach loop that I wrote in razor to help generate the table:

```html
 <tbody>
     @if (Model.FirstOrDefault().Items != null)
     {
         foreach(var item in Model.FirstOrDefault().Items)
         {
             <tr>
                 <td>@item.StockItemID</td>
                 <td>@item.ItemDescription</td>
                 <td>@{string LineProfit = string.Format("{0:C2}", item.LineProfit);} @LineProfit</td>
                 <td>@item.SalesPerson</td>
            </tr>
        }
    }
</tbody>
```


## Video
<video width="1000" height="666" controls="controls">
</video>
