using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIntegradorAccessData.Migrations
{
    /// <inheritdoc />
    public partial class turnosCarga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "TurnosCargas",
                newName: "FechaInicioSemana");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinSemana",
                table: "TurnosCargas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ToneladasAcumuladas",
                table: "TurnosCargas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinSemana",
                table: "TurnosCargas");

            migrationBuilder.DropColumn(
                name: "ToneladasAcumuladas",
                table: "TurnosCargas");

            migrationBuilder.RenameColumn(
                name: "FechaInicioSemana",
                table: "TurnosCargas",
                newName: "Fecha");
        }
    }
}
