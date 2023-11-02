﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOB.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbver1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Number);
                    table.ForeignKey(
                        name: "FK_players_statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCodeId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: true),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_users_coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_players_Number",
                        column: x => x.Number,
                        principalTable: "players",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_users_staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_userCodes_UserCodeId",
                        column: x => x.UserCodeId,
                        principalTable: "userCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_StatusId",
                table: "players",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_users_CoachId",
                table: "users",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Number",
                table: "users",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_users_StaffId",
                table: "users",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserCodeId",
                table: "users",
                column: "UserCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "coaches");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "staffs");

            migrationBuilder.DropTable(
                name: "userCodes");

            migrationBuilder.DropTable(
                name: "statuses");
        }
    }
}
