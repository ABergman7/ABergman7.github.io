using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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