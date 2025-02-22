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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                        name: "FK_Requests_ServiceSubCategories_ServiceSubCategoryId",
                        column: x => x.ServiceSubCategoryId,
                        principalTable: "ServiceSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "50c8f809-6d45-4e29-9231-094ba541a44f", "Admin@gmail.com", false, false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENOPVWpIZn5WQq4YPkhHD2HgDeujX9ArE2R5/vbL8nD961mV/LMUxSmWl5cELl714g==", null, false, "819b5ed1-00d4-4524-9f98-fd9bec7a844f", false, "Admin@gmail.com" },
                    { 2, 0, "95b300b2-a183-4451-960f-e19418ba090b", "Javad@gmail.com", false, false, false, null, "JAVAD@GMAIL.COM", "JAVAD@GMAIL.COM", "AQAAAAIAAYagAAAAEPYEi8h0I4UqFNMcecdMf8CMX1yprdRz0EWXjggq0V2PCcDIoXRMEVW7TmzBe+BUtg==", null, false, "543fbe77-59e4-4269-b001-20ca460d6353", false, "Javad@gmail.com" },
                    { 3, 0, "b484839b-88a0-4053-be64-1d34c48761be", "Ali@gmail.com", false, false, false, null, "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAENV9GxQ3hDR9Yb9+upSn4rvZjgbFX8QGH9J7Aoq3VjKfbJgwT2BZ5a0CuaS4A5OtwQ==", null, false, "3cf40e78-1e71-4f60-ac2c-c7a26ba64d7f", false, "Ali@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatAt", "ImagePath", "IsActive", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 20, 25, 49, 368, DateTimeKind.Local).AddTicks(3258), "/assets/img/category/tamiz.png", true, false, "تمیز کاری" },
                    { 2, new DateTime(2025, 2, 21, 20, 25, 49, 368, DateTimeKind.Local).AddTicks(3500), "/assets/img/category/sakhteman.png", true, false, "ساختمان" },
                    { 3, new DateTime(2025, 2, 21, 20, 25, 49, 368, DateTimeKind.Local).AddTicks(3502), "/assets/img/category/ashya.png", true, false, "تعمیرات اشیا" },
                    { 4, new DateTime(2025, 2, 21, 20, 25, 49, 368, DateTimeKind.Local).AddTicks(3503), "/assets/img/category/Asbabkeshi-icon.png", true, false, "اسباب کشی و حمل بار" },
                    { 5, new DateTime(2025, 2, 21, 20, 25, 49, 368, DateTimeKind.Local).AddTicks(3505), "/assets/img/category/khodro.png", true, false, "خودرو" },
                    { 6, new DateTime(2025, 2, 21, 20, 25, 49, 368, DateTimeKind.Local).AddTicks(3506), "/assets/img/category/zibaii.png", true, false, "سلامت و زیبایی" }
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
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Email", "FirstName", "ImagePath", "IsActive", "IsDeleted", "LastName", "Wallet" },
                values: new object[] { 1, 1, new DateTime(2025, 2, 21, 20, 25, 49, 366, DateTimeKind.Local).AddTicks(5920), "Admin@gmail.com", "Javad", null, true, false, "Moradi", 100.5m });

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
                columns: new[] { "Id", "ApplicationUserId", "CityId", "CreatedAt", "FirstName", "ImagePath", "IsActive", "IsDeleted", "LastName", "Mail", "PhoneNumber" },
                values: new object[] { 1, 2, 1, new DateTime(2025, 2, 21, 20, 25, 49, 372, DateTimeKind.Local).AddTicks(9811), "Javad", null, true, false, "Sadeghi", "Javad@gmail.com", null });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "ApplicationUserId", "CityId", "CreatedAt", "Description", "Email", "FirstName", "Gender", "ImagePath", "IsDeleted", "LastName", "PhoneNumber" },
                values: new object[] { 1, 3, 1, new DateTime(2025, 2, 21, 20, 25, 49, 375, DateTimeKind.Local).AddTicks(98), "Expert in web development and software architecture.", "Ali@gmail.com", "Ali", 1, null, false, "Abd", null });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatAt", "ImagePath", "IsActive", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3677), null, true, false, "نظافت و پذیرایی" },
                    { 2, 1, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3792), null, true, false, "شستشو" },
                    { 3, 1, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3794), null, true, false, "کارواش و دیتیلینگ" },
                    { 4, 2, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3795), null, true, false, "سرمایش و گرمایش" },
                    { 5, 2, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3796), null, true, false, "تعمیرات ساختمان" },
                    { 6, 2, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3797), null, true, false, "لوله کشی" },
                    { 7, 2, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3798), null, true, false, "طراحی و بازسازی ساختمان" },
                    { 8, 2, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3799), null, true, false, "برقکاری" },
                    { 9, 2, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3800), null, true, false, "چوب و کابینت" },
                    { 10, 2, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3801), null, true, false, "خدمات شیشه ای ساختمان" },
                    { 11, 2, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3802), null, true, false, "باغبانی و فضای سبز" },
                    { 12, 3, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3803), null, true, false, "نصب و تعمیر لوازم خانگی" },
                    { 13, 3, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3804), null, true, false, "خدمات کامپیوتری" },
                    { 14, 3, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3804), null, true, false, "تعمیرات موبایل" },
                    { 15, 4, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3805), null, true, false, "باربری و جابجایی" },
                    { 16, 5, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3806), null, true, false, "خدمات و تعمیرات خودرو" },
                    { 17, 5, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3807), null, true, false, "کارواش و دیتیلینگ" },
                    { 18, 6, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3808), null, true, false, "زیبایی بانوان" },
                    { 19, 6, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3809), null, true, false, "پزشکی و پرستاری" },
                    { 20, 6, new DateTime(2025, 2, 21, 20, 25, 49, 380, DateTimeKind.Local).AddTicks(3810), null, true, false, "حیوانات خانگی" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatAt", "CustomerId", "ExpertId", "IsAccept", "IsActive", "IsDeleted", "Score" },
                values: new object[] { 1, "This is a great comment!", new DateTime(2025, 2, 21, 20, 25, 49, 371, DateTimeKind.Local).AddTicks(8945), 1, 1, true, true, false, 5 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatAt", "CustomerId", "ExpertId", "IsActive", "IsDeleted", "Score" },
                values: new object[,]
                {
                    { 2, "This is another comment.", new DateTime(2025, 2, 21, 20, 25, 49, 371, DateTimeKind.Local).AddTicks(9606), 1, 1, true, false, 4 },
                    { 3, "This is bad comment.", new DateTime(2025, 2, 21, 20, 25, 49, 371, DateTimeKind.Local).AddTicks(9609), 1, 1, true, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatAt", "ImagePath", "IsActive", "IsDeleted", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2056), "\\Images\\services\\1.jpg", true, false, 1, "خدمات نظافت و منزل" },
                    { 2, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2295), "\\Images\\services\\2.jpg", true, false, 1, "سرویس ویژه نظافت" },
                    { 3, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2297), "\\Images\\services\\3.jpg", true, false, 1, "سرویس لوکس نظافت" },
                    { 4, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2298), "\\Images\\services\\4.jpg", true, false, 1, "نظافت راه پله" },
                    { 5, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2299), "\\Images\\services\\5.jpg", true, false, 1, "سرویس نظافت فوری" },
                    { 6, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2300), "\\Images\\services\\6.jpg", true, false, 1, "پذیرایی" },
                    { 7, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2301), "\\Images\\services\\7.jpg", true, false, 1, "کارگر ساده" },
                    { 8, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2302), "\\Images\\services\\8.jpg", true, false, 1, "سمپاشی فضای داخلی" },
                    { 9, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2303), "\\Images\\services\\9.jpg", true, false, 2, "شستشو در محل" },
                    { 10, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2305), "\\Images\\services\\10.jpg", true, false, 2, "قالیشویی" },
                    { 11, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2306), "\\Images\\services\\11.png", true, false, 2, "خشکشویی" },
                    { 12, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2307), "\\Images\\services\\12.jpg", true, false, 2, "پرده شویی" },
                    { 13, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2308), "\\Images\\services\\13.jpg", true, false, 3, "کارواش سیار" },
                    { 14, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2309), "\\Images\\services\\14.jpg", true, false, 3, "سرامیک خودرو" },
                    { 15, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2318), "\\Images\\services\\15.jpg", true, false, 3, "موتورشویی خودرو" },
                    { 16, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2319), "\\Images\\services\\16.jpg", true, false, 4, "تعمیر و سرویس پکیج" },
                    { 17, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2320), "\\Images\\services\\17.jpg", true, false, 4, "تعمیر و سرویس آبگرم کن" },
                    { 18, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2322), "\\Images\\services\\18.jpg", true, false, 4, "نصب و تعمیر شوفاژ" },
                    { 19, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2323), "\\Images\\services\\19.jpg", true, false, 4, "تعمیر و نگهداری موتورخانه" },
                    { 20, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2324), "\\Images\\services\\20.jpg", true, false, 5, "سنگ کاری" },
                    { 21, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2325), "\\Images\\services\\21.jpeg", true, false, 5, "نقاشی ساختمان" },
                    { 22, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2326), "\\Images\\services\\22.jpg", true, false, 5, "نصب کاغذ دیواری" },
                    { 23, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2327), "\\Images\\services\\23.jpg", true, false, 5, "ساخت و نصب توری" },
                    { 24, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2328), "\\Images\\services\\24.jpg", true, false, 5, "بنایی" },
                    { 25, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2329), "\\Images\\services\\25.jpg", true, false, 5, "کلید سازی" },
                    { 26, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2330), "\\Images\\services\\26.jpg", true, false, 5, "دریل کاری" },
                    { 27, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2331), "\\Images\\services\\27.jpg", true, false, 6, "خدمات لوله کشی ساختمان" },
                    { 28, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2332), "\\Images\\services\\28.jpg", true, false, 6, "پمپ و منبع آب" },
                    { 29, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2333), "\\Images\\services\\29.webp", true, false, 6, "لوله کشی گاز" },
                    { 30, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2334), "\\Images\\services\\30.jpg", true, false, 6, "نصب و تعمیر وال هنگ" },
                    { 31, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2335), "\\Images\\services\\31.webp", true, false, 7, "خدمات بازسازی خانه" },
                    { 32, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2337), "\\Images\\services\\32.jpg", true, false, 7, "مشاوره و بازسازی خانه" },
                    { 33, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2344), "\\Images\\services\\33.jpg", true, false, 7, "دکوراسیون و طراحی ساختمان" },
                    { 34, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2345), "\\Images\\services\\34.jpg", true, false, 8, "سیم کشی و کابل کشی" },
                    { 35, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2347), "\\Images\\services\\35.jpg", true, false, 8, "رفع اتصالی" },
                    { 36, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2348), "\\Images\\services\\36.jpg", true, false, 8, "نصب لوستر و چراغ" },
                    { 37, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2349), "\\Images\\services\\37.jpg", true, false, 8, "کلید و پریز" },
                    { 38, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2350), "\\Images\\services\\38.png", true, false, 8, "نصب و تعویز فیوز" },
                    { 39, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2351), "\\Images\\services\\39.jpg", true, false, 8, "نصب و تعمیر کرکره برقی" },
                    { 40, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2352), "\\Images\\services\\40.webp", true, false, 9, "نجاری" },
                    { 41, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2353), "\\Images\\services\\41.jpg", true, false, 9, "تعمیرات مبلمان" },
                    { 42, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2355), "\\Images\\services\\42.jpg", true, false, 9, "خدمات درب چوبی و ضدسرقت" },
                    { 43, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2356), "\\Images\\services\\43.png", true, false, 10, "پارتیشن شیشه ای" },
                    { 44, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2357), "\\Images\\services\\44.jpg", true, false, 10, "شیشه بری و آینه کاری" },
                    { 45, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2358), "\\Images\\services\\45.jpg", true, false, 10, "هندریل شیشه ای" },
                    { 46, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2359), "\\Images\\services\\46.jpg", true, false, 10, "شیشه ریلی اسلاید" },
                    { 47, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2360), "\\Images\\services\\47.webp", true, false, 11, "خدمات باغبانی" },
                    { 48, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2361), "\\Images\\services\\48.jpg", true, false, 11, "کاشت و تعویض گلدان" },
                    { 49, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2362), "\\Images\\services\\49.webp", true, false, 11, "مشاوره گل و گیاه" },
                    { 50, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2363), "\\Images\\services\\50.jpg", true, false, 12, "تعمیر جارو برقی" },
                    { 51, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2371), "\\Images\\services\\51.jpg", true, false, 12, "تعمیر چرخ خیاطی" },
                    { 52, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2373), "\\Images\\services\\52.jpg", true, false, 12, "تعمیر پنکه" },
                    { 53, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2374), "\\Images\\services\\53.jpg", true, false, 13, "تعمیر کامپیوتر و لپ تاب" },
                    { 54, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2375), "\\Images\\services\\54.jpg", true, false, 13, "تعمیر ماشین های اداری" },
                    { 55, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2376), "\\Images\\services\\55.jpg", true, false, 13, "مودم و اینترنت" },
                    { 56, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2377), "\\Images\\services\\56.jpg", true, false, 14, "خدمات نرم افزاری" },
                    { 57, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2378), "\\Images\\services\\57.jpg", true, false, 14, "خدمات باتری" },
                    { 58, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2379), "\\Images\\services\\58.webp", true, false, 14, "خدمات دوربین" },
                    { 59, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2380), "\\Images\\services\\59.jpg", true, false, 15, "خدمات اسباب کشی" },
                    { 60, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2381), "\\Images\\services\\60.jpg", true, false, 15, "سرویس بسته بندی" },
                    { 61, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2382), "\\Images\\services\\61.jpg", true, false, 15, "کارگر جابه جایی" },
                    { 62, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2383), "\\Images\\services\\62.webp", true, false, 15, "اجاره انبار و سوله" },
                    { 63, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2384), "\\Images\\services\\63.jpg", true, false, 16, "خدمات خودرو" },
                    { 64, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2385), "\\Images\\services\\64.jpg", true, false, 16, "باتری به باتری" },
                    { 65, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2386), "\\Images\\services\\65.png", true, false, 16, "امداد خودرو" },
                    { 66, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2387), "\\Images\\services\\66.jpg", true, false, 16, "حمل خودرو" },
                    { 67, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2388), "\\Images\\services\\67.jpg", true, false, 17, "کارواش سیار" },
                    { 68, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2390), "\\Images\\services\\68.jpg", true, false, 17, "کارواش نانو" },
                    { 69, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2391), "\\Images\\services\\69.jpg", true, false, 17, "موتورشویی خودرو" },
                    { 70, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2392), "\\Images\\services\\70.jpg", true, false, 17, "احیای رنگ" },
                    { 71, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2393), "\\Images\\services\\71.jpg", true, false, 18, "خدمات ناخن" },
                    { 72, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2394), "\\Images\\services\\72.jpg", true, false, 18, "رنگ مو بانوان" },
                    { 73, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2395), "\\Images\\services\\73.jpg", true, false, 18, "براشینگ مو" },
                    { 74, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2396), "\\Images\\services\\74.jpg", true, false, 18, "کوتاهی مو بانوان" },
                    { 75, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2397), "\\Images\\services\\75.jpg", true, false, 19, "مراقبت و نگهداری" },
                    { 76, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2398), "\\Images\\services\\76.jpg", true, false, 19, "معاینه پزشکی" },
                    { 77, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2399), "\\Images\\services\\77.webp", true, false, 19, "پیراپزشکی" },
                    { 78, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2400), "\\Images\\services\\78.jpg", true, false, 20, "هتل های حیوانات خانگی" },
                    { 79, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2401), "\\Images\\services\\79.jpg", true, false, 20, "خدمات دامپزشکی در محل" },
                    { 80, new DateTime(2025, 2, 21, 20, 25, 49, 379, DateTimeKind.Local).AddTicks(2402), "\\Images\\services\\80.jpg", true, false, 20, "خدمات شستشو و آراش حیوانات خانگی" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "BasePrice", "CreatedAt", "CustomerId", "Description", "DoneTime", "IsDeleted", "ServiceSubCategoryId", "Status" },
                values: new object[,]
                {
                    { 1, 100m, new DateTime(2025, 2, 21, 16, 55, 49, 377, DateTimeKind.Utc).AddTicks(458), 1, "Request for a detailed consultation on product X", null, false, 1, 1 },
                    { 2, 150m, new DateTime(2025, 2, 20, 16, 55, 49, 377, DateTimeKind.Utc).AddTicks(861), 1, "Urgent request for a technical issue in product Y", new DateTime(2025, 2, 22, 16, 55, 49, 377, DateTimeKind.Utc).AddTicks(937), false, 2, 1 },
                    { 3, 200m, new DateTime(2025, 2, 19, 16, 55, 49, 377, DateTimeKind.Utc).AddTicks(1001), 1, "Completed request for installation of service Z", new DateTime(2025, 2, 20, 16, 55, 49, 377, DateTimeKind.Utc).AddTicks(1002), false, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "Id", "Amount", "Descripsion", "ExpertId", "IsActive", "IsDeleted", "IsWinner", "RequestId", "Status", "SuggestedDate", "SuggestedDo" },
                values: new object[,]
                {
                    { 1, 150m, "Detailed consultation suggestion for product X", 1, true, false, false, 1, 1, new DateTime(2025, 2, 21, 16, 55, 49, 381, DateTimeKind.Utc).AddTicks(6434), new DateTime(2025, 2, 22, 16, 55, 49, 381, DateTimeKind.Utc).AddTicks(6514) },
                    { 2, 200m, "Urgent technical issue resolution suggestion for product Y", 1, true, false, false, 2, 1, new DateTime(2025, 2, 19, 16, 55, 49, 381, DateTimeKind.Utc).AddTicks(6858), new DateTime(2025, 2, 22, 16, 55, 49, 381, DateTimeKind.Utc).AddTicks(6858) },
                    { 3, 180m, "Installation suggestion for service Z", 1, true, false, false, 3, 1, new DateTime(2025, 2, 18, 16, 55, 49, 381, DateTimeKind.Utc).AddTicks(6861), new DateTime(2025, 2, 23, 16, 55, 49, 381, DateTimeKind.Utc).AddTicks(6861) }
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
                name: "IX_Experts_ApplicationUserId",
                table: "Experts",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experts_CityId",
                table: "Experts",
                column: "CityId");

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
                name: "IX_Requests_ServiceSubCategoryId",
                table: "Requests",
                column: "ServiceSubCategoryId");

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
