using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    public class SalesTrackerContext : DbContext
    {
        public virtual DbSet<Inventory> Inventory{ get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SalesTracker;integrated security = True");
        }
    }
}
