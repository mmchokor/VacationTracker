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
    [Migration("20230310154216_removed foreign from Employee")]
    partial class removedforeignfromEmployee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebRevamp.Models.Approval", b =>
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

            modelBuilder.Entity("WebRevamp.Models.Employee", b =>
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

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebRevamp.Models.VacationRequest", b =>
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

            modelBuilder.Entity("WebRevamp.Models.Approval", b =>
                {
                    b.HasOne("WebRevamp.Models.Employee", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRevamp.Models.VacationRequest", "VacationRequest")
                        .WithMany("Approvals")
                        .HasForeignKey("VacationRequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("VacationRequest");
                });

            modelBuilder.Entity("WebRevamp.Models.VacationRequest", b =>
                {
                    b.HasOne("WebRevamp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRevamp.Models.Employee", "HODApprover")
                        .WithMany()
                        .HasForeignKey("HODApproverId");

                    b.HasOne("WebRevamp.Models.Employee", "OpsApprover")
                        .WithMany()
                        .HasForeignKey("OpsApproverId");

                    b.Navigation("Employee");

                    b.Navigation("HODApprover");

                    b.Navigation("OpsApprover");
                });

            modelBuilder.Entity("WebRevamp.Models.VacationRequest", b =>
                {
                    b.Navigation("Approvals");
                });
#pragma warning restore 612, 618
        }
    }
}
