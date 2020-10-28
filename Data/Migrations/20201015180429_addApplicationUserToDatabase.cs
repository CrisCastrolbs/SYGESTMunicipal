using Microsoft.EntityFrameworkCore.Migrations;

namespace SYGESTMunicipal.Data.Migrations
{
    public partial class addApplicationUserToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");
            
            migrationBuilder.AddColumn<string>(
               name: "IdPassport",
               table: "AspNetUsers",
               nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName2",
                table: "AspNetUsers",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Canton",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                nullable: true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
               name: "IdPassport",
               table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
               name: "LastName1",
               table: "AspNetUsers");

            migrationBuilder.DropColumn(
               name: "LastName2",
               table: "AspNetUsers");
            
            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "AspNetUsers");
            
            migrationBuilder.DropColumn(
                name: "District",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Canton",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AspNetUsers");

            
        }
    }
}
