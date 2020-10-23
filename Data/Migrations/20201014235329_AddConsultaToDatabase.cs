using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class AddConsultaToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    ConsultaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(nullable: true),
                    PersonaOFIMId = table.Column<string>(nullable: true),
                    TipoConsultaId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    HoraFin = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    RespuestaOfrecida = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.ConsultaId);
                    table.ForeignKey(
                        name: "FK_Consulta_PersonaOFIM_PersonaOFIMId",
                        column: x => x.PersonaOFIMId,
                        principalTable: "PersonaOFIM",
                        principalColumn: "PersonaOFIMId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_TipoConsulta_TipoConsultaId",
                        column: x => x.TipoConsultaId,
                        principalTable: "TipoConsulta",
                        principalColumn: "TipoConsultaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PersonaOFIMId",
                table: "Consulta",
                column: "PersonaOFIMId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_TipoConsultaId",
                table: "Consulta",
                column: "TipoConsultaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");
        }
    }
}
