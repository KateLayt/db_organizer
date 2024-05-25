using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace organizer.Migrations
{
    /// <inheritdoc />
    public partial class AllTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -4,
                column: "Name",
                value: "Уборка");

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -3,
                column: "Name",
                value: "Продукты");

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -2,
                column: "Name",
                value: "Работа");

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -1,
                column: "Name",
                value: "Прочее");

            migrationBuilder.InsertData(
                table: "TaskGroups",
                columns: new[] { "TaskGroupID", "Description", "IsBuiltin", "Name", "UserID" },
                values: new object[] { -5, null, true, "Все задачи", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -5);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -4,
                column: "Name",
                value: "Прочее");

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -3,
                column: "Name",
                value: "Работа");

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -2,
                column: "Name",
                value: "Продукты");

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "TaskGroupID",
                keyValue: -1,
                column: "Name",
                value: "Уборка");
        }
    }
}
