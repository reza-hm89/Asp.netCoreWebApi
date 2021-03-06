﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProjectTest.Data;
using System;

namespace ProjectTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectTest.Models.Building", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("SchoolID");

                    b.HasKey("ID");

                    b.HasIndex("SchoolID");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("ProjectTest.Models.ClassRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingID");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("RoomNO")
                        .HasMaxLength(10);

                    b.Property<int>("TeacherID");

                    b.HasKey("ID");

                    b.HasIndex("BuildingID");

                    b.HasIndex("TeacherID");

                    b.ToTable("ClassRoom");
                });

            modelBuilder.Entity("ProjectTest.Models.Grade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassRoomID");

                    b.Property<float>("GPA");

                    b.Property<int>("StudentID");

                    b.HasKey("ID");

                    b.HasIndex("ClassRoomID");

                    b.HasIndex("StudentID");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("ProjectTest.Models.School", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("School");
                });

            modelBuilder.Entity("ProjectTest.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Age");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("SurName")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ProjectTest.Models.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("ProjectTest.Models.Building", b =>
                {
                    b.HasOne("ProjectTest.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectTest.Models.ClassRoom", b =>
                {
                    b.HasOne("ProjectTest.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectTest.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectTest.Models.Grade", b =>
                {
                    b.HasOne("ProjectTest.Models.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectTest.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
