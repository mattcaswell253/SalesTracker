using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SalesTracker.Models;

namespace SalesTracker.Migrations
{
    [DbContext(typeof(SalesTrackerContext))]
    [Migration("20170503204755_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalesTracker.Models.Comment", b =>
                {
                    b.Property<string>("Title");

                    b.Property<string>("Body");

                    b.Property<int>("CommentId");

                    b.Property<int?>("SaleId");

                    b.HasKey("Title");

                    b.HasIndex("SaleId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SalesTracker.Models.Inventory", b =>
                {
                    b.Property<string>("Name");

                    b.Property<string>("Description");

                    b.Property<int>("InventoryId");

                    b.Property<string>("Price");

                    b.Property<int?>("SaleId");

                    b.HasKey("Name");

                    b.HasIndex("SaleId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("SalesTracker.Models.InventorySale", b =>
                {
                    b.Property<int>("InventoryId");

                    b.Property<int>("SaleId");

                    b.Property<string>("InventoryName");

                    b.HasKey("InventoryId", "SaleId");

                    b.HasIndex("InventoryName");

                    b.HasIndex("SaleId");

                    b.ToTable("InventorySales");
                });

            modelBuilder.Entity("SalesTracker.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerName");

                    b.Property<string>("InventoryName");

                    b.HasKey("SaleId");

                    b.HasIndex("InventoryName");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("SalesTracker.Models.Comment", b =>
                {
                    b.HasOne("SalesTracker.Models.Sale", "Sale")
                        .WithMany("Comments")
                        .HasForeignKey("SaleId");
                });

            modelBuilder.Entity("SalesTracker.Models.Inventory", b =>
                {
                    b.HasOne("SalesTracker.Models.Sale")
                        .WithMany("Inventories")
                        .HasForeignKey("SaleId");
                });

            modelBuilder.Entity("SalesTracker.Models.InventorySale", b =>
                {
                    b.HasOne("SalesTracker.Models.Inventory", "Inventory")
                        .WithMany("InventorySales")
                        .HasForeignKey("InventoryName");

                    b.HasOne("SalesTracker.Models.Sale", "Sale")
                        .WithMany("InventorySales")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalesTracker.Models.Sale", b =>
                {
                    b.HasOne("SalesTracker.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryName");
                });
        }
    }
}
