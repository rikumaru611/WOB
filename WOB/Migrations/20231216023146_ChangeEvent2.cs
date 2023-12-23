using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEvent2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_eventTypes_EventTypeId",
                table: "events");

            migrationBuilder.DropIndex(
                name: "IX_events_EventTypeId",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "events");

            migrationBuilder.DropColumn(
                name: "DismissalTime",
                table: "events");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "events");

            migrationBuilder.DropColumn(
                name: "MeetingTime",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Valid",
                table: "events");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "events",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "End_Date",
                table: "events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Start_Date",
                table: "events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "events");

            migrationBuilder.DropColumn(
                name: "End_Date",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Start_Date",
                table: "events");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "events",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DismissalTime",
                table: "events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventTypeId",
                table: "events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingTime",
                table: "events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_events_EventTypeId",
                table: "events",
                column: "EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_events_eventTypes_EventTypeId",
                table: "events",
                column: "EventTypeId",
                principalTable: "eventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
