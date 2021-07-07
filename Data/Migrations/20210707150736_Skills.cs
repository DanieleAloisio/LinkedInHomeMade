using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Skills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rel_Skills_ApplicationUsers_Skill_SkillsId",
                table: "Rel_Skills_ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Competenza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rel_Skills_ApplicationUsers_Skills_SkillsId",
                table: "Rel_Skills_ApplicationUsers",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rel_Skills_ApplicationUsers_Skills_SkillsId",
                table: "Rel_Skills_ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Competenza = table.Column<int>(type: "int", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rel_Skills_ApplicationUsers_Skill_SkillsId",
                table: "Rel_Skills_ApplicationUsers",
                column: "SkillsId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
