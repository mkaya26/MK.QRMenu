using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.QRMenu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MENU");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "MENU");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "MENU");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                schema: "MENU",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "MENU",
                newName: "Roles");
        }
    }
}
