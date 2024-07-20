﻿// <auto-generated />
using System;
using CRST_ServerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRST_ServerAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240720121721_initial data")]
    partial class initialdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("KTSFClassLibrary.ABAC.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("appointment");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.ComponentAccessAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("component_access_attribute");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.DataBaseAccessAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<int>("DataBaseActionId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdminsСonsent")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("RangeFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RangeTo")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("DataBaseActionId");

                    b.ToTable("database_access_attribute");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.DataBaseAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("database_action");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.EmployeeAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AdminsСonsent")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NewData")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OldData")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("employee_action");
                });

            modelBuilder.Entity("KTSFClassLibrary.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("company");
                });

            modelBuilder.Entity("KTSFClassLibrary.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ApplyingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LayoffDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<int?>("PassportNumber")
                        .HasColumnType("int");

                    b.Property<int?>("PassportSeries")
                        .HasColumnType("int");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Snils")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Tin")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ObjectId");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("KTSFClassLibrary.Object", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("object");
                });

            modelBuilder.Entity("KTSFClassLibrary.PackingList_.PackingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("packing_list");
                });

            modelBuilder.Entity("KTSFClassLibrary.PackingList_.PackingListProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PackingListId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PackingListId");

                    b.HasIndex("ProductId");

                    b.ToTable("packing_list_product");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("article");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Barcode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("barcode");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("category");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("group");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("price");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BuyPrice")
                        .HasColumnType("int");

                    b.Property<int>("BuySales")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NameToPrint")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("OldPrice")
                        .HasColumnType("int");

                    b.Property<int?>("PackingListId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.Property<int?>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("PackingListId");

                    b.HasIndex("UnitId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("unit");
                });

            modelBuilder.Entity("KTSFClassLibrary.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Patronimyc")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.ComponentAccessAttribute", b =>
                {
                    b.HasOne("KTSFClassLibrary.ABAC.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.DataBaseAccessAttribute", b =>
                {
                    b.HasOne("KTSFClassLibrary.ABAC.Appointment", "Appointment")
                        .WithMany("AccessAttibutes")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.ABAC.DataBaseAction", "DataBaseAction")
                        .WithMany()
                        .HasForeignKey("DataBaseActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("DataBaseAction");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.EmployeeAction", b =>
                {
                    b.HasOne("KTSFClassLibrary.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("KTSFClassLibrary.Company", b =>
                {
                    b.HasOne("KTSFClassLibrary.Employee", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KTSFClassLibrary.Employee", b =>
                {
                    b.HasOne("KTSFClassLibrary.ABAC.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.Object", "Object")
                        .WithMany()
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Object");
                });

            modelBuilder.Entity("KTSFClassLibrary.Object", b =>
                {
                    b.HasOne("KTSFClassLibrary.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("KTSFClassLibrary.PackingList_.PackingListProduct", b =>
                {
                    b.HasOne("KTSFClassLibrary.PackingList_.PackingList", "PackingList")
                        .WithMany()
                        .HasForeignKey("PackingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.Product_.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PackingList");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Article", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Product", null)
                        .WithMany("Articles")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Barcode", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Product", null)
                        .WithMany("Barcodes")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Category", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Price", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Product", null)
                        .WithMany("PriceHistory")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Product", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.PackingList_.PackingList", null)
                        .WithMany("Products")
                        .HasForeignKey("PackingListId");

                    b.HasOne("KTSFClassLibrary.Product_.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.Appointment", b =>
                {
                    b.Navigation("AccessAttibutes");
                });

            modelBuilder.Entity("KTSFClassLibrary.PackingList_.PackingList", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Product", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Barcodes");

                    b.Navigation("PriceHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
