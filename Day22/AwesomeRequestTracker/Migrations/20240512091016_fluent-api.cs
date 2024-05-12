using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeRequestTracker.Migrations
{
    /// <inheritdoc />
    public partial class fluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackByEmployeeId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_Person_PersonId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_SolutionFeedbacks_FeedbackByEmployeeId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_SolutionFeedbacks_PersonId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RaisedById",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestClosedByEmployeeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "FeedbackByEmployeeId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropColumn(
                name: "RaisedById",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestClosedByEmployeeId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedbacks_FeedbackBy",
                table: "SolutionFeedbacks",
                column: "FeedbackBy");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestRaisedBy",
                table: "Requests",
                column: "RequestRaisedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Person_Id",
                table: "Employees",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Person_RequestRaisedBy",
                table: "Requests",
                column: "RequestRaisedBy",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_Person_FeedbackBy",
                table: "SolutionFeedbacks",
                column: "FeedbackBy",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Person_Id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Person_RequestRaisedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Employees_SolvedBy",
                table: "RequestSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_Person_FeedbackBy",
                table: "SolutionFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_SolutionFeedbacks_FeedbackBy",
                table: "SolutionFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestRaisedBy",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackByEmployeeId",
                table: "SolutionFeedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "SolutionFeedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaisedById",
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedbacks_FeedbackByEmployeeId",
                table: "SolutionFeedbacks",
                column: "FeedbackByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedbacks_PersonId",
                table: "SolutionFeedbacks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RaisedById",
                table: "Requests",
                column: "RaisedById");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestClosedByEmployeeId",
                table: "Requests",
                column: "RequestClosedByEmployeeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackByEmployeeId",
                table: "SolutionFeedbacks",
                column: "FeedbackByEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_Person_PersonId",
                table: "SolutionFeedbacks",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
