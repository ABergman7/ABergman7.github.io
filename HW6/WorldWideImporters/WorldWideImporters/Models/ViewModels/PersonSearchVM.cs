      
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace WorldWideImporters.Models.ViewModels
{
    /// <summary>
    /// Makes an overall viewmodel for all of the data that I will need
    /// </summary>
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
}