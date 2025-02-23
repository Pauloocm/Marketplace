using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerlessMarketplace.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AnotherMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "character varying(210)",
                maxLength: 210,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(210)",
                oldMaxLength: 210);
        }
    }
}
