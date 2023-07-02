﻿// <auto-generated />
using System;
using AppointmentPrj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppointmentPrj.Migrations
{
    [DbContext(typeof(AppointmentContext))]
    [Migration("20230702054138_big")]
    partial class big
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Models.Administration", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Administration");
                });

            modelBuilder.Entity("Library.Models.Appoinments", b =>
                {
                    b.Property<int>("Appoinment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Appoinment_ID"));

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Doctor_ID")
                        .HasColumnType("int");

                    b.Property<int>("Patient_ID")
                        .HasColumnType("int");

                    b.Property<string>("Patient_Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason_of_visit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Treatment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Appoinment_ID");

                    b.HasIndex("Doctor_ID");

                    b.HasIndex("Patient_ID");

                    b.ToTable("Appoinments");
                });

            modelBuilder.Entity("Library.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Constulting_Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Constulting_Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorMobile")
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_Experience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmergencyNo")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Library.Models.Patients", b =>
                {
                    b.Property<int>("Patient_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Patient_ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Patient_Phone")
                        .HasColumnType("bigint");

                    b.Property<string>("Patient_UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Patient_ID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Library.Models.Appoinments", b =>
                {
                    b.HasOne("Library.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("Doctor_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Patients", "Patient")
                        .WithMany()
                        .HasForeignKey("Patient_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Library.Models.Patients", b =>
                {
                    b.HasOne("Library.Models.Doctor", null)
                        .WithMany("Patient")
                        .HasForeignKey("DoctorID");
                });

            modelBuilder.Entity("Library.Models.Doctor", b =>
                {
                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}
