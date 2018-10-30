namespace CampusApartments.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
