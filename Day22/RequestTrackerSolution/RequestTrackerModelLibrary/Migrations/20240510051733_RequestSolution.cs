using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class RequestSolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Something",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RequestSolution",
                columns: table => new
                {
                    SolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    SolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolvedBy = table.Column<int>(type: "int", nullable: false),
                    SolvedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false),
                    RequestRaiserComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSolution", x => x.SolutionId);
                    table.ForeignKey(
                        name: "FK_RequestSolution_Employees_SolvedBy",
                        column: x => x.SolvedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestSolution_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolution_RequestId",
                table: "RequestSolution",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolution_SolvedBy",
                table: "RequestSolution",
                column: "SolvedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestSolution");

            migrationBuilder.DropColumn(
                name: "Something",
                table: "Requests");
        }
    }
}
