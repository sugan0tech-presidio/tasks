using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeRequestTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddPswd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Person");
        }
    }
}
