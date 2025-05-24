using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerlessMarketplace.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FixingOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_OwnerId",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_OwnerId",
                table: "Customers",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_OwnerId",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_OwnerId",
                table: "Customers",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
