using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace organizer.Migrations
{
    /// <inheritdoc />
    public partial class SignUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: -1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskGroups",
                columns: new[] { "TaskGroupID", "Description", "IsBuiltin", "Name", "UserID" },
                values: new object[,]
                {
                    { -5, null, true, "Все задачи", null },
                    { -4, null, true, "Уборка", null },
                    { -3, null, true, "Продукты", null },
                    { -2, null, true, "Работа", null },
                    { -1, null, true, "Прочее", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AvatarID", "BirthDate", "HashPassword", "IsMale", "Name", "Username" },
                values: new object[,]
                {
                    { -3, null, null, "dasha", false, "Дашуля", "dasha" },
                    { -2, null, null, "katya", false, "Катюша", "katya" },
                    { -1, null, null, "user", true, "Пользователь", "user" }
                });
        }
    }
}
