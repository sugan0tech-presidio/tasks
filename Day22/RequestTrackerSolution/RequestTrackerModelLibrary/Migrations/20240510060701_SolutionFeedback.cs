using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SolutionFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Employees_SolvedBy",
                table: "RequestSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Requests_RequestId",
                table: "RequestSolution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSolution",
                table: "RequestSolution");

            migrationBuilder.RenameTable(
                name: "RequestSolution",
                newName: "RequestSolutions");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolution_SolvedBy",
                table: "RequestSolutions",
                newName: "IX_RequestSolutions_SolvedBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolution_RequestId",
                table: "RequestSolutions",
                newName: "IX_RequestSolutions_RequestId");

            migrationBuilder.AddColumn<int>(
                name: "solutionFeedbackFeedbackId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSolutions",
                table: "RequestSolutions",
                column: "SolutionId");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionId = table.Column<int>(type: "int", nullable: false),
                    FeedbackBy = table.Column<int>(type: "int", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Employees_FeedbackBy",
                        column: x => x.FeedbackBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_RequestSolutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "RequestSolutions",
                        principalColumn: "SolutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_solutionFeedbackFeedbackId",
                table: "Requests",
                column: "solutionFeedbackFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackBy",
                table: "Feedbacks",
                column: "FeedbackBy");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_SolutionId",
                table: "Feedbacks",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Feedbacks_solutionFeedbackFeedbackId",
                table: "Requests",
                column: "solutionFeedbackFeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Employees_SolvedBy",
                table: "RequestSolutions",
                column: "SolvedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Feedbacks_solutionFeedbackFeedbackId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Employees_SolvedBy",
                table: "RequestSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Requests_solutionFeedbackFeedbackId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSolutions",
                table: "RequestSolutions");

            migrationBuilder.DropColumn(
                name: "solutionFeedbackFeedbackId",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "RequestSolutions",
                newName: "RequestSolution");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolutions_SolvedBy",
                table: "RequestSolution",
                newName: "IX_RequestSolution_SolvedBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolutions_RequestId",
                table: "RequestSolution",
                newName: "IX_RequestSolution_RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSolution",
                table: "RequestSolution",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Employees_SolvedBy",
                table: "RequestSolution",
                column: "SolvedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Requests_RequestId",
                table: "RequestSolution",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
