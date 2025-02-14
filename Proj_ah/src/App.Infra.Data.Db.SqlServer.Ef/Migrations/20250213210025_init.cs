using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infra.Data.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CityId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    CityId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Experts_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSubCategories_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpertServiceSubCategory",
                columns: table => new
                {
                    ExpertsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertServiceSubCategory", x => new { x.ExpertsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ExpertServiceSubCategory_Experts_ExpertsId",
                        column: x => x.ExpertsId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertServiceSubCategory_ServiceSubCategories_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "ServiceSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ServiceSubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoneTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId1 = table.Column<int>(type: "int", nullable: true),
                    ServiceSubCategoryId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_ServiceSubCategories_ServiceSubCategoryId",
                        column: x => x.ServiceSubCategoryId,
                        principalTable: "ServiceSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_ServiceSubCategories_ServiceSubCategoryId1",
                        column: x => x.ServiceSubCategoryId1,
                        principalTable: "ServiceSubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripsion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsWinner = table.Column<bool>(type: "bit", nullable: true),
                    SuggestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuggestedDo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suggestions_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Customer", "Customer" },
                    { 3, null, "Expert", "Expert" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "d255353f-43dc-4877-b886-134ba8cf5819", "Admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKyK2zP/1bwNESPsevVkfWzJGl4VguQ6aW0lEHQMm2bmIQzI1gv99CWzYAxFn5T7ZQ==", null, false, "660ecaca-bb13-4da7-add8-66dafe257675", false, "Admin@gmail.com" },
                    { 2, 0, "5b6d3993-fecc-4276-900a-2fa324b6ff9c", "Javad@gmail.com", false, false, null, "JAVAD@GMAIL.COM", "JAVAD@GMAIL.COM", "AQAAAAIAAYagAAAAEDnxfJR++/pcpSShBf6XfgbqOdsCpPSWgNEukqshUL7yFqWSE6RghDZ7qdD9Iea9Gg==", null, false, "a29e8086-cf43-426a-a913-6535b88fc93e", false, "Javad@gmail.com" },
                    { 3, 0, "c8950bd3-6016-4875-9024-16807c7623ef", "Ali@gmail.com", false, false, null, "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAEBDvdXlGJMNMm8i8mbIwVpjqcfZacl/lCXHmHViCgD8U85N5fYlU23fIARnX+Lm07A==", null, false, "d579d2c7-6aa9-4069-98ea-f5505655b453", false, "Ali@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatAt", "ImagePath", "IsActive", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 14, 0, 30, 24, 388, DateTimeKind.Local).AddTicks(1642), "\\Images\\icon\\tamiz.png", true, "تمیز کاری" },
                    { 2, new DateTime(2025, 2, 14, 0, 30, 24, 388, DateTimeKind.Local).AddTicks(1993), "\\Images\\icon\\sakhteman.png", true, "ساختمان" },
                    { 3, new DateTime(2025, 2, 14, 0, 30, 24, 388, DateTimeKind.Local).AddTicks(1996), "\\Images\\icon\\ashya.png", true, "تعمیرات اشیا" },
                    { 4, new DateTime(2025, 2, 14, 0, 30, 24, 388, DateTimeKind.Local).AddTicks(1997), "\\Images\\icon\\asbabkeshi.png", true, "اسباب کشی و حمل بار" },
                    { 5, new DateTime(2025, 2, 14, 0, 30, 24, 388, DateTimeKind.Local).AddTicks(1998), "\\Images\\icon\\khodro.png", true, "خودرو" },
                    { 6, new DateTime(2025, 2, 14, 0, 30, 24, 388, DateTimeKind.Local).AddTicks(1999), "\\Images\\icon\\zibaii.png", true, "سلامت و زیبایی" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "تهران" },
                    { 2, "مشهد" },
                    { 3, "اصفهان" },
                    { 4, "شیراز" },
                    { 5, "تبریز" },
                    { 6, "اهواز" },
                    { 7, "کرمانشاه" },
                    { 8, "زاهدان" },
                    { 9, "یزد" },
                    { 10, "اراک" },
                    { 11, "کرمان" },
                    { 12, "همدان" },
                    { 13, "قم" },
                    { 14, "رشت" },
                    { 15, "ارومیه" },
                    { 16, "سنندج" },
                    { 17, "گرگان" },
                    { 18, "شاهرود" },
                    { 19, "بوشهر" },
                    { 20, "خرم‌آباد" },
                    { 21, "قزوین" },
                    { 22, "ساری" },
                    { 23, "ماهشهر" },
                    { 24, "بابل" },
                    { 25, "زنجان" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Email", "FirstName", "ImagePath", "IsActive", "LastName", "Wallet" },
                values: new object[] { 1, 1, new DateTime(2025, 2, 14, 0, 30, 24, 386, DateTimeKind.Local).AddTicks(5206), "Admin@gmail.com", "Javad", null, true, "Moradi", 100.5m });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApplicationUserId", "CityId", "CityId1", "CreatedAt", "FirstName", "ImagePath", "IsActive", "LastName", "Mail", "PhoneNumber" },
                values: new object[] { 1, 2, 1, null, new DateTime(2025, 2, 14, 0, 30, 24, 398, DateTimeKind.Local).AddTicks(1423), "Javad", null, true, "Sadeghi", "Javad@gmail.com", null });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "ApplicationUserId", "CityId", "CityId1", "CreatedAt", "Description", "Email", "FirstName", "Gender", "ImagePath", "LastName", "PhoneNumber" },
                values: new object[] { 1, 3, 1, null, new DateTime(2025, 2, 14, 0, 30, 24, 401, DateTimeKind.Local).AddTicks(4399), "Expert in web development and software architecture.", "Ali@gmail.com", "Ali", 1, null, "Abd", null });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatAt", "ImagePath", "IsActive", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(4965), null, true, "نظافت و پذیرایی" },
                    { 2, 1, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5079), null, true, "شستشو" },
                    { 3, 1, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5081), null, true, "کارواش و دیتیلینگ" },
                    { 4, 2, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5082), null, true, "سرمایش و گرمایش" },
                    { 5, 2, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5083), null, true, "تعمیرات ساختمان" },
                    { 6, 2, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5084), null, true, "لوله کشی" },
                    { 7, 2, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5085), null, true, "طراحی و بازسازی ساختمان" },
                    { 8, 2, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5086), null, true, "برقکاری" },
                    { 9, 2, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5087), null, true, "چوب و کابینت" },
                    { 10, 2, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5088), null, true, "خدمات شیشه ای ساختمان" },
                    { 11, 2, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5089), null, true, "باغبانی و فضای سبز" },
                    { 12, 3, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5090), null, true, "نصب و تعمیر لوازم خانگی" },
                    { 13, 3, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5091), null, true, "خدمات کامپیوتری" },
                    { 14, 3, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5092), null, true, "تعمیرات موبایل" },
                    { 15, 4, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5093), null, true, "باربری و جابجایی" },
                    { 16, 5, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5094), null, true, "خدمات و تعمیرات خودرو" },
                    { 17, 5, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5095), null, true, "کارواش و دیتیلینگ" },
                    { 18, 6, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5096), null, true, "زیبایی بانوان" },
                    { 19, 6, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5097), null, true, "پزشکی و پرستاری" },
                    { 20, 6, new DateTime(2025, 2, 14, 0, 30, 24, 409, DateTimeKind.Local).AddTicks(5098), null, true, "حیوانات خانگی" }
                });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatAt", "ImagePath", "IsActive", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2309), "\\Images\\services\\1.jpg", true, 1, "خدمات نظافت و منزل" },
                    { 2, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2572), "\\Images\\services\\2.jpg", true, 1, "سرویس ویژه نظافت" },
                    { 3, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2574), "\\Images\\services\\3.jpg", true, 1, "سرویس لوکس نظافت" },
                    { 4, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2575), "\\Images\\services\\4.jpg", true, 1, "نظافت راه پله" },
                    { 5, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2577), "\\Images\\services\\5.jpg", true, 1, "سرویس نظافت فوری" },
                    { 6, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2578), "\\Images\\services\\6.jpg", true, 1, "پذیرایی" },
                    { 7, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2579), "\\Images\\services\\7.jpg", true, 1, "کارگر ساده" },
                    { 8, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2580), "\\Images\\services\\8.jpg", true, 1, "سمپاشی فضای داخلی" },
                    { 9, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2581), "\\Images\\services\\9.jpg", true, 2, "شستشو در محل" },
                    { 10, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2582), "\\Images\\services\\10.jpg", true, 2, "قالیشویی" },
                    { 11, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2596), "\\Images\\services\\11.png", true, 2, "خشکشویی" },
                    { 12, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2597), "\\Images\\services\\12.jpg", true, 2, "پرده شویی" },
                    { 13, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2598), "\\Images\\services\\13.jpg", true, 3, "کارواش سیار" },
                    { 14, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2599), "\\Images\\services\\14.jpg", true, 3, "سرامیک خودرو" },
                    { 15, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2600), "\\Images\\services\\15.jpg", true, 3, "موتورشویی خودرو" },
                    { 16, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2601), "\\Images\\services\\16.jpg", true, 4, "تعمیر و سرویس پکیج" },
                    { 17, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2602), "\\Images\\services\\17.jpg", true, 4, "تعمیر و سرویس آبگرم کن" },
                    { 18, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2603), "\\Images\\services\\18.jpg", true, 4, "نصب و تعمیر شوفاژ" },
                    { 19, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2604), "\\Images\\services\\19.jpg", true, 4, "تعمیر و نگهداری موتورخانه" },
                    { 20, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2605), "\\Images\\services\\20.jpg", true, 5, "سنگ کاری" },
                    { 21, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2606), "\\Images\\services\\21.jpeg", true, 5, "نقاشی ساختمان" },
                    { 22, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2607), "\\Images\\services\\22.jpg", true, 5, "نصب کاغذ دیواری" },
                    { 23, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2608), "\\Images\\services\\23.jpg", true, 5, "ساخت و نصب توری" },
                    { 24, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2609), "\\Images\\services\\24.jpg", true, 5, "بنایی" },
                    { 25, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2610), "\\Images\\services\\25.jpg", true, 5, "کلید سازی" },
                    { 26, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2611), "\\Images\\services\\26.jpg", true, 5, "دریل کاری" },
                    { 27, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2612), "\\Images\\services\\27.jpg", true, 6, "خدمات لوله کشی ساختمان" },
                    { 28, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2613), "\\Images\\services\\28.jpg", true, 6, "پمپ و منبع آب" },
                    { 29, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2622), "\\Images\\services\\29.webp", true, 6, "لوله کشی گاز" },
                    { 30, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2623), "\\Images\\services\\30.jpg", true, 6, "نصب و تعمیر وال هنگ" },
                    { 31, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2625), "\\Images\\services\\31.webp", true, 7, "خدمات بازسازی خانه" },
                    { 32, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2626), "\\Images\\services\\32.jpg", true, 7, "مشاوره و بازسازی خانه" },
                    { 33, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2627), "\\Images\\services\\33.jpg", true, 7, "دکوراسیون و طراحی ساختمان" },
                    { 34, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2628), "\\Images\\services\\34.jpg", true, 8, "سیم کشی و کابل کشی" },
                    { 35, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2629), "\\Images\\services\\35.jpg", true, 8, "رفع اتصالی" },
                    { 36, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2630), "\\Images\\services\\36.jpg", true, 8, "نصب لوستر و چراغ" },
                    { 37, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2631), "\\Images\\services\\37.jpg", true, 8, "کلید و پریز" },
                    { 38, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2632), "\\Images\\services\\38.png", true, 8, "نصب و تعویز فیوز" },
                    { 39, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2633), "\\Images\\services\\39.jpg", true, 8, "نصب و تعمیر کرکره برقی" },
                    { 40, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2634), "\\Images\\services\\40.webp", true, 9, "نجاری" },
                    { 41, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2635), "\\Images\\services\\41.jpg", true, 9, "تعمیرات مبلمان" },
                    { 42, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2636), "\\Images\\services\\42.jpg", true, 9, "خدمات درب چوبی و ضدسرقت" },
                    { 43, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2637), "\\Images\\services\\43.png", true, 10, "پارتیشن شیشه ای" },
                    { 44, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2638), "\\Images\\services\\44.jpg", true, 10, "شیشه بری و آینه کاری" },
                    { 45, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2639), "\\Images\\services\\45.jpg", true, 10, "هندریل شیشه ای" },
                    { 46, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2640), "\\Images\\services\\46.jpg", true, 10, "شیشه ریلی اسلاید" },
                    { 47, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2648), "\\Images\\services\\47.webp", true, 11, "خدمات باغبانی" },
                    { 48, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2649), "\\Images\\services\\48.jpg", true, 11, "کاشت و تعویض گلدان" },
                    { 49, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2650), "\\Images\\services\\49.webp", true, 11, "مشاوره گل و گیاه" },
                    { 50, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2651), "\\Images\\services\\50.jpg", true, 12, "تعمیر جارو برقی" },
                    { 51, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2652), "\\Images\\services\\51.jpg", true, 12, "تعمیر چرخ خیاطی" },
                    { 52, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2653), "\\Images\\services\\52.jpg", true, 12, "تعمیر پنکه" },
                    { 53, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2654), "\\Images\\services\\53.jpg", true, 13, "تعمیر کامپیوتر و لپ تاب" },
                    { 54, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2655), "\\Images\\services\\54.jpg", true, 13, "تعمیر ماشین های اداری" },
                    { 55, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2657), "\\Images\\services\\55.jpg", true, 13, "مودم و اینترنت" },
                    { 56, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2677), "\\Images\\services\\56.jpg", true, 14, "خدمات نرم افزاری" },
                    { 57, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2679), "\\Images\\services\\57.jpg", true, 14, "خدمات باتری" },
                    { 58, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2680), "\\Images\\services\\58.webp", true, 14, "خدمات دوربین" },
                    { 59, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2681), "\\Images\\services\\59.jpg", true, 15, "خدمات اسباب کشی" },
                    { 60, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2682), "\\Images\\services\\60.jpg", true, 15, "سرویس بسته بندی" },
                    { 61, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2683), "\\Images\\services\\61.jpg", true, 15, "کارگر جابه جایی" },
                    { 62, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2684), "\\Images\\services\\62.webp", true, 15, "اجاره انبار و سوله" },
                    { 63, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2685), "\\Images\\services\\63.jpg", true, 16, "خدمات خودرو" },
                    { 64, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2686), "\\Images\\services\\64.jpg", true, 16, "باتری به باتری" },
                    { 65, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2687), "\\Images\\services\\65.png", true, 16, "امداد خودرو" },
                    { 66, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2688), "\\Images\\services\\66.jpg", true, 16, "حمل خودرو" },
                    { 67, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2689), "\\Images\\services\\67.jpg", true, 17, "کارواش سیار" },
                    { 68, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2690), "\\Images\\services\\68.jpg", true, 17, "کارواش نانو" },
                    { 69, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2691), "\\Images\\services\\69.jpg", true, 17, "موتورشویی خودرو" },
                    { 70, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2692), "\\Images\\services\\70.jpg", true, 17, "احیای رنگ" },
                    { 71, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2693), "\\Images\\services\\71.jpg", true, 18, "خدمات ناخن" },
                    { 72, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2694), "\\Images\\services\\72.jpg", true, 18, "رنگ مو بانوان" },
                    { 73, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2695), "\\Images\\services\\73.jpg", true, 18, "براشینگ مو" },
                    { 74, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2696), "\\Images\\services\\74.jpg", true, 18, "کوتاهی مو بانوان" },
                    { 75, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2697), "\\Images\\services\\75.jpg", true, 19, "مراقبت و نگهداری" },
                    { 76, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2698), "\\Images\\services\\76.jpg", true, 19, "معاینه پزشکی" },
                    { 77, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2699), "\\Images\\services\\77.webp", true, 19, "پیراپزشکی" },
                    { 78, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2700), "\\Images\\services\\78.jpg", true, 20, "هتل های حیوانات خانگی" },
                    { 79, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2701), "\\Images\\services\\79.jpg", true, 20, "خدمات دامپزشکی در محل" },
                    { 80, new DateTime(2025, 2, 14, 0, 30, 24, 408, DateTimeKind.Local).AddTicks(2702), "\\Images\\services\\80.jpg", true, 20, "خدمات شستشو و آراش حیوانات خانگی" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ApplicationUserId",
                table: "Admins",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ExpertId",
                table: "Comments",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId1",
                table: "Customers",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Experts_ApplicationUserId",
                table: "Experts",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experts_CityId",
                table: "Experts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Experts_CityId1",
                table: "Experts",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertServiceSubCategory_SkillsId",
                table: "ExpertServiceSubCategory",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RequestId",
                table: "Images",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId1",
                table: "Requests",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceSubCategoryId",
                table: "Requests",
                column: "ServiceSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceSubCategoryId1",
                table: "Requests",
                column: "ServiceSubCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSubCategories_SubCategoryId",
                table: "ServiceSubCategories",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ExpertId",
                table: "Suggestions",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_RequestId",
                table: "Suggestions",
                column: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ExpertServiceSubCategory");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ServiceSubCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
