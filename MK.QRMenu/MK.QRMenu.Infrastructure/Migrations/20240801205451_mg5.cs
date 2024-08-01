using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.QRMenu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleleteDate",
                schema: "MENU",
                table: "Kampanyalar",
                newName: "DeleteDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                schema: "MENU",
                table: "Kampanyalar",
                newName: "DeleleteDate");
        }
    }
}
