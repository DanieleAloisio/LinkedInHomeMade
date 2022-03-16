using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class rel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CurriculumVitae_IdCurriculumVitae",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdCurriculumVitae",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdCurriculumVitae",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IdApplicationUser",
                table: "CurriculumVitae",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "CurriculumVitaeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurriculumVitaeId",
                table: "AspNetUsers",
                column: "CurriculumVitaeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CurriculumVitae_CurriculumVitaeId",
                table: "AspNetUsers",
                column: "CurriculumVitaeId",
                principalTable: "CurriculumVitae",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CurriculumVitae_CurriculumVitaeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurriculumVitaeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurriculumVitaeId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CurriculumVitae",
                newName: "IdApplicationUser");

            migrationBuilder.AddColumn<int>(
                name: "IdCurriculumVitae",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdCurriculumVitae",
                table: "AspNetUsers",
                column: "IdCurriculumVitae");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CurriculumVitae_IdCurriculumVitae",
                table: "AspNetUsers",
                column: "IdCurriculumVitae",
                principalTable: "CurriculumVitae",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
