﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebRevamp.Data;

#nullable disable

namespace WebRevamp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230310110952_tried adding enum to Employee model")]
    partial class triedaddingenumtoEmployeemodel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Approval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ApproverId")
                        .HasColumnType("int");

                    b.Property<int>("VacationRequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("VacationRequestId");

                    b.ToTable("Approvals");
                });

            modelBuilder.Entity("WebApplication1.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApplication1.Models.VacationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HODApprovalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HODApproverId")
                        .HasColumnType("int");

                    b.Property<string>("OpsApprovalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OpsApproverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("HODApproverId");

                    b.HasIndex("OpsApproverId");

                    b.ToTable("VacationRequests");
                });

            modelBuilder.Entity("WebApplication1.Models.Approval", b =>
                {
                    b.HasOne("WebApplication1.Models.Employee", "Approver")
                        .WithMany("Approvals")
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.VacationRequest", "VacationRequest")
                        .WithMany("Approvals")
                        .HasForeignKey("VacationRequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("VacationRequest");
                });

            modelBuilder.Entity("WebApplication1.Models.VacationRequest", b =>
                {
                    b.HasOne("WebApplication1.Models.Employee", "Employee")
                        .WithMany("VacationRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Employee", "HODApprover")
                        .WithMany()
                        .HasForeignKey("HODApproverId");

                    b.HasOne("WebApplication1.Models.Employee", "OpsApprover")
                        .WithMany()
                        .HasForeignKey("OpsApproverId");

                    b.Navigation("Employee");

                    b.Navigation("HODApprover");

                    b.Navigation("OpsApprover");
                });

            modelBuilder.Entity("WebApplication1.Models.Employee", b =>
                {
                    b.Navigation("Approvals");

                    b.Navigation("VacationRequests");
                });

            modelBuilder.Entity("WebApplication1.Models.VacationRequest", b =>
                {
                    b.Navigation("Approvals");
                });
#pragma warning restore 612, 618
        }
    }
}
