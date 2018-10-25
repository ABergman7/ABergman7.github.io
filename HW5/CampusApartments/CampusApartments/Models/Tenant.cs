using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CampusApartments.Models
{
    public class Tenant
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Current Date of Request")]
        public DateTime DateReq { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public int PhoneNum { get; set; }

        [Required]
        [Display(Name = "Reason for Request")]
        public string Reason { get; set; }

        [Display(Name = "Select here to give permission for the landlord or representative to enter your unit to perform the requested maintenance. We will call first")]
        public bool Permission { get; set; }


        public override string ToString()
        {
            return $"{base.ToString()} : {FirstName} {LastName} DateReq = {DateReq} PhoneNum = {PhoneNum}";
        }
    }

}