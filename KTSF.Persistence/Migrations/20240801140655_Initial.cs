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
                    Phone = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
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
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    BuyPrice = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    BuySales = table.Column<ulong>(type: "bigint unsigned", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barcodes", x => x.Id);
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
                name: "prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProductInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prices_product_informations_ProductInformationId",
                        column: x => x.ProductInformationId,
                        principalTable: "product_informations",
                        principalColumn: "Id");
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
                columns: new[] { "Id", "AccessToken", "Email", "Name", "PasswordHash", "Patronymic", "PhoneNumber", "Surname" },
                values: new object[] { 1, "bgUYGBvkuybjkyGJGVjhyvbjyuBKYJ", "tester@mail.ru", "tester", "tester", "testerovich", "+7111111111", "testerov" });

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
                columns: new[] { "Id", "BuyPrice", "BuySales", "Name", "OldPrice", "UnitId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 200ul, 450ul, "Пассатижи", 560ul, 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9605) },
                    { 2, 1109ul, 2409ul, "Набор профессиональных отверток и бит DEKO SS100 с удобной подставкой (100 предметов)", 2750ul, 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9609) },
                    { 3, 1600ul, 4932ul, "Набор слесарного инстр-та в чем. 72пр. Волат (1/4\", 1/2\", 6 граней) (18530-72) (18530-72)", 6700ul, 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9611) },
                    { 4, 1600ul, 4932ul, "Дрель-шуруповерт с набором инструмента TOTAL THKTHP11282 (с 1-им АКБ, кейс, 128 предметов)", 6700ul, 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9613) },
                    { 5, 500ul, 1883ul, "Клещи (пресс-клещи) для обжима наконечников электропроводов с сечением 0.25-8 мм2 Gross", 2200ul, 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9615) },
                    { 6, 116268ul, 176268ul, "Смартфон Samsung Galaxy Z Fold6 12/256 ГБ, Dual: nano SIM + eSIM, серебристый", 220268ul, 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9617) },
                    { 7, 10400ul, 16460ul, "Перфоратор SDS+ 2.7Дж - 780Вт Makita HR2470", 18900ul, 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9619) }
                });

            migrationBuilder.InsertData(
                table: "articles",
                columns: new[] { "Name", "Id", "ProductId" },
                values: new object[,]
                {
                    { "article_1", 1, 1 },
                    { "article_2", 2, 2 },
                    { "article_2.1", 3, 2 },
                    { "article_3", 4, 3 },
                    { "article_4", 5, 4 },
                    { "article_4.1", 6, 4 },
                    { "article_4.2", 7, 4 },
                    { "article_5", 8, 5 },
                    { "article_6", 9, 6 },
                    { "article_7", 10, 7 }
                });

            migrationBuilder.InsertData(
                table: "barcodes",
                columns: new[] { "Id", "Code", "ProductId", "Type" },
                values: new object[,]
                {
                    { 1, "barcode_1", 1, 31 },
                    { 2, "barcode_2", 2, 31 },
                    { 3, "barcode_3", 3, 31 },
                    { 4, "barcode_4", 4, 31 },
                    { 5, "barcode_5", 5, 31 },
                    { 6, "barcode_6", 6, 31 },
                    { 7, "barcode_7", 7, 31 },
                    { 8, "barcode_7.1", 7, 31 }
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
                    { 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9656), "Пассатижи эконом класса", 25, 50, "Пассатижи", 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9656), 0.10000000000000001, 150 },
                    { 2, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9659), "Набор профессиональных отверток и бит DEKO SS100 с удобной подставкой (100 предметов).", 315, 143, "Набор проф. отверток DEKO SS100", 2, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9660), 2.75, 275 },
                    { 3, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9662), "Набор инструментов 1/4\", 1/2\" 6 граней 72 предмета волат (18530-72) - многофункциональный набор предназначен для ремонта и обслуживания автомобиля, а также для выполнения других слесарных работ. Рабочие части изготовлены из инструментальной стали. Покрытие сатинированное. Профиль головок шестигранный. Кейс из прочного противоударного пластика, с металлическими замками.", 300, 70, "Набор слесарного инстр-та 72пр.", 3, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9662), 7.3799999999999999, 300 },
                    { 4, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9668), "Комплектация набора подобрана так, что домашний мастер закроет все бытовые вопросы, связанные с ремонтом и благоустройством, сборкой/разборкой мебели, монтажа/демонтажа", 300, 70, "Дрель-шуруповерт (с 1-им АКБ, кейс, 128 предметов)", 4, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9668), 1.3, 300 },
                    { 5, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9670), "Пресс-клещи Gross 17724 используются для обжима наконечников электропроводов с сечением 0,25-8 м2. Позволяют добиться качественного соединения проводов при подключении бытовых приборов и электрооборудования. Клещи с автозажимом значительно повышают скорость работы, пригодятся в быту и профессиональной сфере. Преимущества 6-ступенчатая регулировка усилия сжатия позволяет выбрать оптимальный режим для работы с различными проводами. Двухкомпонентные рельефные рукоятки повышают удобство работы, обеспечивая надежный хват без риска проскальзывания инструмента. За счет функции авторазжима не нужно прикладывать усилия для раскрытия рабочих частей. Клещи упакованы в слайд карту для практичного хранения и транспортировк", 180, 3, "Клещи Gross", 5, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9670), 0.29999999999999999, 100 },
                    { 6, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9672), "Сверхлегкий, тонкий дизайн\r\nТоньше и легче, идеально ложится в карман, и с еще более ярким раскрывающимся экраном, от которого захватывает дух.\r\nСамый простой способ составить сводку в заметках на складных Galaxy\r\nЗаметки со встреч и лекций всего в несколько касаний, даже в условиях многозадачности. Ассистент для заметок превращает записи в текст и организует их в заметки, создавая удобные сводки. Для всего остального пользуйтесь электронным пером пером S Pen, которое на большом экране способно творить чудеса.", 135, 10, "Смартфон Samsung Galaxy Z Fold6 12/256 ГБ, Dual: nano SIM + eSIM, серебристый", 6, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9672), 0.17999999999999999, 150 },
                    { 7, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9674), "Три режима работы (сверление, сверление с ударом, долбление). Расцепляющая муфта для защиты инструмента и оператора при заклинивании. 40 осевых положений зубила для удобства эксплуатации. Спусковая кнопка с переменной скоростью.", 214, 370, "Перфоратор Makita HR2470", 7, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9675), 2.8999999999999999, 84 }
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
                columns: new[] { "Id", "ASetOfRulesId", "AccessToken", "Address", "ApplyingDate", "AppointmentId", "Created_At", "Email", "EmployeeStatusId", "LayoffDate", "Name", "ObjectId", "PassportNumber", "PassportSeries", "Password", "Patronymic", "PhoneNumber", "Snils", "Surname", "Tin", "Updated_At" },
                values: new object[,]
                {
                    { 1, 1, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEifQ.GQm1j57RyZMHdwsolLnzhoB9A49mC0KusQBpHS9_-kQ", "Красная прощать 4", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9471), 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9483), "admin@mail.ru", 1, null, "Иван", 1, "123456", "1234", "tester", "Алексеевич", "+79260128187", "123456789012", "Калмыков", "12345678901", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9484) },
                    { 2, 2, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIifQ.cbpuaPB0oVEkmkgFvfQUcaRb58xRn5zlClDroWd75JA", "Арбатская 6", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9487), 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9487), "admin2@mail.ru", 1, null, "Артур", 1, "123456", "1234", "tester", "Игоревич", "+79260125434", "123456789012", "Соколов", "12345678901", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9487) },
                    { 3, 3, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjMifQ.n0AxopvGMqJUdvyuXVuBZOurMD2Tiah-EqFi-a-lR6E", "Шевченко 4", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9491), 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9491), "admin3@mail.ru", 1, null, "Александр", 1, "123456", "1234", "tester", "Владимирович", "+79267654356", "123456789012", "Трунин", "12345678901", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9491) },
                    { 4, 4, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQifQ.NiQnkH09RTP1QMiS9rbWLQ3iDJbZ2CV3RsBflk5QjXs", "Ново Павловка 16/3", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9494), 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9494), "admin4@mail.ru", 1, null, "Алексей", 1, "123456", "1234", "tester", "Александрович", "+79266455553", "123456789012", "Федосов", "12345678901", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9495) },
                    { 5, 5, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjUifQ.t9QlQfK-k6WS2yA2KlKgn0JRCQhDaz5Ujo8UBVTJWCM", "Дальний восток 13/3", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9497), 1, new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9497), "admin5@mail.ru", 1, null, "Ансар", 1, "123456", "1234", "tester", "Нуруллович", "+79266726545", "123456789012", "Агадуллин", "12345678901", new DateTime(2024, 8, 1, 17, 6, 54, 802, DateTimeKind.Local).AddTicks(9498) }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "barcodes");

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
                name: "packing_lists");

            migrationBuilder.DropTable(
                name: "product_informations");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "products");

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
