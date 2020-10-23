using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class AddComplaintToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonOFGA",
                columns: table => new
                {
                    PersonOFGAId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName1 = table.Column<string>(nullable: false),
                    LastName2 = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Province = table.Column<string>(nullable: false),
                    Canton = table.Column<string>(nullable: false),
                    District = table.Column<string>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    CellphoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonOFGA", x => x.PersonOFGAId);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PersonOFGAId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaint_PersonOFGA_PersonOFGAId",
                        column: x => x.PersonOFGAId,
                        principalTable: "PersonOFGA",
                        principalColumn: "PersonOFGAId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_PersonOFGAId",
                table: "Complaint",
                column: "PersonOFGAId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "PersonOFGA");
        }
    }
}
