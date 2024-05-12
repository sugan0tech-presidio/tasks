using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeRequestTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Person");
        }
    }
}
