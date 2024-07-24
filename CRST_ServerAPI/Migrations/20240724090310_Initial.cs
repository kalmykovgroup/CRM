using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace CRST_ServerAPI.Migrations
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
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "longblob", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: true),
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
