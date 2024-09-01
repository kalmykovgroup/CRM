using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KTSF.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "a_set_of_rules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_a_set_of_rules", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categories_categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "categories",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee_statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_statuses", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payment_methods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_methods", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessToken = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Patronymic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "component_access_attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ASetOfRulesId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_component_access_attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_component_access_attributes_a_set_of_rules_ASetOfRulesId",
                        column: x => x.ASetOfRulesId,
                        principalTable: "a_set_of_rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payment_infos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TotalSum = table.Column<double>(type: "double", nullable: false),
                    CashAmount = table.Column<double>(type: "double", nullable: false),
                    CardAmount = table.Column<double>(type: "double", nullable: false),
                    AmountPaid = table.Column<double>(type: "double", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_infos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payment_infos_payment_methods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "payment_methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    BuyPrice = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    SalePrice = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    OldPrice = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_companies_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Discount = table.Column<double>(type: "double", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receipts_payment_infos_PaymentInfoId",
                        column: x => x.PaymentInfoId,
                        principalTable: "payment_infos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Name);
                    table.ForeignKey(
                        name: "FK_articles_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "barcodes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barcodes", x => x.Code);
                    table.ForeignKey(
                        name: "FK_barcodes_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_informations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    NameToPrint = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "double", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_informations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_informations_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_to_category_join_tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_to_category_join_tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_to_category_join_tables_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_to_category_join_tables_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "objects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_objects_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "buy_product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    TotalSumProduct = table.Column<double>(type: "double", nullable: false),
                    Discount = table.Column<double>(type: "double", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buy_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buy_product_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buy_product_receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProductInformationIp = table.Column<int>(type: "int", nullable: false),
                    ProductInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prices_product_informations_ProductInformationId",
                        column: x => x.ProductInformationId,
                        principalTable: "product_informations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    ASetOfRulesId = table.Column<int>(type: "int", nullable: false),
                    AccessToken = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Patronymic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PassportSeries = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true),
                    PassportNumber = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    Tin = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    Snils = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    ApplyingDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LayoffDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    EmployeeStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_a_set_of_rules_ASetOfRulesId",
                        column: x => x.ASetOfRulesId,
                        principalTable: "a_set_of_rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_employee_statuses_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalTable: "employee_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "database_access_attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ASetOfRulesId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false),
                    IsAdminsConsent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    RangeFrom = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RangeTo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_database_access_attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_database_access_attributes_a_set_of_rules_ASetOfRulesId",
                        column: x => x.ASetOfRulesId,
                        principalTable: "a_set_of_rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_database_access_attributes_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee_actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TableName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    OldData = table.Column<string>(type: "longtext", nullable: false),
                    NewData = table.Column<string>(type: "longtext", nullable: false),
                    AdminsСonsent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Ip = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Agent = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_actions_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "packing_lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packing_lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_packing_lists_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "packing_list_to_product_joint_tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PackingListId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packing_list_to_product_joint_tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_packing_list_to_product_joint_tables_packing_lists_PackingLi~",
                        column: x => x.PackingListId,
                        principalTable: "packing_lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_packing_list_to_product_joint_tables_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "a_set_of_rules",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Администратор" },
                    { 2, "", "Старший кассир" },
                    { 3, "", "Менеджер по закупкам" },
                    { 4, "", "Кассир" },
                    { 5, "Установленные дополнительные права доступа на изменение цены для товаров", "Кассир Евгений" },
                    { 6, "", "Бухгалтер" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Администратор" },
                    { 2, "", "Менеджер по закупкам" },
                    { 3, "", "Старший кассир" },
                    { 4, "", "Кассир" },
                    { 5, "", "Бугалтер" },
                    { 6, "", "Охранник" },
                    { 7, "", "Уборщик" },
                    { 8, "", "Водитель" },
                    { 9, "", "Грущик" },
                    { 10, "", "Слесарь" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Одежда", null },
                    { 2, "Дом", null },
                    { 3, "Детям", null },
                    { 4, "Красота", null },
                    { 5, "Электроника", null },
                    { 6, "Продукты", null },
                    { 7, "Инструмент", null }
                });

            migrationBuilder.InsertData(
                table: "employee_statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Не трудоустроен" },
                    { 2, "На испытательном сроке" },
                    { 3, "Трудоустроен" },
                    { 4, "Уволен" }
                });

            migrationBuilder.InsertData(
                table: "units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Шт." },
                    { 2, "Кг." },
                    { 3, "М." }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccessToken", "Email", "EmailConfirmed", "Name", "PasswordHash", "Patronymic", "PhoneNumber", "PhoneNumberConfirmed", "Surname" },
                values: new object[] { 1, "", "tester@mail.ru", false, "tester", "$2a$11$2aqUw79oY8LEgBBSgbGBWOawq.sT9GAWkx/w1z0mq3CcgOYm0SZha", "testerovich", "+7111111111", false, "testerov" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 8, "Электроинструмент", 7 },
                    { 9, "Перфораторы", 7 }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 1, "My company name", 1 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "BuyPrice", "Name", "OldPrice", "SalePrice", "UnitId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 200ul, "Пассатижи", 560ul, 450ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2923) },
                    { 2, 1109ul, "Набор профессиональных отверток и бит DEKO SS100 с удобной подставкой (100 предметов)", 2750ul, 2409ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2926) },
                    { 3, 1600ul, "Набор слесарного инстр-та в чем. 72пр. Волат (1/4\", 1/2\", 6 граней) (18530-72) (18530-72)", 6700ul, 4932ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2927) },
                    { 4, 1600ul, "Дрель-шуруповерт с набором инструмента TOTAL THKTHP11282 (с 1-им АКБ, кейс, 128 предметов)", 6700ul, 4932ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2929) },
                    { 5, 500ul, "Клещи (пресс-клещи) для обжима наконечников электропроводов с сечением 0.25-8 мм2 Gross", 2200ul, 1883ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2931) },
                    { 6, 116268ul, "Смартфон Samsung Galaxy Z Fold6 12/256 ГБ, Dual: nano SIM + eSIM, серебристый", 220268ul, 176268ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2932) },
                    { 7, 10400ul, "Перфоратор SDS+ 2.7Дж - 780Вт Makita HR2470", 18900ul, 16460ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2934) },
                    { 8, 205ul, "Комбинированные плоскогубцы Gigant 180 мм GCP 180", 590ul, 480ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2936) },
                    { 9, 320ul, "Диэлектрические пассатижи SHTOK 1000В 180 мм", 730ul, 650ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2937) },
                    { 10, 130ul, "Мини пассатижи SHTOK 120 мм", 420ul, 350ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2939) },
                    { 11, 460ul, "Никелированные пассатижи Inforce 200мм", 910ul, 900ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2941) },
                    { 12, 1560ul, "Комплект насадок с ключом-трещоткой (26 предметов) Bosch", 2050ul, 2100ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2942) },
                    { 13, 17200ul, "Набор торцевых головок SAE 3/4", 25300ul, 26500ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2944) },
                    { 14, 3620ul, "Набор инструментов STARTUL 1/4 , 1/2 6 граней 108 предметов PRO Stuttgart PRO-108S", 6200ul, 6950ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2946) },
                    { 15, 52900ul, "Набор трещоток 8100 SC 2 Zyklop 1/2 Wera WE-003645", 72630ul, 75550ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2947) },
                    { 16, 16530ul, "Раскладной ящик с инструментами для механиков IZELTAS металлический, 63 предмета, 190х420х200", 24200ul, 25800ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2949) },
                    { 17, 8630ul, "Перфоратор Ресанта П-32-1400КВ 75/3/6", 10800ul, 10700ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2951) },
                    { 18, 12100ul, "Набор двенадцатигранных торцевых головок IZELTAS 24 предмета 1114006024", 15650ul, 16200ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2952) },
                    { 19, 24500ul, "Бесщеточная дрель-шуруповерт Dewalt 18.0 В XR DCD7771D2", 30120ul, 29900ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2954) },
                    { 20, 6350ul, "Аккумуляторная дрель-шуруповерт Makita DF333DWYE", 10800ul, 10900ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2955) },
                    { 21, 17350ul, "Аккумуляторная дрель-шуруповерт Makita LXT DDF453RFE", 21700ul, 22490ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2957) },
                    { 22, 3210ul, "Дрель Makita DF0300", 6500ul, 6490ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2958) },
                    { 23, 11750ul, "Аккумуляторная бесщеточная ударная дрель-шуруповерт Bosch GSB 12V-30 06019G9120", 16240ul, 17240ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2960) },
                    { 24, 17640ul, "Перфоратор Makita HR 2810", 28750ul, 29990ul, 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2962) }
                });

            migrationBuilder.InsertData(
                table: "articles",
                columns: new[] { "Name", "Id", "ProductId" },
                values: new object[,]
                {
                    { "article_1", 1, 1 },
                    { "article_10", 13, 10 },
                    { "article_11", 14, 11 },
                    { "article_12", 15, 12 },
                    { "article_13", 16, 13 },
                    { "article_14", 17, 14 },
                    { "article_15", 18, 15 },
                    { "article_16", 19, 16 },
                    { "article_17", 20, 17 },
                    { "article_18", 21, 18 },
                    { "article_19", 22, 19 },
                    { "article_2", 2, 2 },
                    { "article_2.1", 3, 2 },
                    { "article_20", 23, 20 },
                    { "article_21", 24, 21 },
                    { "article_22", 25, 22 },
                    { "article_23", 26, 23 },
                    { "article_24", 27, 24 },
                    { "article_3", 4, 3 },
                    { "article_4", 5, 4 },
                    { "article_4.1", 6, 4 },
                    { "article_4.2", 7, 4 },
                    { "article_5", 8, 5 },
                    { "article_6", 9, 6 },
                    { "article_7", 10, 7 },
                    { "article_8", 11, 8 },
                    { "article_9", 12, 9 }
                });

            migrationBuilder.InsertData(
                table: "barcodes",
                columns: new[] { "Code", "Id", "ProductId", "Type" },
                values: new object[,]
                {
                    { "barcode_1", 1, 1, 31 },
                    { "barcode_10", 11, 10, 31 },
                    { "barcode_11", 12, 11, 31 },
                    { "barcode_12", 13, 12, 31 },
                    { "barcode_13", 14, 13, 31 },
                    { "barcode_14", 15, 14, 31 },
                    { "barcode_15", 16, 15, 31 },
                    { "barcode_16", 17, 16, 31 },
                    { "barcode_17", 18, 17, 31 },
                    { "barcode_18", 19, 18, 31 },
                    { "barcode_19", 20, 19, 31 },
                    { "barcode_2", 2, 2, 31 },
                    { "barcode_20", 21, 20, 31 },
                    { "barcode_21", 22, 21, 31 },
                    { "barcode_22", 23, 22, 31 },
                    { "barcode_23", 24, 23, 31 },
                    { "barcode_24", 25, 24, 31 },
                    { "barcode_3", 3, 3, 31 },
                    { "barcode_4", 4, 4, 31 },
                    { "barcode_5", 5, 5, 31 },
                    { "barcode_6", 6, 6, 31 },
                    { "barcode_7", 7, 7, 31 },
                    { "barcode_7.1", 8, 7, 31 },
                    { "barcode_8", 9, 8, 31 },
                    { "barcode_9", 10, 9, 31 }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 10, "Makita", 9 });

            migrationBuilder.InsertData(
                table: "objects",
                columns: new[] { "Id", "Address", "CompanyId", "Name" },
                values: new object[] { 1, "ул. Новый Арбат, 15", 1, "Продуктовый на Арбате" });

            migrationBuilder.InsertData(
                table: "product_informations",
                columns: new[] { "Id", "CreatedAt", "Description", "Height", "Length", "NameToPrint", "ProductId", "UpdatedAt", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3020), "Пассатижи эконом класса", 25, 50, "Пассатижи", 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3021), 0.10000000000000001, 150 },
                    { 2, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3023), "Набор профессиональных отверток и бит DEKO SS100 с удобной подставкой (100 предметов).", 315, 143, "Набор проф. отверток DEKO SS100", 2, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3023), 2.75, 275 },
                    { 3, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3025), "Набор инструментов 1/4\", 1/2\" 6 граней 72 предмета волат (18530-72) - многофункциональный набор предназначен для ремонта и обслуживания автомобиля, а также для выполнения других слесарных работ. Рабочие части изготовлены из инструментальной стали. Покрытие сатинированное. Профиль головок шестигранный. Кейс из прочного противоударного пластика, с металлическими замками.", 300, 70, "Набор слесарного инстр-та 72пр.", 3, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3025), 7.3799999999999999, 300 },
                    { 4, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3027), "Комплектация набора подобрана так, что домашний мастер закроет все бытовые вопросы, связанные с ремонтом и благоустройством, сборкой/разборкой мебели, монтажа/демонтажа", 300, 70, "Дрель-шуруповерт (с 1-им АКБ, кейс, 128 предметов)", 4, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3027), 1.3, 300 },
                    { 5, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3029), "Пресс-клещи Gross 17724 используются для обжима наконечников электропроводов с сечением 0,25-8 м2. Позволяют добиться качественного соединения проводов при подключении бытовых приборов и электрооборудования. Клещи с автозажимом значительно повышают скорость работы, пригодятся в быту и профессиональной сфере. Преимущества 6-ступенчатая регулировка усилия сжатия позволяет выбрать оптимальный режим для работы с различными проводами. Двухкомпонентные рельефные рукоятки повышают удобство работы, обеспечивая надежный хват без риска проскальзывания инструмента. За счет функции авторазжима не нужно прикладывать усилия для раскрытия рабочих частей. Клещи упакованы в слайд карту для практичного хранения и транспортировк", 180, 3, "Клещи Gross", 5, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3030), 0.29999999999999999, 100 },
                    { 6, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3031), "Сверхлегкий, тонкий дизайн\r\nТоньше и легче, идеально ложится в карман, и с еще более ярким раскрывающимся экраном, от которого захватывает дух.\r\nСамый простой способ составить сводку в заметках на складных Galaxy\r\nЗаметки со встреч и лекций всего в несколько касаний, даже в условиях многозадачности. Ассистент для заметок превращает записи в текст и организует их в заметки, создавая удобные сводки. Для всего остального пользуйтесь электронным пером пером S Pen, которое на большом экране способно творить чудеса.", 135, 10, "Смартфон Samsung Galaxy Z Fold6 12/256 ГБ, Dual: nano SIM + eSIM, серебристый", 6, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3032), 0.17999999999999999, 150 },
                    { 7, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3034), "Три режима работы (сверление, сверление с ударом, долбление). Расцепляющая муфта для защиты инструмента и оператора при заклинивании. 40 осевых положений зубила для удобства эксплуатации. Спусковая кнопка с переменной скоростью.", 214, 370, "Перфоратор Makita HR2470", 7, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3034), 2.8999999999999999, 84 },
                    { 8, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3036), "Комбинированные плоскогубцы Gigant 180 мм GCP 180", 214, 370, "Комб. плоскогубцы Gigant 180 мм", 8, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3036), 2.8999999999999999, 84 },
                    { 9, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3038), "Диэлектрические пассатижи SHTOK 1000В 180 мм", 214, 370, "Диэлект. пассатижи SHTOK 1000В 180 мм", 9, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3038), 2.8999999999999999, 84 },
                    { 10, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3041), "Мини пассатижи SHTOK 120 мм", 214, 370, "Мини пассатижи SHTOK 120 мм", 10, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3041), 2.8999999999999999, 84 },
                    { 11, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3043), "Никелированные пассатижи Inforce 200мм", 214, 370, "Никелиров. пассатижи Inforce 200мм", 11, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3043), 2.8999999999999999, 84 },
                    { 12, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3045), "Комплект насадок с ключом-трещоткой (26 предметов) Bosch", 214, 370, "Комп. насадок с кл.трещоткой Bosch", 12, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3045), 2.8999999999999999, 84 },
                    { 13, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3047), "Набор торцевых головок SAE 3/4", 214, 370, "Набор торц. головок SAE 3/4", 13, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3047), 2.8999999999999999, 84 },
                    { 14, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3049), "Набор инструментов STARTUL 1/4 , 1/2 6 граней 108 предметов PRO Stuttgart PRO-108S", 214, 370, "Наб. инстр. STARTUL 108 пред.", 14, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3049), 2.8999999999999999, 84 },
                    { 15, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3051), "Набор трещоток 8100 SC 2 Zyklop 1/2 Wera WE-003645", 214, 370, "Наб. трещоток Zyklop", 15, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3051), 2.8999999999999999, 84 },
                    { 16, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3053), "Раскладной ящик с инструментами для механиков IZELTAS металлический, 63 предмета, 190х420х200", 214, 370, "Раскл. ящик с инстр. IZELTAS метал.", 16, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3053), 2.8999999999999999, 84 },
                    { 17, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3055), "Перфоратор Ресанта П-32-1400КВ 75/3/6", 214, 370, "Перфоратор Ресанта П-32", 17, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3055), 2.8999999999999999, 84 },
                    { 18, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3057), "Набор двенадцатигранных торцевых головок IZELTAS 24 предмета 1114006024", 214, 370, "Наб. головок IZELTAS", 18, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3057), 2.8999999999999999, 84 },
                    { 19, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3059), "Бесщеточная дрель-шуруповерт Dewalt 18.0 В XR DCD7771D2", 214, 370, "Бесщет. дрель-шуруповерт Dewalt", 19, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3059), 2.8999999999999999, 84 },
                    { 20, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3061), "Аккумуляторная дрель-шуруповерт Makita DF333DWYE", 214, 370, "Аккум. дрель-шуруповерт Makita DF333DWYE", 20, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3061), 2.8999999999999999, 84 },
                    { 21, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3063), "Аккумуляторная дрель-шуруповерт Makita LXT DDF453RFE", 214, 370, "Аккум. дрель-шуруповерт Makita LXT DDF453RFE", 21, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3063), 2.8999999999999999, 84 },
                    { 22, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3065), "Дрель Makita DF0300", 214, 370, "Дрель Makita DF0300", 22, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3065), 2.8999999999999999, 84 },
                    { 23, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3067), "Аккумуляторная бесщеточная ударная дрель-шуруповерт Bosch GSB 12V-30 06019G9120", 214, 370, "Аккум. бесщет. ударная дрель-шуруповерт Bosch", 23, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3067), 2.8999999999999999, 84 },
                    { 24, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3069), "Перфоратор Makita HR 2810", 214, 370, "Перфоратор Makita HR 2810", 24, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(3069), 2.8999999999999999, 84 }
                });

            migrationBuilder.InsertData(
                table: "product_to_category_join_tables",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 7, 1 },
                    { 2, 7, 2 },
                    { 3, 7, 3 },
                    { 4, 7, 4 },
                    { 5, 7, 5 },
                    { 6, 7, 7 }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "ASetOfRulesId", "AccessToken", "Address", "ApplyingDate", "AppointmentId", "Created_At", "Email", "EmployeeStatusId", "LayoffDate", "Name", "ObjectId", "PassportNumber", "PassportSeries", "Password", "Patronymic", "Phone", "Snils", "Surname", "Tin", "Updated_At" },
                values: new object[,]
                {
                    { 1, 1, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEifQ.GQm1j57RyZMHdwsolLnzhoB9A49mC0KusQBpHS9_-kQ", "Красная площадь 4", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2791), 1, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2807), "admin@mail.ru", 3, null, "Иван", 1, "123456", "1234", "tester", "Алексеевич", "+79260128187", "123456789012", "Калмыков", "12345678901", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2808) },
                    { 2, 2, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIifQ.cbpuaPB0oVEkmkgFvfQUcaRb58xRn5zlClDroWd75JA", "Арбатская 6", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2810), 2, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2811), "admin2@mail.ru", 3, null, "Артур", 1, "123456", "1234", "tester", "Игоревич", "+79260125434", "123456789012", "Соколов", "12345678901", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2811) },
                    { 3, 3, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjMifQ.n0AxopvGMqJUdvyuXVuBZOurMD2Tiah-EqFi-a-lR6E", "Шевченко 4", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2813), 6, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2814), "admin3@mail.ru", 3, null, "Александр", 1, "123456", "1234", "tester", "Владимирович", "+79267654356", "123456789012", "Трунин", "12345678901", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2814) },
                    { 4, 4, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQifQ.NiQnkH09RTP1QMiS9rbWLQ3iDJbZ2CV3RsBflk5QjXs", "Ново Павловка 16/3", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2816), 3, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2817), "admin4@mail.ru", 3, null, "Алексей", 1, "123456", "1234", "tester", "Александрович", "+79266455553", "123456789012", "Федосов", "12345678901", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2817) },
                    { 5, 5, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjUifQ.t9QlQfK-k6WS2yA2KlKgn0JRCQhDaz5Ujo8UBVTJWCM", "Дальний восток 13/3", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2819), 4, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2819), "admin5@mail.ru", 2, null, "Ансар", 1, "123456", "1234", "tester", "Нуруллович", "+79266726545", "123456789012", "Агадуллин", "12345678901", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2820) },
                    { 6, 4, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjUifQ.t9QlQfK-k6WS2yA2KlKgn0JRCQhDaz5Ujo8UBVTJWCM", "Hell street 66/6", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2822), 5, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2822), "merlin@mail.ru", 4, null, "Мерлин", 1, "123456", "1234", "tester", "Витальевич", "+79266726545", "123456789012", "Мэнсон", "12345678901", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2823) },
                    { 7, 4, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjUifQ.t9QlQfK-k6WS2yA2KlKgn0JRCQhDaz5Ujo8UBVTJWCM", "Hell street 66/6", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2825), 6, new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2825), "prohor@mail.ru", 1, null, "Прохор", 1, "123456", "1234", "tester", "Иванович", "+79266726545", "123456789012", "Шаляпин", "12345678901", new DateTime(2024, 9, 1, 15, 38, 58, 162, DateTimeKind.Local).AddTicks(2826) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_ProductId",
                table: "articles",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_barcodes_ProductId",
                table: "barcodes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_buy_product_ProductId",
                table: "buy_product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_buy_product_ReceiptId",
                table: "buy_product",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_ParentId",
                table: "categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_companies_UserId",
                table: "companies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_component_access_attributes_ASetOfRulesId",
                table: "component_access_attributes",
                column: "ASetOfRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_database_access_attributes_ASetOfRulesId",
                table: "database_access_attributes",
                column: "ASetOfRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_database_access_attributes_EmployeeId",
                table: "database_access_attributes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_actions_EmployeeId",
                table: "employee_actions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_AppointmentId",
                table: "employees",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_ASetOfRulesId",
                table: "employees",
                column: "ASetOfRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_EmployeeStatusId",
                table: "employees",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_ObjectId",
                table: "employees",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_objects_CompanyId",
                table: "objects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_packing_list_to_product_joint_tables_PackingListId",
                table: "packing_list_to_product_joint_tables",
                column: "PackingListId");

            migrationBuilder.CreateIndex(
                name: "IX_packing_list_to_product_joint_tables_ProductId_PackingListId",
                table: "packing_list_to_product_joint_tables",
                columns: new[] { "ProductId", "PackingListId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_packing_lists_EmployeeId",
                table: "packing_lists",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_payment_infos_PaymentMethodId",
                table: "payment_infos",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_prices_ProductInformationId",
                table: "prices",
                column: "ProductInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_product_informations_ProductId",
                table: "product_informations",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_to_category_join_tables_CategoryId",
                table: "product_to_category_join_tables",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_to_category_join_tables_ProductId_CategoryId",
                table: "product_to_category_join_tables",
                columns: new[] { "ProductId", "CategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_UnitId",
                table: "products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_PaymentInfoId",
                table: "receipts",
                column: "PaymentInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "barcodes");

            migrationBuilder.DropTable(
                name: "buy_product");

            migrationBuilder.DropTable(
                name: "component_access_attributes");

            migrationBuilder.DropTable(
                name: "database_access_attributes");

            migrationBuilder.DropTable(
                name: "employee_actions");

            migrationBuilder.DropTable(
                name: "packing_list_to_product_joint_tables");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "product_to_category_join_tables");

            migrationBuilder.DropTable(
                name: "receipts");

            migrationBuilder.DropTable(
                name: "packing_lists");

            migrationBuilder.DropTable(
                name: "product_informations");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "payment_infos");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "payment_methods");

            migrationBuilder.DropTable(
                name: "a_set_of_rules");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "employee_statuses");

            migrationBuilder.DropTable(
                name: "objects");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
