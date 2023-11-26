using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "events");

            migrationBuilder.AddColumn<DateTime>(
                name: "DismissalTime",
                table: "events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingTime",
                table: "events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DismissalTime",
                table: "events");

            migrationBuilder.DropColumn(
                name: "MeetingTime",
                table: "events");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
