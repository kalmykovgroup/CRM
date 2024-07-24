﻿// <auto-generated />
using System;
using CRST_ServerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRST_ServerAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("KTSFClassLibrary.ABAC.ASetOfRules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("a_set_of_rules");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.ComponentAccessAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ASetOfRulesId")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ASetOfRulesId");

                    b.ToTable("component_access_attributes");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.DataBaseAccessAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ASetOfRulesId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAdminsConsent")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("RangeFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RangeTo")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ASetOfRulesId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("database_access_attributes");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.EmployeeAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AdminsСonsent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Agent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NewData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OldData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("employee_actions");
                });

            modelBuilder.Entity("KTSFClassLibrary.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("appointments");
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

                    b.ToTable("companies");
                });

            modelBuilder.Entity("KTSFClassLibrary.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ASetOfRulesId")
                        .HasColumnType("int");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("ApplyingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("EmployeeStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LayoffDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<string>("PassportNumber")
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("PassportSeries")
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Snils")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Tin")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ASetOfRulesId");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("EmployeeStatusId");

                    b.HasIndex("ObjectId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("KTSFClassLibrary.EmployeeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("employee_statuses");
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

                    b.ToTable("objects");
                });

            modelBuilder.Entity("KTSFClassLibrary.PackingList_.PackingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("packing_lists");
                });

            modelBuilder.Entity("KTSFClassLibrary.PackingList_.PackingListToProductJoinTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("PackingListId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PackingListId");

                    b.HasIndex("ProductId", "PackingListId")
                        .IsUnique();

                    b.ToTable("packing_list_to_product_joint_tables");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Article", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("ProductId");

                    b.ToTable("articles");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Barcode", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("ProductId");

                    b.ToTable("barcodes");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("Cost")
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ProductInformationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductInformationId");

                    b.ToTable("prices");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("BuyPrice")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("BuySales")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<ulong?>("OldPrice")
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.ProductInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("Length")
                        .HasColumnType("int");

                    b.Property<string>("NameToPrint")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<double?>("Weight")
                        .HasColumnType("double");

                    b.Property<int?>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("product_informations");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.ProductToCategoryJoinTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId", "CategoryId")
                        .IsUnique();

                    b.ToTable("product_to_category_join_tables");
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

                    b.ToTable("units");
                });

            modelBuilder.Entity("KTSFClassLibrary.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

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

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<string>("Patronymic")
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

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.ComponentAccessAttribute", b =>
                {
                    b.HasOne("KTSFClassLibrary.ABAC.ASetOfRules", "ASetOfRules")
                        .WithMany("ComponentAccessAttributes")
                        .HasForeignKey("ASetOfRulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ASetOfRules");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.DataBaseAccessAttribute", b =>
                {
                    b.HasOne("KTSFClassLibrary.ABAC.ASetOfRules", "ASetOfRules")
                        .WithMany("AccessAttributes")
                        .HasForeignKey("ASetOfRulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("ASetOfRules");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.EmployeeAction", b =>
                {
                    b.HasOne("KTSFClassLibrary.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("KTSFClassLibrary.Company", b =>
                {
                    b.HasOne("KTSFClassLibrary.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KTSFClassLibrary.Employee", b =>
                {
                    b.HasOne("KTSFClassLibrary.ABAC.ASetOfRules", "ASetOfRules")
                        .WithMany()
                        .HasForeignKey("ASetOfRulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.EmployeeStatus", "EmployeeStatus")
                        .WithMany()
                        .HasForeignKey("EmployeeStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.Object", "Object")
                        .WithMany()
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ASetOfRules");

                    b.Navigation("Appointment");

                    b.Navigation("EmployeeStatus");

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

            modelBuilder.Entity("KTSFClassLibrary.PackingList_.PackingList", b =>
                {
                    b.HasOne("KTSFClassLibrary.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("KTSFClassLibrary.PackingList_.PackingListToProductJoinTable", b =>
                {
                    b.HasOne("KTSFClassLibrary.PackingList_.PackingList", "PackingList")
                        .WithMany("PackingListToProductJoinTables")
                        .HasForeignKey("PackingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.Product_.Product", "Product")
                        .WithMany("PackingListToProductJoinTables")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PackingList");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Article", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Product", "Product")
                        .WithMany("Articles")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Barcode", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Product", "Product")
                        .WithMany("Barcodes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
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
                    b.HasOne("KTSFClassLibrary.Product_.ProductInformation", null)
                        .WithMany("PriceHistory")
                        .HasForeignKey("ProductInformationId");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Product", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.ProductInformation", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Product", "Product")
                        .WithOne("ProductInformation")
                        .HasForeignKey("KTSFClassLibrary.Product_.ProductInformation", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.ProductToCategoryJoinTable", b =>
                {
                    b.HasOne("KTSFClassLibrary.Product_.Category", "Category")
                        .WithMany("ProductToCategoryJoinTables")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KTSFClassLibrary.Product_.Product", "Product")
                        .WithMany("ProductToCategoryJoinTables")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KTSFClassLibrary.ABAC.ASetOfRules", b =>
                {
                    b.Navigation("AccessAttributes");

                    b.Navigation("ComponentAccessAttributes");
                });

            modelBuilder.Entity("KTSFClassLibrary.PackingList_.PackingList", b =>
                {
                    b.Navigation("PackingListToProductJoinTables");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Category", b =>
                {
                    b.Navigation("ProductToCategoryJoinTables");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.Product", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Barcodes");

                    b.Navigation("PackingListToProductJoinTables");

                    b.Navigation("ProductInformation");

                    b.Navigation("ProductToCategoryJoinTables");
                });

            modelBuilder.Entity("KTSFClassLibrary.Product_.ProductInformation", b =>
                {
                    b.Navigation("PriceHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
