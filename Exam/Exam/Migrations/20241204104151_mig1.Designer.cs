﻿// <auto-generated />
using System;
using Exam.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exam.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241204104151_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exam.Entities.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonId"));

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LessonId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Exam.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Examination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("Examinations");
                });

            modelBuilder.Entity("Examination", b =>
                {
                    b.HasOne("Exam.Entities.Lesson", "Lesson")
                        .WithMany("Examinations")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exam.Entities.Student", "Student")
                        .WithMany("Examinations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Exam.Entities.Lesson", b =>
                {
                    b.Navigation("Examinations");
                });

            modelBuilder.Entity("Exam.Entities.Student", b =>
                {
                    b.Navigation("Examinations");
                });
#pragma warning restore 612, 618
        }
    }
}