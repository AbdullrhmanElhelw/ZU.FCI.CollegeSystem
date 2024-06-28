﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZU.FCI.CollegeSystem.DataAccess.Data;

#nullable disable

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Migrations
{
    [DbContext(typeof(CollegeSystemDbContext))]
    partial class CollegeSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

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

                    b.ToTable("AspNetUsers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssistantId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("CourseImageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssistantId");

                    b.HasIndex("CourseImageId")
                        .IsUnique()
                        .HasFilter("[CourseImageId] IS NOT NULL");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.DoctorCourses.DoctorCourse", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("DoctorCourses", (string)null);
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lectures", (string)null);
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Sections", (string)null);
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.StudentCourses.StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses", (string)null);
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.BaseFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Files", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Assistants.Assistant", b =>
                {
                    b.HasBaseType("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Assistants", (string)null);
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors.Doctor", b =>
                {
                    b.HasBaseType("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students.Student", b =>
                {
                    b.HasBaseType("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("ProfilePictureId")
                        .HasColumnType("int");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ProfilePictureId")
                        .IsUnique()
                        .HasFilter("[ProfilePictureId] IS NOT NULL");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.CourseImage", b =>
                {
                    b.HasBaseType("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.BaseFile");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.ToTable("CourseImages");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles.LectureFile", b =>
                {
                    b.HasBaseType("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.BaseFile");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DoctorId");

                    b.HasIndex("LectureId");

                    b.ToTable("LectureFiles");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.ProfilePicture", b =>
                {
                    b.HasBaseType("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.BaseFile");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.ToTable("ProfilePictures");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.SectionFile", b =>
                {
                    b.HasBaseType("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.BaseFile");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("SectionId");

                    b.ToTable("SectionFiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Course", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Assistants.Assistant", "Assistant")
                        .WithMany("Courses")
                        .HasForeignKey("AssistantId");

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.CourseImage", "CourseImage")
                        .WithOne("Course")
                        .HasForeignKey("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Course", "CourseImageId");

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Assistant");

                    b.Navigation("CourseImage");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.DoctorCourses.DoctorCourse", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Course", "Course")
                        .WithMany("DoctorCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors.Doctor", "Doctor")
                        .WithMany("DoctorCourses")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Lecture", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Course", "Course")
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Section", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Course", "Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.StudentCourses.StudentCourse", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Assistants.Assistant", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Department", "Department")
                        .WithMany("Assistants")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Assistants.Assistant", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors.Doctor", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students.Student", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Common.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.ProfilePicture", "ProfilePicture")
                        .WithOne("Student")
                        .HasForeignKey("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students.Student", "ProfilePictureId");

                    b.Navigation("Department");

                    b.Navigation("ProfilePicture");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.CourseImage", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.BaseFile", null)
                        .WithOne()
                        .HasForeignKey("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.CourseImage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles.LectureFile", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors.Doctor", "Doctor")
                        .WithMany("LectureFiles")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.BaseFile", null)
                        .WithOne()
                        .HasForeignKey("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles.LectureFile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Lecture", "Lecture")
                        .WithMany("LectureFiles")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.ProfilePicture", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.BaseFile", null)
                        .WithOne()
                        .HasForeignKey("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.ProfilePicture", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.SectionFile", b =>
                {
                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.BaseFile", null)
                        .WithOne()
                        .HasForeignKey("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.SectionFile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Section", "Section")
                        .WithMany("SectionFiles")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Course", b =>
                {
                    b.Navigation("DoctorCourses");

                    b.Navigation("Lectures");

                    b.Navigation("Sections");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Department", b =>
                {
                    b.Navigation("Assistants");

                    b.Navigation("Courses");

                    b.Navigation("Doctors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Lecture", b =>
                {
                    b.Navigation("LectureFiles");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Section", b =>
                {
                    b.Navigation("SectionFiles");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Assistants.Assistant", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors.Doctor", b =>
                {
                    b.Navigation("DoctorCourses");

                    b.Navigation("LectureFiles");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.CourseImage", b =>
                {
                    b.Navigation("Course")
                        .IsRequired();
                });

            modelBuilder.Entity("ZU.FCI.CollegeSystem.DataAccess.Entites.Files.ProfilePicture", b =>
                {
                    b.Navigation("Student")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
