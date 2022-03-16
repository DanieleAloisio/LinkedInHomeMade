using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class relpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CurriculumVitae_CurriculumVitaeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurriculumVitaeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CurriculumVitaeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurriculumVitaeId",
                table: "AspNetUsers",
                column: "CurriculumVitaeId",
                unique: true,
                filter: "[CurriculumVitaeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CurriculumVitae_CurriculumVitaeId",
                table: "AspNetUsers",
                column: "CurriculumVitaeId",
                principalTable: "CurriculumVitae",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CurriculumVitae_CurriculumVitaeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurriculumVitaeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CurriculumVitaeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
