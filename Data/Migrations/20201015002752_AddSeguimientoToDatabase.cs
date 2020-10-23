using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class AddSeguimientoToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguimiento",
                columns: table => new
                {
                    SeguimientoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    PersonaOFIMId = table.Column<string>(nullable: true),
                    ConsultaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimiento", x => x.SeguimientoId);
                    table.ForeignKey(
                        name: "FK_Seguimiento_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "ConsultaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seguimiento_PersonaOFIM_PersonaOFIMId",
                        column: x => x.PersonaOFIMId,
                        principalTable: "PersonaOFIM",
                        principalColumn: "PersonaOFIMId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_ConsultaId",
                table: "Seguimiento",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_PersonaOFIMId",
                table: "Seguimiento",
                column: "PersonaOFIMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguimiento");
        }
    }
}
