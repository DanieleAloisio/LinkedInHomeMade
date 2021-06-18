using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfiloIdProfilo",
                table: "Esperienze",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Esperienze_ProfiloIdProfilo",
                table: "Esperienze",
                column: "ProfiloIdProfilo");

            migrationBuilder.AddForeignKey(
                name: "FK_Esperienze_Profilo_ProfiloIdProfilo",
                table: "Esperienze",
                column: "ProfiloIdProfilo",
                principalTable: "Profilo",
                principalColumn: "IdProfilo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Esperienze_Profilo_ProfiloIdProfilo",
                table: "Esperienze");

            migrationBuilder.DropIndex(
                name: "IX_Esperienze_ProfiloIdProfilo",
                table: "Esperienze");

            migrationBuilder.DropColumn(
                name: "ProfiloIdProfilo",
                table: "Esperienze");
        }
    }
}
