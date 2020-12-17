using Microsoft.EntityFrameworkCore.Migrations;

namespace APPTESTE.Migrations
{
    public partial class TabelaParticipante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    V_Sem = table.Column<float>(nullable: false),
                    V_Com = table.Column<float>(nullable: false),
                    ChurrascoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participantes_Churrascos_ChurrascoId",
                        column: x => x.ChurrascoId,
                        principalTable: "Churrascos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_ChurrascoId",
                table: "Participantes",
                column: "ChurrascoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
