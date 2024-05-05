using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace organizer.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "RepeatableTasks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDone",
                table: "RepeatableTasks",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "RepeatableTasks");

            migrationBuilder.DropColumn(
                name: "LastDone",
                table: "RepeatableTasks");
        }
    }
}
