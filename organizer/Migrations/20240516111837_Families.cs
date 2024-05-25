using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace organizer.Migrations
{
    /// <inheritdoc />
    public partial class Families : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FamilyID",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FamilyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FamilyID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyID",
                table: "Users",
                column: "FamilyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Families_FamilyID",
                table: "Users",
                column: "FamilyID",
                principalTable: "Families",
                principalColumn: "FamilyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Families_FamilyID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Users_FamilyID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FamilyID",
                table: "Users");
        }
    }
}
