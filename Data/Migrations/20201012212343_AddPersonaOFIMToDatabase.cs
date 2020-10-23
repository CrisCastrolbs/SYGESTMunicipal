using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class AddPersonaOFIMToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                     EstadoCivilId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.EstadoCivilId);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelAcademico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelAcademico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocupacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguro", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "PersonaOFIM",
                columns: table => new
                {
                    PersonaOFIMId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Canton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildNumber = table.Column<int>(type: "int", nullable: false),
                    CoupleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false),
                    LatName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NacionalidadId = table.Column<int>(type: "int", nullable: false),
                    NivelAcademicoId = table.Column<int>(type: "int", nullable: false),
                    OcupacionId = table.Column<int>(type: "int", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeguroId = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaOFIM", x => x.PersonaOFIMId);
                    table.ForeignKey(
                        name: "FK_PersonaOFIM_EstadoCivil_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadoCivil",
                        principalColumn: "EstadoCivilId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonaOFIM_Nacionalidad_NacionalidadId",
                        column: x => x.NacionalidadId,
                        principalTable: "Nacionalidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonaOFIM_NivelAcademico_NivelAcademicoId",
                        column: x => x.NivelAcademicoId,
                        principalTable: "NivelAcademico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonaOFIM_Ocupacion_OcupacionId",
                        column: x => x.OcupacionId,
                        principalTable: "Ocupacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonaOFIM_Seguro_SeguroId",
                        column: x => x.SeguroId,
                        principalTable: "Seguro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });


            migrationBuilder.CreateIndex(
                name: "IX_PersonaOFIM_EstadoCivilId",
                table: "PersonaOFIM",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaOFIM_NacionalidadId",
                table: "PersonaOFIM",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaOFIM_NivelAcademicoId",
                table: "PersonaOFIM",
                column: "NivelAcademicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaOFIM_OcupacionId",
                table: "PersonaOFIM",
                column: "OcupacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaOFIM_SeguroId",
                table: "PersonaOFIM",
                column: "SeguroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "PersonaOFIM");

            migrationBuilder.DropTable(
                 name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Nacionalidad");

            migrationBuilder.DropTable(
                name: "NivelAcademico");

            migrationBuilder.DropTable(
                name: "Ocupacion");

            migrationBuilder.DropTable(
                name: "Seguro");
        }
    }
}
