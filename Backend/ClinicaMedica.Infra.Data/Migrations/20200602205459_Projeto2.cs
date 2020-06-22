using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaMedica.Infra.Data.Migrations
{
    public partial class Projeto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Paciente_CPF",
                table: "Paciente",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medico_CRM",
                table: "Medico",
                column: "CRM",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Paciente_CPF",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Medico_CRM",
                table: "Medico");
        }
    }
}
