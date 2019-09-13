using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("DataConnection")
        {
           
        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Comment>Comments { get; set; }
    }
}