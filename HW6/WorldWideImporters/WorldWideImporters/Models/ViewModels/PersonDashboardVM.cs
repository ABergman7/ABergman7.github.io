using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldWideImporters.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorldWideImporters.Models.ViewModels
{
    public class PersonDashboardVM
    {
        public string Name { get; set; }
        public IEnumerable<PersonSearchVM> PersonResults { get; set; }
    }
}