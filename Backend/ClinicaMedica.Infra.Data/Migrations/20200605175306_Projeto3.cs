using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaMedica.Infra.Data.Migrations
{
    public partial class Projeto3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtendimento",
                table: "Atendimento");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Atendimento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataTermino",
                table: "Atendimento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "DataTermino",
                table: "Atendimento");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtendimento",
                table: "Atendimento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
