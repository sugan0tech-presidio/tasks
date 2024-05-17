using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomePizzas.Migrations
{
    /// <inheritdoc />
    public partial class addresstypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address",
                table: "Orders",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "address");
        }
    }
}
