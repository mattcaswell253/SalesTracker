using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventorySales",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false),
                    SaleId = table.Column<int>(nullable: false),
                    InventoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventorySales", x => new { x.InventoryId, x.SaleId });
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(nullable: true),
                    InventoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    CommentId = table.Column<int>(nullable: false),
                    SaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Comments_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InventoryId = table.Column<int>(nullable: false),
                    Price = table.Column<string>(nullable: true),
                    SaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Inventory_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SaleId",
                table: "Comments",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_SaleId",
                table: "Inventory",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_InventorySales_InventoryName",
                table: "InventorySales",
                column: "InventoryName");

            migrationBuilder.CreateIndex(
                name: "IX_InventorySales_SaleId",
                table: "InventorySales",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_InventoryName",
                table: "Sales",
                column: "InventoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_InventorySales_Sales_SaleId",
                table: "InventorySales",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventorySales_Inventory_InventoryName",
                table: "InventorySales",
                column: "InventoryName",
                principalTable: "Inventory",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Inventory_InventoryName",
                table: "Sales",
                column: "InventoryName",
                principalTable: "Inventory",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Sales_SaleId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "InventorySales");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
