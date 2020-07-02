﻿// <auto-generated />
using System;
using CharlieBackend.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CharlieBackend.Api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CharlieBackend.Core.Entities.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<sbyte?>("Role")
                        .HasColumnType("tinyint");

                    b.Property<string>("Salt")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Lesson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LessonDate")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("MentorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudentGroupId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ThemeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.HasIndex("StudentGroupId");

                    b.HasIndex("ThemeId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Mentor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.MentorOfCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("MentorComment")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("MentorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("MentorId");

                    b.ToTable("Mentorsofcourses");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.MentorOfStudentGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Comments")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("MentorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudentGroupId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.HasIndex("StudentGroupId");

                    b.ToTable("Mentorsofstudentgroups");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.StudentGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Studentgroups");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.StudentsOfGroups", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("StudentGroupId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudentGroupId");

                    b.HasIndex("StudentId");

                    b.ToTable("Studentsofgroups");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Theme", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Visit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Comments")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Presence")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<sbyte?>("StudentMark")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Lesson", b =>
                {
                    b.HasOne("CharlieBackend.Core.Entities.Mentor", "Mentor")
                        .WithMany("Lessons")
                        .HasForeignKey("MentorId");

                    b.HasOne("CharlieBackend.Core.Entities.StudentGroup", "StudentGroup")
                        .WithMany("Lessons")
                        .HasForeignKey("StudentGroupId");

                    b.HasOne("CharlieBackend.Core.Entities.Theme", "Theme")
                        .WithMany("Lessons")
                        .HasForeignKey("ThemeId");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Mentor", b =>
                {
                    b.HasOne("CharlieBackend.Core.Entities.Account", "Account")
                        .WithMany("Mentors")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.MentorOfCourse", b =>
                {
                    b.HasOne("CharlieBackend.Core.Entities.Course", "Course")
                        .WithMany("MentorsOfCourses")
                        .HasForeignKey("CourseId");

                    b.HasOne("CharlieBackend.Core.Entities.Mentor", "Mentor")
                        .WithMany("MentorsOfCourses")
                        .HasForeignKey("MentorId");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.MentorOfStudentGroup", b =>
                {
                    b.HasOne("CharlieBackend.Core.Entities.Mentor", "Mentor")
                        .WithMany("MentorsOfStudentGroups")
                        .HasForeignKey("MentorId");

                    b.HasOne("CharlieBackend.Core.Entities.StudentGroup", "StudentGroup")
                        .WithMany("MentorsOfStudentGroups")
                        .HasForeignKey("StudentGroupId");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Student", b =>
                {
                    b.HasOne("CharlieBackend.Core.Entities.Account", "Account")
                        .WithMany("Students")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.StudentGroup", b =>
                {
                    b.HasOne("CharlieBackend.Core.Entities.Course", "Course")
                        .WithMany("StudentGroups")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.StudentsOfGroups", b =>
                {
                    b.HasOne("CharlieBackend.Core.Entities.StudentGroup", "StudentGroup")
                        .WithMany("StudentsOfGroups")
                        .HasForeignKey("StudentGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CharlieBackend.Core.Entities.Student", "Student")
                        .WithMany("StudentsOfGroups")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharlieBackend.Core.Entities.Visit", b =>
                {
                    b.HasOne("CharlieBackend.Core.Entities.Lesson", "Lesson")
                        .WithMany("Visits")
                        .HasForeignKey("LessonId");

                    b.HasOne("CharlieBackend.Core.Entities.Student", "Student")
                        .WithMany("Visits")
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}
