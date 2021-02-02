using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class AddProductoToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Imagen = table.Column<byte[]>(nullable: true),
                    ClasificacionID = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Clasificacion_ClasificacionID",
                        column: x => x.ClasificacionID,
                        principalTable: "Clasificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ClasificacionID",
                table: "Producto",
                column: "ClasificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_EmpresaId",
                table: "Producto",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
