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
        // GET: TenantContext
        public TenantContext() : base("name=Tenant")
        {
          
        }
        public virtual DbSet<Tenant> Tenants { get; set; }
    }
}