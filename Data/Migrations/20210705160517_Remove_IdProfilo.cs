using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Remove_IdProfilo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProfilo",
                table: "Esperienze");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProfilo",
                table: "Esperienze",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
