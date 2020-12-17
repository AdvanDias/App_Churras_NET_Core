using Microsoft.EntityFrameworkCore.Migrations;

namespace APPTESTE.Migrations
{
    public partial class AdicionandoCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Churrascos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Churrascos");
        }
    }
}
