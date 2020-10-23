using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class AddEstablishmentToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    ActivityTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.ActivityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.ApplicantId);
                });

            migrationBuilder.CreateTable(
                name: "CIIU",
                columns: table => new
                {
                    CIIUId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIIU", x => x.CIIUId);
                });

            migrationBuilder.CreateTable(
                name: "EstablishmentType",
                columns: table => new
                {
                    EstablishmentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablishmentType", x => x.EstablishmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Establishment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CIIUId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    OtherActivities = table.Column<string>(nullable: true),
                    NFarm = table.Column<string>(nullable: false),
                    DesignNum = table.Column<string>(nullable: false),
                    WorkingHours = table.Column<string>(nullable: false),
                    WMen = table.Column<string>(nullable: false),
                    WWomen = table.Column<string>(nullable: false),
                    ApplicantId = table.Column<int>(nullable: false),
                    WebPage = table.Column<string>(nullable: true),
                    SkilledWorkers = table.Column<string>(nullable: false),
                    UnskilledWorkers = table.Column<string>(nullable: false),
                    EstablishmentTypeId = table.Column<int>(nullable: false),
                    ActivityTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Establishment_ActivityType_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "ActivityTypeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Establishment_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Establishment_CIIU_CIIUId",
                        column: x => x.CIIUId,
                        principalTable: "CIIU",
                        principalColumn: "CIIUId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Establishment_EstablishmentType_EstablishmentTypeId",
                        column: x => x.EstablishmentTypeId,
                        principalTable: "EstablishmentType",
                        principalColumn: "EstablishmentTypeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Establishment_ActivityTypeId",
                table: "Establishment",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Establishment_ApplicantId",
                table: "Establishment",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Establishment_CIIUId",
                table: "Establishment",
                column: "CIIUId");

            migrationBuilder.CreateIndex(
                name: "IX_Establishment_EstablishmentTypeId",
                table: "Establishment",
                column: "EstablishmentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Establishment");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropTable(
                name: "CIIU");

            migrationBuilder.DropTable(
                name: "EstablishmentType");
        }
    }
}
