using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotasDaFacul.Server.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradesModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Grade = table.Column<decimal>(type: "numeric(2,0)", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradesModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradesModel");
        }
    }
}
