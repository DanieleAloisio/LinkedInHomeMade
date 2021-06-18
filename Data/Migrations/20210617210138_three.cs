using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "IdProfilo",
                table: "Esperienze",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Esperienze_IdProfilo",
                table: "Esperienze",
                column: "IdProfilo");

            migrationBuilder.AddForeignKey(
                name: "FK_Esperienze_Profilo_IdProfilo",
                table: "Esperienze",
                column: "IdProfilo",
                principalTable: "Profilo",
                principalColumn: "IdProfilo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Esperienze_Profilo_IdProfilo",
                table: "Esperienze");

            migrationBuilder.DropIndex(
                name: "IX_Esperienze_IdProfilo",
                table: "Esperienze");

            migrationBuilder.AlterColumn<int>(
                name: "IdProfilo",
                table: "Esperienze",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
