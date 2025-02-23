using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerlessMarketplace.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FixingMapps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "Order",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "numeric",
                nullable: false,
                computedColumnSql: "SELECT COALESCE(SUM(oi.Price * oi.Quantity), 0) FROM OrderItems oi WHERE oi.OrderId = Id",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldComputedColumnSql: "SELECT COALESCE(SUM(p.Price), 0) FROM Products p WHERE p.OrderId = Id",
                oldStored: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId1",
                table: "Order",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId1",
                table: "Order",
                column: "CustomerId1",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Order");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "numeric",
                nullable: false,
                computedColumnSql: "SELECT COALESCE(SUM(p.Price), 0) FROM Products p WHERE p.OrderId = Id",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldComputedColumnSql: "SELECT COALESCE(SUM(oi.Price * oi.Quantity), 0) FROM OrderItems oi WHERE oi.OrderId = Id",
                oldStored: true);
        }
    }
}
