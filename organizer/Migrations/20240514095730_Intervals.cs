using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace organizer.Migrations
{
    /// <inheritdoc />
    public partial class Intervals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Interval",
                table: "RepeatableTasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interval",
                table: "RepeatableTasks");
        }
    }
}
