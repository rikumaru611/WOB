using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEventProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start_Date",
                table: "events",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "End_Date",
                table: "events",
                newName: "End");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "events",
                newName: "Start_Date");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "events",
                newName: "End_Date");
        }
    }
}
