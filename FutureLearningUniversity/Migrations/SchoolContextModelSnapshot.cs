﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FutureLearningUniversity.Data;

namespace FutureLearningUniversity.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FutureLearningUniversity.Models.Course", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("Credits");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.CourseAssignment", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("InstructorID");

                    b.HasKey("CourseID", "InstructorID");

                    b.HasIndex("InstructorID");

                    b.ToTable("CourseAssignment");
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("InstructorID");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("DepartmentID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorID");

                    b.Property<string>("Location")
                        .HasMaxLength(50);

                    b.HasKey("InstructorID");

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.Instructor", b =>
                {
                    b.HasBaseType("FutureLearningUniversity.Models.Person");

                    b.Property<DateTime>("HireDate");

                    b.ToTable("Instructor");

                    b.HasDiscriminator().HasValue("Instructor");
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.Student", b =>
                {
                    b.HasBaseType("FutureLearningUniversity.Models.Person");

                    b.Property<DateTime>("EnrollmentDate");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.Course", b =>
                {
                    b.HasOne("FutureLearningUniversity.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.CourseAssignment", b =>
                {
                    b.HasOne("FutureLearningUniversity.Models.Course", "Course")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FutureLearningUniversity.Models.Instructor", "Instructor")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.Department", b =>
                {
                    b.HasOne("FutureLearningUniversity.Models.Instructor", "Administrator")
                        .WithMany()
                        .HasForeignKey("InstructorID");
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.Enrollment", b =>
                {
                    b.HasOne("FutureLearningUniversity.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FutureLearningUniversity.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FutureLearningUniversity.Models.OfficeAssignment", b =>
                {
                    b.HasOne("FutureLearningUniversity.Models.Instructor", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("FutureLearningUniversity.Models.OfficeAssignment", "InstructorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
