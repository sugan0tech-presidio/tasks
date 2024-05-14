using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorsAppointmentManager.Migrations
{
    /// <inheritdoc />
    public partial class manytomanyrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qualification_Doctors_DoctorId",
                table: "Qualification");

            migrationBuilder.DropForeignKey(
                name: "FK_Speciality_Doctors_DoctorId",
                table: "Speciality");

            migrationBuilder.DropIndex(
                name: "IX_Speciality_DoctorId",
                table: "Speciality");

            migrationBuilder.DropIndex(
                name: "IX_Qualification_DoctorId",
                table: "Qualification");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Speciality");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Qualification");

            migrationBuilder.CreateTable(
                name: "DoctorQualification",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    QualificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorQualification", x => new { x.DoctorsId, x.QualificationId });
                    table.ForeignKey(
                        name: "FK_DoctorQualification_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorQualification_Qualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpeciality",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    SpecialitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpeciality", x => new { x.DoctorsId, x.SpecialitiesId });
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Speciality_SpecialitiesId",
                        column: x => x.SpecialitiesId,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorQualification_QualificationId",
                table: "DoctorQualification",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpeciality_SpecialitiesId",
                table: "DoctorSpeciality",
                column: "SpecialitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorQualification");

            migrationBuilder.DropTable(
                name: "DoctorSpeciality");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Speciality",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Qualification",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 1,
                column: "DoctorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 2,
                column: "DoctorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 3,
                column: "DoctorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 4,
                column: "DoctorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 1,
                column: "DoctorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 2,
                column: "DoctorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 3,
                column: "DoctorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 4,
                column: "DoctorId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Speciality_DoctorId",
                table: "Speciality",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_DoctorId",
                table: "Qualification",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualification_Doctors_DoctorId",
                table: "Qualification",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Speciality_Doctors_DoctorId",
                table: "Speciality",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
