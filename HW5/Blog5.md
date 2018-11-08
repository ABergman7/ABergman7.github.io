---
title: Homework 5
layout: default
---

# Software Engineering Homework
## Homework 5



For this Homework assignment we were tasked with creating a MVC 5 web application with two features using a simple One table database. 

1. [Assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW5_1819.html)
2. [Repo](https://github.com/ABergman7/ABergman7.github.io/tree/master/HW5)

 <iframe width="560" height="315" src="(https://youtu.be/EWqsBhqKzus" frameborder="0" gesture="media" allow="encrypted-media" allowfullscreen></iframe>

## Database and model 

I've been a volunteer DBA for the state for almost 2 years now, so setting up the database was pretty easy. This assignment however was a perspective change for me. I'm so used to working with a database first perspective, and now this assignment really opened my eyes to the code first perspective. Here are code snippets of the model and then the data base up.sql:



### Tenant Model
```csharp

    public class Tenant
    { 
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(64),Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Unit Number")]
        public int UnitNumber { get; set; }

        [Required]
        [StringLength(40), Display(Name = "Apartment Name")]
        public string AptName { get; set; }

        [Required]
        [StringLength(1000), Display(Name = "Issue")]
        public string Reason { get; set; }

        [Display(Name = "Contact Number")]
        public long PhonNum { get; set; }

        [Display(Name = "Allow RA to enter room")]
        public bool Permission { get; set; }

        public DateTime DateReq { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {UnitNumber} {AptName} {Reason} {PhonNum} {Permission} DateReq = {DateReq}";
        }
    }
}

```

### Tenants database

```sql

CREATE TABLE [dbo].[Tenants]
(
	[ID]		 INT IDENTITY (1,1)  NOT NULL,
	[FirstName]  NVARCHAR(64)		 NOT NULL,
	[LastName]   NVARCHAR(128)		 NOT NULL,
	[UnitNumber] INT				 NOT NULL,
	[AptName]	 NVARCHAR(40)		 NOT NULL,
	[Reason]	 NVARCHAR(1000)		 NOT NULL,
	[PhonNum]	 BIGINT			     NOT NULL,
	[Permission] BIT				 NOT NULL,
	[DateReq]	 DATETIME			 NOT NULL,

	CONSTRAINT [PK_dbo.Tenants] PRIMARY KEY CLUSTERED ([ID] ASC)

);

INSERT INTO [dbo].[Tenants] (FirstName, LastName, UnitNumber, AptName, Reason, PhonNum, Permission, DateReq) VALUES
('Jim','Johnson','317','Bobs Apartments','Broken Toilet', '5552228888', '1', '2018-10-24  12:45:23'),
('Bill','Williams','215','Bobs Apartments','Broken Window', '5552334444', '0', '2018-08-12  12:45:23'),
('John','Johnson','318','Bobs Apartments','Broken Toilet', '5552228888', '1', '2018-05-12  12:45:23')

GO


```

Like I said it was a bit of a perspective shift from a datafirst to code first. After I made my data types for the data base I eventually went back and fixed the data types for the model to make sure that the matched the database.

## Data Access 

To be able to allow the model to communicate with the database we had to add a Data Access Layer (DAL) folder, and add a connection string to to the specific database server's name. (Note that the database and server dont have the same name)

### TenantsContext (DAL)

```csharp
using CampusApartments.Models;

namespace CampusApartments.DAL
{
    public class TenantContext : DbContext 
    {
        public TenantContext() : base("name=TenantDB")
        {
          
        }
        public virtual DbSet<Tenant> Tenants { get; set; }
    }
}
```

### Connection String to Server

```xml
  <connectionStrings>
    <add name="TenantDB" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\theau\Desktop\HW460\ABergman7.github.io\HW5\CampusApartments\CampusApartments\App_Data\TenantDB.mdf;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>

```

One thing that I regretted, but I learned from my mistake, was naming the server TenantDB when it was not a DB. Later on I will stick with nameing my servers differently to prevent any confusion.

## Views 

To scaffold a view from the model and the DAL was really nifty. However, the almost gave a bit too much than what I needed, and didn't allow for the Issue text box to be any bigger. So I gutted the excess .cshtml files like edit, details. I did leave delete since, from my perspective, the resident assistance was using the data from the database like a queue, so I wanted them to be able to "pop" from the queue. One thing that is really important to talk about here is the views are STRONGLY TYPED. This allowed us to treate the views like functionally programmed file, and since we are passing information back and forth to the model the strongly typed views allow very little room for failure. This also allowed us use Lambda functions, for example here is a display from the Index.cshtml file of Tenants: 

```csharp
@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.FirstName)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.LastName)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.UnitNumber)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.AptName)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Reason)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.PhonNum)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Permission)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.DateReq)
        </td>
        <td>
            @Html.ActionLink("Delete", "Delete", new { id=item.ID })
        </td>
    </tr>
}
```
With Razor syntax, we were able to assign a lambda function, in this case modelItem, to display the data currently in the items in the Tenant model. It's also nice to use lambda functions to create what we wanted on one line. Had we handled this view with an object-Oriented perspective the amount of functions to write for each item would be pain-staking. 

## Closing Thought

I enjoyed this lab, simply because I have always had the perspective of a DBA. The perspective shift from a DBA to a full stack developer was almost a 180 degree change for me. I have always handled things from a data first perspective, so the code first perspective was a big time eye-opener. 
