using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeRequestTracker.Migrations
{
    /// <inheritdoc />
    public partial class PersonRelationsAndRegistry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registry",
                table: "Registry");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Registry",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registry",
                table: "Registry",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Registry_PersonId",
                table: "Registry",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registry",
                table: "Registry");

            migrationBuilder.DropIndex(
                name: "IX_Registry_PersonId",
                table: "Registry");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Registry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registry",
                table: "Registry",
                column: "PersonId");
        }
    }
}
