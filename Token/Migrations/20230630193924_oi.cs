using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Token.Migrations
{
    /// <inheritdoc />
    public partial class oi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Doctor_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doctor_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doctor_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doctor_Mobile = table.Column<int>(type: "int", nullable: false),
                    Emergency_No = table.Column<int>(type: "int", nullable: false),
                    Doctor_Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constulting_Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constulting_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Doctor_ID);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Patient_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Phone = table.Column<int>(type: "int", nullable: false),
                    Patient_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Patient_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Payment = table.Column<int>(type: "int", nullable: false),
                    Doctor_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Patient_ID);
                    table.ForeignKey(
                        name: "FK_Patient_Doctor_Doctor_ID",
                        column: x => x.Doctor_ID,
                        principalTable: "Doctor",
                        principalColumn: "Doctor_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Doctor_ID",
                table: "Patient",
                column: "Doctor_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
