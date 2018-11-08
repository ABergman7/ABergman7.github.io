using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldWideImporters.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorldWideImporters.Models.ViewModels
{
    /// <summary>
    /// Place holder for an Enumerable PersonSearch
    /// Had issues for unknown reason that wouldn't allow index to accept other viewmodels
    /// </summary>
    public class PersonDashboardVM
    {
        public string Name { get; set; }

        public IEnumerable<PersonSearchVM> PersonResults { get; set; }
    }
}