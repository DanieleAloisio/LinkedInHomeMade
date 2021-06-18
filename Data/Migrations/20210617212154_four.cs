using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Citta",
                table: "Profilo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Paese",
                table: "Profilo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Professione",
                table: "Profilo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Citta",
                table: "Profilo");

            migrationBuilder.DropColumn(
                name: "Paese",
                table: "Profilo");

            migrationBuilder.DropColumn(
                name: "Professione",
                table: "Profilo");
        }
    }
}
