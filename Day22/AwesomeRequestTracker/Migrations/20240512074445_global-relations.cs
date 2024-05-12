using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeRequestTracker.Migrations
{
    /// <inheritdoc />
    public partial class globalrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Person_RequestRaisedById",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "RequestFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestRaisedById",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestRaisedById",
                table: "Requests",
                newName: "RequestRaisedBy");

            migrationBuilder.AddColumn<bool>(
                name: "IsSolved",
                table: "RequestSolutions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "RequestSolutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RequestRaiserComment",
                table: "RequestSolutions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolutionDescription",
                table: "RequestSolutions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SolvedBy",
                table: "RequestSolutions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SolvedDate",
                table: "RequestSolutions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaisedById",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestClosedBy",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestClosedByEmployeeId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RequestMessage",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequestStatus",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SolutionFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionId = table.Column<int>(type: "int", nullable: false),
                    FeedbackBy = table.Column<int>(type: "int", nullable: false),
                    FeedbackByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionFeedbacks_Employees_FeedbackByEmployeeId",
                        column: x => x.FeedbackByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolutionFeedbacks_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "RequestSolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolutions_RequestId",
                table: "RequestSolutions",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolutions_SolvedBy",
                table: "RequestSolutions",
                column: "SolvedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RaisedById",
                table: "Requests",
                column: "RaisedById");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestClosedByEmployeeId",
                table: "Requests",
                column: "RequestClosedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedbacks_FeedbackByEmployeeId",
                table: "SolutionFeedbacks",
                column: "FeedbackByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedbacks_PersonId",
                table: "SolutionFeedbacks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedbacks_SolutionId",
                table: "SolutionFeedbacks",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestClosedByEmployeeId",
                table: "Requests",
                column: "RequestClosedByEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Person_RaisedById",
                table: "Requests",
                column: "RaisedById",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Employees_SolvedBy",
                table: "RequestSolutions",
                column: "SolvedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedByEmployeeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Person_RaisedById",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Employees_SolvedBy",
                table: "RequestSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions");

            migrationBuilder.DropTable(
                name: "SolutionFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_RequestSolutions_RequestId",
                table: "RequestSolutions");

            migrationBuilder.DropIndex(
                name: "IX_RequestSolutions_SolvedBy",
                table: "RequestSolutions");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RaisedById",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestClosedByEmployeeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsSolved",
                table: "RequestSolutions");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "RequestSolutions");

            migrationBuilder.DropColumn(
                name: "RequestRaiserComment",
                table: "RequestSolutions");

            migrationBuilder.DropColumn(
                name: "SolutionDescription",
                table: "RequestSolutions");

            migrationBuilder.DropColumn(
                name: "SolvedBy",
                table: "RequestSolutions");

            migrationBuilder.DropColumn(
                name: "SolvedDate",
                table: "RequestSolutions");

            migrationBuilder.DropColumn(
                name: "ClosedDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RaisedById",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestClosedByEmployeeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestMessage",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestRaisedBy",
                table: "Requests",
                newName: "RequestRaisedById");

            migrationBuilder.CreateTable(
                name: "RequestFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestRaisedById",
                table: "Requests",
                column: "RequestRaisedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Person_RequestRaisedById",
                table: "Requests",
                column: "RequestRaisedById",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
