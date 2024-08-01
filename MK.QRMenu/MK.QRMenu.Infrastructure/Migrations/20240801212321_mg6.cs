using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MK.QRMenu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                schema: "MENU",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KategoriAdi = table.Column<string>(type: "varchar(100)", nullable: false),
                    UstKategoriId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArkaPlanRengi = table.Column<string>(type: "varchar(50)", nullable: true),
                    YaziRengi = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kategoriler",
                schema: "MENU");
        }
    }
}
