using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class AddPersonPatentesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonPatentes",
                columns: table => new
                {
                    PersonId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName1 = table.Column<string>(nullable: false),
                    LastName2 = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Province = table.Column<string>(nullable: false),
                    Canton = table.Column<string>(nullable: false),
                    District = table.Column<string>(nullable: false),
                    Neighborhood = table.Column<string>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    CellphoneNumber = table.Column<string>(nullable: false),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NameF = table.Column<string>(nullable: true),
                    LastName1F = table.Column<string>(nullable: true),
                    LastName2F = table.Column<string>(nullable: true),
                    FisicID = table.Column<string>(nullable: true),
                    NameJ = table.Column<string>(nullable: true),
                    NameJS = table.Column<string>(nullable: true),
                    JuridicId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPatentes", x => x.PersonId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPatentes");
        }
    }
}
