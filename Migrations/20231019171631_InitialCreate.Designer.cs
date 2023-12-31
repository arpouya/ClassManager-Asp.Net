﻿// <auto-generated />
using System;
using ClassManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassManager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231019171631_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("ClassManager.Models.Classes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Classname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Studentsnumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Teachername")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("ClassManager.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassesId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataReport")
                        .HasColumnType("TEXT");

                    b.Property<int>("Point")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClassesId");

                    b.HasIndex("StudentsId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("ClassManager.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fathername")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ClassesStudents", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClassesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ClassesStudents");
                });

            modelBuilder.Entity("ClassManager.Models.Report", b =>
                {
                    b.HasOne("ClassManager.Models.Classes", "Classes")
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassManager.Models.Students", "Students")
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classes");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ClassesStudents", b =>
                {
                    b.HasOne("ClassManager.Models.Classes", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassManager.Models.Students", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
