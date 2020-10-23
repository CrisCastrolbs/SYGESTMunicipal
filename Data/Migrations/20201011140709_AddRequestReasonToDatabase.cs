using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class AddRequestReasonToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestReason",
                columns: table => new
                {
                    RequestReasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestReason", x => x.RequestReasonId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestReason");
        }
    }
}
