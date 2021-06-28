using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoGruppo",
                table: "Profilo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoGruppo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoGruppo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profilo_IdTipoGruppo",
                table: "Profilo",
                column: "IdTipoGruppo");

            migrationBuilder.AddForeignKey(
                name: "FK_Profilo_TipoGruppo_IdTipoGruppo",
                table: "Profilo",
                column: "IdTipoGruppo",
                principalTable: "TipoGruppo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profilo_TipoGruppo_IdTipoGruppo",
                table: "Profilo");

            migrationBuilder.DropTable(
                name: "TipoGruppo");

            migrationBuilder.DropIndex(
                name: "IX_Profilo_IdTipoGruppo",
                table: "Profilo");

            migrationBuilder.DropColumn(
                name: "IdTipoGruppo",
                table: "Profilo");
        }
    }
}
