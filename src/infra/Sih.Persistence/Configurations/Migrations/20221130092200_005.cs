using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sih.Persistence.Configurations.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avions");

            migrationBuilder.DropColumn(
                name: "Datedepart",
                table: "Voyages");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Voyages");

            migrationBuilder.AddColumn<int>(
                name: "Capacite",
                table: "Vols",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datedepart",
                table: "Vols",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "Vols",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumTel",
                table: "Usagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacite",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "Datedepart",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Vols");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usagers");

            migrationBuilder.DropColumn(
                name: "NumTel",
                table: "Usagers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datedepart",
                table: "Voyages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "Voyages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Avions",
                columns: table => new
                {
                    AvionEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    NumAvion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avions", x => x.AvionEntityId);
                });
        }
    }
}
