using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fans",
                columns: table => new
                {
                    FanUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fans", x => new { x.FollowUserId, x.FanUserId });
                    table.ForeignKey(
                        name: "FK_Fans_AspNetUsers_FanUserId",
                        column: x => x.FanUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fans_AspNetUsers_FollowUserId",
                        column: x => x.FollowUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fans_FanUserId",
                table: "Fans",
                column: "FanUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fans");
        }
    }
}
