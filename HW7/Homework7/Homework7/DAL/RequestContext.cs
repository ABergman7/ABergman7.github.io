using Homework7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Homework7.DAL
{
    public class RequestContext : DbContext
    {
        public RequestContext() : base("name=RequestsDB")
        { }
        public virtual DbSet<Request> Requests { get; set; }
    }
}