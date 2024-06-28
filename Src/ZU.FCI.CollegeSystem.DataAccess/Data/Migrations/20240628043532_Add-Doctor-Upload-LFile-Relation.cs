using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorUploadLFileRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Lectures",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "LectureFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LectureFiles_DoctorId",
                table: "LectureFiles",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_LectureFiles_Doctors_DoctorId",
                table: "LectureFiles",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureFiles_Doctors_DoctorId",
                table: "LectureFiles");

            migrationBuilder.DropIndex(
                name: "IX_LectureFiles_DoctorId",
                table: "LectureFiles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "LectureFiles");
        }
    }
}
