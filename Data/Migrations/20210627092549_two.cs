using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Votazione",
                table: "Esperienze",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Votazione",
                table: "Esperienze");
        }
    }
}
