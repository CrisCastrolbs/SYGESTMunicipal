using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class AddEmpresaToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Manager = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Direction = table.Column<string>(nullable: false),
                    WebPage = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Imagen = table.Column<byte[]>(nullable: true),
                    ClasificacionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Clasificacion_ClasificacionID",
                        column: x => x.ClasificacionID,
                        principalTable: "Clasificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_ClasificacionID",
                table: "Empresa",
                column: "ClasificacionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
