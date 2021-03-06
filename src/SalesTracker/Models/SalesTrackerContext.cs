﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    public class SalesTrackerContext : IdentityDbContext<User>
    {
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<InventorySale> InventorySales { get; set; }
        public SalesTrackerContext(DbContextOptions options) : base(options)
        {
        }        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SalesTracker;integrated security = True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<InventorySale>().HasKey(x => new { x.InventoryId, x.SaleId });
        }
    }
}
