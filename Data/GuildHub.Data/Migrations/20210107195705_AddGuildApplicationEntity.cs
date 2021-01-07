using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildHub.Data.Migrations
{
    public partial class AddGuildApplicationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuildApplications",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    GuildId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildApplications", x => new { x.UserId, x.GuildId });
                    table.ForeignKey(
                        name: "FK_GuildApplications_Guilds_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuildApplications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuildApplications_GuildId",
                table: "GuildApplications",
                column: "GuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuildApplications");
        }
    }
}
