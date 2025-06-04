using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRMApp.Data
{
    internal class MiniCRMContext : DbContext
    {
        // Constructor using connection string name from config
        public MiniCRMContext() : base("name=MiniCRMConnectionString")
        {
        }

        // DbSet properties for your entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any custom model configurations here
        }
    }
}
