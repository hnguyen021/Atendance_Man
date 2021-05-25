﻿// <auto-generated />
using System;
using Core_3._1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core_3._1.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AttendanceEntryPhysicalClass", b =>
                {
                    b.Property<long>("PhysicalClassIdPhysicalClass")
                        .HasColumnType("bigint");

                    b.Property<long>("attendanceEntryIdAttendanceEntry")
                        .HasColumnType("bigint");

                    b.HasKey("PhysicalClassIdPhysicalClass", "attendanceEntryIdAttendanceEntry");

                    b.HasIndex("attendanceEntryIdAttendanceEntry");

                    b.ToTable("AttendanceEntryPhysicalClass");
                });

            modelBuilder.Entity("AttendanceEntryStudent", b =>
                {
                    b.Property<long>("AttendanceEntriesIdAttendanceEntry")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentsIdStudent")
                        .HasColumnType("bigint");

                    b.HasKey("AttendanceEntriesIdAttendanceEntry", "StudentsIdStudent");

                    b.HasIndex("StudentsIdStudent");

                    b.ToTable("AttendanceEntryStudent");
                });

            modelBuilder.Entity("Core_3._1.Models.AttendanceEntry", b =>
                {
                    b.Property<long>("IdAttendanceEntry")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CheckAttendance")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCheck")
                        .HasColumnType("datetime2");

                    b.Property<long>("IdPhysicalClass")
                        .HasColumnType("bigint");

                    b.Property<long>("IdStudent")
                        .HasColumnType("bigint");

                    b.HasKey("IdAttendanceEntry");

                    b.ToTable("AttendanceEntry");
                });

            modelBuilder.Entity("Core_3._1.Models.Lecturer", b =>
                {
                    b.Property<long>("IdTeacher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("IdPhysicalClass")
                        .HasColumnType("bigint");

                    b.Property<string>("MailTeacher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameTeacher")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeacherAccount")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTeacher");

                    b.ToTable("Lecturer");
                });

            modelBuilder.Entity("Core_3._1.Models.PhysicalClass", b =>
                {
                    b.Property<long>("IdPhysicalClass")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdAttendanceEntry")
                        .HasColumnType("bigint");

                    b.Property<long>("IdStudent")
                        .HasColumnType("bigint");

                    b.Property<long>("IdTeacher")
                        .HasColumnType("bigint");

                    b.Property<int>("NumberSession")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPhysicalClass");

                    b.ToTable("PhysicalClass");
                });

            modelBuilder.Entity("Core_3._1.Models.Student", b =>
                {
                    b.Property<long>("IdStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("IdAttendanceEntry")
                        .HasColumnType("bigint");

                    b.Property<long>("IdPhysicalClass")
                        .HasColumnType("bigint");

                    b.Property<string>("NameStudent")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("IdStudent");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("LecturerPhysicalClass", b =>
                {
                    b.Property<long>("LecturersIdTeacher")
                        .HasColumnType("bigint");

                    b.Property<long>("PhysicalClassIdPhysicalClass")
                        .HasColumnType("bigint");

                    b.HasKey("LecturersIdTeacher", "PhysicalClassIdPhysicalClass");

                    b.HasIndex("PhysicalClassIdPhysicalClass");

                    b.ToTable("LecturerPhysicalClass");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PhysicalClassStudent", b =>
                {
                    b.Property<long>("PhysicalClassIdPhysicalClass")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentsIdStudent")
                        .HasColumnType("bigint");

                    b.HasKey("PhysicalClassIdPhysicalClass", "StudentsIdStudent");

                    b.HasIndex("StudentsIdStudent");

                    b.ToTable("PhysicalClassStudent");
                });

            modelBuilder.Entity("AttendanceEntryPhysicalClass", b =>
                {
                    b.HasOne("Core_3._1.Models.PhysicalClass", null)
                        .WithMany()
                        .HasForeignKey("PhysicalClassIdPhysicalClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core_3._1.Models.AttendanceEntry", null)
                        .WithMany()
                        .HasForeignKey("attendanceEntryIdAttendanceEntry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AttendanceEntryStudent", b =>
                {
                    b.HasOne("Core_3._1.Models.AttendanceEntry", null)
                        .WithMany()
                        .HasForeignKey("AttendanceEntriesIdAttendanceEntry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core_3._1.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsIdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LecturerPhysicalClass", b =>
                {
                    b.HasOne("Core_3._1.Models.Lecturer", null)
                        .WithMany()
                        .HasForeignKey("LecturersIdTeacher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core_3._1.Models.PhysicalClass", null)
                        .WithMany()
                        .HasForeignKey("PhysicalClassIdPhysicalClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhysicalClassStudent", b =>
                {
                    b.HasOne("Core_3._1.Models.PhysicalClass", null)
                        .WithMany()
                        .HasForeignKey("PhysicalClassIdPhysicalClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core_3._1.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsIdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
