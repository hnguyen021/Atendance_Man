using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core_3._1.Migrations
{
    public partial class AttendanceMan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceEntry",
                columns: table => new
                {
                    IdAttendanceEntry = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCheck = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckAttendance = table.Column<bool>(type: "bit", nullable: false),
                    IdPhysicalClass = table.Column<long>(type: "bigint", nullable: false),
                    IdStudent = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceEntry", x => x.IdAttendanceEntry);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    IdTeacher = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTeacher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MailTeacher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdPhysicalClass = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.IdTeacher);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalClass",
                columns: table => new
                {
                    IdPhysicalClass = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumberSession = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdStudent = table.Column<long>(type: "bigint", nullable: false),
                    IdTeacher = table.Column<long>(type: "bigint", nullable: false),
                    IdAttendanceEntry = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalClass", x => x.IdPhysicalClass);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    IdStudent = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStudent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IdPhysicalClass = table.Column<long>(type: "bigint", nullable: false),
                    IdAttendanceEntry = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.IdStudent);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceEntryPhysicalClass",
                columns: table => new
                {
                    PhysicalClassIdPhysicalClass = table.Column<long>(type: "bigint", nullable: false),
                    attendanceEntryIdAttendanceEntry = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceEntryPhysicalClass", x => new { x.PhysicalClassIdPhysicalClass, x.attendanceEntryIdAttendanceEntry });
                    table.ForeignKey(
                        name: "FK_AttendanceEntryPhysicalClass_AttendanceEntry_attendanceEntryIdAttendanceEntry",
                        column: x => x.attendanceEntryIdAttendanceEntry,
                        principalTable: "AttendanceEntry",
                        principalColumn: "IdAttendanceEntry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceEntryPhysicalClass_PhysicalClass_PhysicalClassIdPhysicalClass",
                        column: x => x.PhysicalClassIdPhysicalClass,
                        principalTable: "PhysicalClass",
                        principalColumn: "IdPhysicalClass",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerPhysicalClass",
                columns: table => new
                {
                    LecturersIdTeacher = table.Column<long>(type: "bigint", nullable: false),
                    PhysicalClassIdPhysicalClass = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerPhysicalClass", x => new { x.LecturersIdTeacher, x.PhysicalClassIdPhysicalClass });
                    table.ForeignKey(
                        name: "FK_LecturerPhysicalClass_Lecturer_LecturersIdTeacher",
                        column: x => x.LecturersIdTeacher,
                        principalTable: "Lecturer",
                        principalColumn: "IdTeacher",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerPhysicalClass_PhysicalClass_PhysicalClassIdPhysicalClass",
                        column: x => x.PhysicalClassIdPhysicalClass,
                        principalTable: "PhysicalClass",
                        principalColumn: "IdPhysicalClass",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceEntryStudent",
                columns: table => new
                {
                    AttendanceEntriesIdAttendanceEntry = table.Column<long>(type: "bigint", nullable: false),
                    StudentsIdStudent = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceEntryStudent", x => new { x.AttendanceEntriesIdAttendanceEntry, x.StudentsIdStudent });
                    table.ForeignKey(
                        name: "FK_AttendanceEntryStudent_AttendanceEntry_AttendanceEntriesIdAttendanceEntry",
                        column: x => x.AttendanceEntriesIdAttendanceEntry,
                        principalTable: "AttendanceEntry",
                        principalColumn: "IdAttendanceEntry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceEntryStudent_Student_StudentsIdStudent",
                        column: x => x.StudentsIdStudent,
                        principalTable: "Student",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalClassStudent",
                columns: table => new
                {
                    PhysicalClassIdPhysicalClass = table.Column<long>(type: "bigint", nullable: false),
                    StudentsIdStudent = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalClassStudent", x => new { x.PhysicalClassIdPhysicalClass, x.StudentsIdStudent });
                    table.ForeignKey(
                        name: "FK_PhysicalClassStudent_PhysicalClass_PhysicalClassIdPhysicalClass",
                        column: x => x.PhysicalClassIdPhysicalClass,
                        principalTable: "PhysicalClass",
                        principalColumn: "IdPhysicalClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicalClassStudent_Student_StudentsIdStudent",
                        column: x => x.StudentsIdStudent,
                        principalTable: "Student",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceEntryPhysicalClass_attendanceEntryIdAttendanceEntry",
                table: "AttendanceEntryPhysicalClass",
                column: "attendanceEntryIdAttendanceEntry");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceEntryStudent_StudentsIdStudent",
                table: "AttendanceEntryStudent",
                column: "StudentsIdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerPhysicalClass_PhysicalClassIdPhysicalClass",
                table: "LecturerPhysicalClass",
                column: "PhysicalClassIdPhysicalClass");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalClassStudent_StudentsIdStudent",
                table: "PhysicalClassStudent",
                column: "StudentsIdStudent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttendanceEntryPhysicalClass");

            migrationBuilder.DropTable(
                name: "AttendanceEntryStudent");

            migrationBuilder.DropTable(
                name: "LecturerPhysicalClass");

            migrationBuilder.DropTable(
                name: "PhysicalClassStudent");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AttendanceEntry");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "PhysicalClass");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
