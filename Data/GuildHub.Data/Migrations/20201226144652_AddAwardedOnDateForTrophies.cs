using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildHub.Data.Migrations
{
    public partial class AddAwardedOnDateForTrophies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AwardedOn",
                table: "UsersTrophies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AwardedOn",
                table: "GuildsTrophies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwardedOn",
                table: "UsersTrophies");

            migrationBuilder.DropColumn(
                name: "AwardedOn",
                table: "GuildsTrophies");
        }
    }
}
