using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeRequestTracker.Migrations
{
    /// <inheritdoc />
    public partial class tmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Person",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContactNumber",
                value: "6855339922");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ContactNumber", "Role" },
                values: new object[] { "6855339922", 2 });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3,
                column: "ContactNumber",
                value: "6855339922");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "ContactNumber" },
                values: new object[] { "magic, street", "6855339922" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address", "ContactNumber", "Email", "Name", "Role" },
                values: new object[] { 5, "Someting", "9855339922", "bboi@gmail.com", "bboi", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                column: "Id",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Person");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address",
                value: null);
        }
    }
}
