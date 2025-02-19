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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExpertId1 = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Comments_Experts_ExpertId1",
                        column: x => x.ExpertId1,
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    { 1, 0, "1570a142-c6dd-4204-8ba5-77a6fc387d34", "Admin@gmail.com", false, false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEATq4zNmZDJ7neZSPKsq1+FQfV1tHmn7EtCOeeTZhN/ee0gCjHKpAwUH2+FA6Us2ZA==", null, false, "4dc5c85c-09a1-4f4f-9fb5-0f63548da942", false, "Admin@gmail.com" },
                    { 2, 0, "5981cd09-8c0a-42b4-9905-aa1d6194595c", "Javad@gmail.com", false, false, false, null, "JAVAD@GMAIL.COM", "JAVAD@GMAIL.COM", "AQAAAAIAAYagAAAAEHcxcdVC1xBhPsQ31ljSMyH33DJ0elB7PS1DiP8Pq1/PAXlIol4wvEtekM+Q3jv/KA==", null, false, "af06ccc8-9a2e-48cb-89a6-d0124370cdcd", false, "Javad@gmail.com" },
                    { 3, 0, "f7a817ae-002c-4534-8237-8c81eccdc2b5", "Ali@gmail.com", false, false, false, null, "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAENXPGoRaaSWWAbzbJrno6W3ICYwSZSoqEqCbm73gMQDghsspCFlRO3JdCRGSpgrKnA==", null, false, "1529f248-053c-4983-b682-e7ea9a5ff1ec", false, "Ali@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatAt", "ImagePath", "IsActive", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 19, 16, 19, 37, 604, DateTimeKind.Local).AddTicks(5948), "\\Images\\icon\\tamiz.png", true, false, "تمیز کاری" },
                    { 2, new DateTime(2025, 2, 19, 16, 19, 37, 604, DateTimeKind.Local).AddTicks(6171), "\\Images\\icon\\sakhteman.png", true, false, "ساختمان" },
                    { 3, new DateTime(2025, 2, 19, 16, 19, 37, 604, DateTimeKind.Local).AddTicks(6173), "\\Images\\icon\\ashya.png", true, false, "تعمیرات اشیا" },
                    { 4, new DateTime(2025, 2, 19, 16, 19, 37, 604, DateTimeKind.Local).AddTicks(6174), "\\Images\\icon\\asbabkeshi.png", true, false, "اسباب کشی و حمل بار" },
                    { 5, new DateTime(2025, 2, 19, 16, 19, 37, 604, DateTimeKind.Local).AddTicks(6175), "\\Images\\icon\\khodro.png", true, false, "خودرو" },
                    { 6, new DateTime(2025, 2, 19, 16, 19, 37, 604, DateTimeKind.Local).AddTicks(6176), "\\Images\\icon\\zibaii.png", true, false, "سلامت و زیبایی" }
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
                values: new object[] { 1, 1, new DateTime(2025, 2, 19, 16, 19, 37, 602, DateTimeKind.Local).AddTicks(9135), "Admin@gmail.com", "Javad", null, true, false, "Moradi", 100.5m });

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
                columns: new[] { "Id", "ApplicationUserId", "CityId", "CityId1", "CreatedAt", "FirstName", "ImagePath", "IsActive", "IsDeleted", "LastName", "Mail", "PhoneNumber" },
                values: new object[] { 1, 2, 1, null, new DateTime(2025, 2, 19, 16, 19, 37, 615, DateTimeKind.Local).AddTicks(8575), "Javad", null, true, false, "Sadeghi", "Javad@gmail.com", null });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "ApplicationUserId", "CityId", "CityId1", "CreatedAt", "Description", "Email", "FirstName", "Gender", "ImagePath", "IsDeleted", "LastName", "PhoneNumber" },
                values: new object[] { 1, 3, 1, null, new DateTime(2025, 2, 19, 16, 19, 37, 619, DateTimeKind.Local).AddTicks(4002), "Expert in web development and software architecture.", "Ali@gmail.com", "Ali", 1, null, false, "Abd", null });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatAt", "ImagePath", "IsActive", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9078), null, true, false, "نظافت و پذیرایی" },
                    { 2, 1, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9196), null, true, false, "شستشو" },
                    { 3, 1, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9198), null, true, false, "کارواش و دیتیلینگ" },
                    { 4, 2, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9199), null, true, false, "سرمایش و گرمایش" },
                    { 5, 2, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9200), null, true, false, "تعمیرات ساختمان" },
                    { 6, 2, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9201), null, true, false, "لوله کشی" },
                    { 7, 2, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9202), null, true, false, "طراحی و بازسازی ساختمان" },
                    { 8, 2, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9203), null, true, false, "برقکاری" },
                    { 9, 2, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9204), null, true, false, "چوب و کابینت" },
                    { 10, 2, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9206), null, true, false, "خدمات شیشه ای ساختمان" },
                    { 11, 2, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9207), null, true, false, "باغبانی و فضای سبز" },
                    { 12, 3, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9208), null, true, false, "نصب و تعمیر لوازم خانگی" },
                    { 13, 3, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9209), null, true, false, "خدمات کامپیوتری" },
                    { 14, 3, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9210), null, true, false, "تعمیرات موبایل" },
                    { 15, 4, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9211), null, true, false, "باربری و جابجایی" },
                    { 16, 5, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9212), null, true, false, "خدمات و تعمیرات خودرو" },
                    { 17, 5, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9213), null, true, false, "کارواش و دیتیلینگ" },
                    { 18, 6, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9214), null, true, false, "زیبایی بانوان" },
                    { 19, 6, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9215), null, true, false, "پزشکی و پرستاری" },
                    { 20, 6, new DateTime(2025, 2, 19, 16, 19, 37, 627, DateTimeKind.Local).AddTicks(9216), null, true, false, "حیوانات خانگی" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatAt", "CustomerId", "ExpertId", "ExpertId1", "IsAccept", "IsActive", "IsDeleted", "MyProperty", "Score" },
                values: new object[] { 1, "This is a great comment!", new DateTime(2025, 2, 19, 16, 19, 37, 610, DateTimeKind.Local).AddTicks(8098), 1, 1, null, true, true, false, 0, 5 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatAt", "CustomerId", "ExpertId", "ExpertId1", "IsActive", "IsDeleted", "MyProperty", "Score" },
                values: new object[,]
                {
                    { 2, "This is another comment.", new DateTime(2025, 2, 19, 16, 19, 37, 610, DateTimeKind.Local).AddTicks(8773), 1, 1, null, true, false, 0, 4 },
                    { 3, "This is bad comment.", new DateTime(2025, 2, 19, 16, 19, 37, 610, DateTimeKind.Local).AddTicks(8776), 1, 1, null, true, false, 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatAt", "ImagePath", "IsActive", "IsDeleted", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6644), "\\Images\\services\\1.jpg", true, false, 1, "خدمات نظافت و منزل" },
                    { 2, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6863), "\\Images\\services\\2.jpg", true, false, 1, "سرویس ویژه نظافت" },
                    { 3, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6865), "\\Images\\services\\3.jpg", true, false, 1, "سرویس لوکس نظافت" },
                    { 4, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6866), "\\Images\\services\\4.jpg", true, false, 1, "نظافت راه پله" },
                    { 5, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6867), "\\Images\\services\\5.jpg", true, false, 1, "سرویس نظافت فوری" },
                    { 6, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6868), "\\Images\\services\\6.jpg", true, false, 1, "پذیرایی" },
                    { 7, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6879), "\\Images\\services\\7.jpg", true, false, 1, "کارگر ساده" },
                    { 8, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6881), "\\Images\\services\\8.jpg", true, false, 1, "سمپاشی فضای داخلی" },
                    { 9, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6882), "\\Images\\services\\9.jpg", true, false, 2, "شستشو در محل" },
                    { 10, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6883), "\\Images\\services\\10.jpg", true, false, 2, "قالیشویی" },
                    { 11, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6884), "\\Images\\services\\11.png", true, false, 2, "خشکشویی" },
                    { 12, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6885), "\\Images\\services\\12.jpg", true, false, 2, "پرده شویی" },
                    { 13, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6886), "\\Images\\services\\13.jpg", true, false, 3, "کارواش سیار" },
                    { 14, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6888), "\\Images\\services\\14.jpg", true, false, 3, "سرامیک خودرو" },
                    { 15, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6889), "\\Images\\services\\15.jpg", true, false, 3, "موتورشویی خودرو" },
                    { 16, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6890), "\\Images\\services\\16.jpg", true, false, 4, "تعمیر و سرویس پکیج" },
                    { 17, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6891), "\\Images\\services\\17.jpg", true, false, 4, "تعمیر و سرویس آبگرم کن" },
                    { 18, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6892), "\\Images\\services\\18.jpg", true, false, 4, "نصب و تعمیر شوفاژ" },
                    { 19, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6893), "\\Images\\services\\19.jpg", true, false, 4, "تعمیر و نگهداری موتورخانه" },
                    { 20, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6894), "\\Images\\services\\20.jpg", true, false, 5, "سنگ کاری" },
                    { 21, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6895), "\\Images\\services\\21.jpeg", true, false, 5, "نقاشی ساختمان" },
                    { 22, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6896), "\\Images\\services\\22.jpg", true, false, 5, "نصب کاغذ دیواری" },
                    { 23, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6898), "\\Images\\services\\23.jpg", true, false, 5, "ساخت و نصب توری" },
                    { 24, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6899), "\\Images\\services\\24.jpg", true, false, 5, "بنایی" },
                    { 25, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6907), "\\Images\\services\\25.jpg", true, false, 5, "کلید سازی" },
                    { 26, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6908), "\\Images\\services\\26.jpg", true, false, 5, "دریل کاری" },
                    { 27, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6909), "\\Images\\services\\27.jpg", true, false, 6, "خدمات لوله کشی ساختمان" },
                    { 28, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6910), "\\Images\\services\\28.jpg", true, false, 6, "پمپ و منبع آب" },
                    { 29, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6911), "\\Images\\services\\29.webp", true, false, 6, "لوله کشی گاز" },
                    { 30, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6912), "\\Images\\services\\30.jpg", true, false, 6, "نصب و تعمیر وال هنگ" },
                    { 31, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6913), "\\Images\\services\\31.webp", true, false, 7, "خدمات بازسازی خانه" },
                    { 32, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6915), "\\Images\\services\\32.jpg", true, false, 7, "مشاوره و بازسازی خانه" },
                    { 33, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6916), "\\Images\\services\\33.jpg", true, false, 7, "دکوراسیون و طراحی ساختمان" },
                    { 34, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6917), "\\Images\\services\\34.jpg", true, false, 8, "سیم کشی و کابل کشی" },
                    { 35, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6918), "\\Images\\services\\35.jpg", true, false, 8, "رفع اتصالی" },
                    { 36, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6919), "\\Images\\services\\36.jpg", true, false, 8, "نصب لوستر و چراغ" },
                    { 37, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6920), "\\Images\\services\\37.jpg", true, false, 8, "کلید و پریز" },
                    { 38, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6921), "\\Images\\services\\38.png", true, false, 8, "نصب و تعویز فیوز" },
                    { 39, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6922), "\\Images\\services\\39.jpg", true, false, 8, "نصب و تعمیر کرکره برقی" },
                    { 40, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6924), "\\Images\\services\\40.webp", true, false, 9, "نجاری" },
                    { 41, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6925), "\\Images\\services\\41.jpg", true, false, 9, "تعمیرات مبلمان" },
                    { 42, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6926), "\\Images\\services\\42.jpg", true, false, 9, "خدمات درب چوبی و ضدسرقت" },
                    { 43, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6927), "\\Images\\services\\43.png", true, false, 10, "پارتیشن شیشه ای" },
                    { 44, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6935), "\\Images\\services\\44.jpg", true, false, 10, "شیشه بری و آینه کاری" },
                    { 45, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6936), "\\Images\\services\\45.jpg", true, false, 10, "هندریل شیشه ای" },
                    { 46, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6938), "\\Images\\services\\46.jpg", true, false, 10, "شیشه ریلی اسلاید" },
                    { 47, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6939), "\\Images\\services\\47.webp", true, false, 11, "خدمات باغبانی" },
                    { 48, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6940), "\\Images\\services\\48.jpg", true, false, 11, "کاشت و تعویض گلدان" },
                    { 49, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6941), "\\Images\\services\\49.webp", true, false, 11, "مشاوره گل و گیاه" },
                    { 50, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6942), "\\Images\\services\\50.jpg", true, false, 12, "تعمیر جارو برقی" },
                    { 51, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6943), "\\Images\\services\\51.jpg", true, false, 12, "تعمیر چرخ خیاطی" },
                    { 52, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6944), "\\Images\\services\\52.jpg", true, false, 12, "تعمیر پنکه" },
                    { 53, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6945), "\\Images\\services\\53.jpg", true, false, 13, "تعمیر کامپیوتر و لپ تاب" },
                    { 54, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6946), "\\Images\\services\\54.jpg", true, false, 13, "تعمیر ماشین های اداری" },
                    { 55, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6948), "\\Images\\services\\55.jpg", true, false, 13, "مودم و اینترنت" },
                    { 56, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6949), "\\Images\\services\\56.jpg", true, false, 14, "خدمات نرم افزاری" },
                    { 57, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6950), "\\Images\\services\\57.jpg", true, false, 14, "خدمات باتری" },
                    { 58, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6951), "\\Images\\services\\58.webp", true, false, 14, "خدمات دوربین" },
                    { 59, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6952), "\\Images\\services\\59.jpg", true, false, 15, "خدمات اسباب کشی" },
                    { 60, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6953), "\\Images\\services\\60.jpg", true, false, 15, "سرویس بسته بندی" },
                    { 61, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6954), "\\Images\\services\\61.jpg", true, false, 15, "کارگر جابه جایی" },
                    { 62, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6963), "\\Images\\services\\62.webp", true, false, 15, "اجاره انبار و سوله" },
                    { 63, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6964), "\\Images\\services\\63.jpg", true, false, 16, "خدمات خودرو" },
                    { 64, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6965), "\\Images\\services\\64.jpg", true, false, 16, "باتری به باتری" },
                    { 65, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6966), "\\Images\\services\\65.png", true, false, 16, "امداد خودرو" },
                    { 66, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6967), "\\Images\\services\\66.jpg", true, false, 16, "حمل خودرو" },
                    { 67, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6968), "\\Images\\services\\67.jpg", true, false, 17, "کارواش سیار" },
                    { 68, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6970), "\\Images\\services\\68.jpg", true, false, 17, "کارواش نانو" },
                    { 69, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6971), "\\Images\\services\\69.jpg", true, false, 17, "موتورشویی خودرو" },
                    { 70, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6972), "\\Images\\services\\70.jpg", true, false, 17, "احیای رنگ" },
                    { 71, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6973), "\\Images\\services\\71.jpg", true, false, 18, "خدمات ناخن" },
                    { 72, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6974), "\\Images\\services\\72.jpg", true, false, 18, "رنگ مو بانوان" },
                    { 73, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6975), "\\Images\\services\\73.jpg", true, false, 18, "براشینگ مو" },
                    { 74, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6976), "\\Images\\services\\74.jpg", true, false, 18, "کوتاهی مو بانوان" },
                    { 75, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6977), "\\Images\\services\\75.jpg", true, false, 19, "مراقبت و نگهداری" },
                    { 76, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6978), "\\Images\\services\\76.jpg", true, false, 19, "معاینه پزشکی" },
                    { 77, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6979), "\\Images\\services\\77.webp", true, false, 19, "پیراپزشکی" },
                    { 78, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6981), "\\Images\\services\\78.jpg", true, false, 20, "هتل های حیوانات خانگی" },
                    { 79, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6982), "\\Images\\services\\79.jpg", true, false, 20, "خدمات دامپزشکی در محل" },
                    { 80, new DateTime(2025, 2, 19, 16, 19, 37, 626, DateTimeKind.Local).AddTicks(6983), "\\Images\\services\\80.jpg", true, false, 20, "خدمات شستشو و آراش حیوانات خانگی" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "BasePrice", "CreatedAt", "CustomerId", "CustomerId1", "Description", "DoneTime", "IsDeleted", "ServiceSubCategoryId", "ServiceSubCategoryId1", "Status" },
                values: new object[,]
                {
                    { 1, 100m, new DateTime(2025, 2, 19, 12, 49, 37, 624, DateTimeKind.Utc).AddTicks(4639), 1, null, "Request for a detailed consultation on product X", null, false, 1, null, 1 },
                    { 2, 150m, new DateTime(2025, 2, 18, 12, 49, 37, 624, DateTimeKind.Utc).AddTicks(5050), 1, null, "Urgent request for a technical issue in product Y", new DateTime(2025, 2, 20, 12, 49, 37, 624, DateTimeKind.Utc).AddTicks(5138), false, 2, null, 1 },
                    { 3, 200m, new DateTime(2025, 2, 17, 12, 49, 37, 624, DateTimeKind.Utc).AddTicks(5195), 1, null, "Completed request for installation of service Z", new DateTime(2025, 2, 18, 12, 49, 37, 624, DateTimeKind.Utc).AddTicks(5196), false, 3, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "Id", "Amount", "Descripsion", "ExpertId", "IsActive", "IsDeleted", "IsWinner", "RequestId", "Status", "SuggestedDate", "SuggestedDo" },
                values: new object[,]
                {
                    { 1, 150m, "Detailed consultation suggestion for product X", 1, true, false, false, 1, 1, new DateTime(2025, 2, 19, 12, 49, 37, 629, DateTimeKind.Utc).AddTicks(2773), new DateTime(2025, 2, 20, 12, 49, 37, 629, DateTimeKind.Utc).AddTicks(2854) },
                    { 2, 200m, "Urgent technical issue resolution suggestion for product Y", 1, true, false, false, 2, 1, new DateTime(2025, 2, 17, 12, 49, 37, 629, DateTimeKind.Utc).AddTicks(3192), new DateTime(2025, 2, 20, 12, 49, 37, 629, DateTimeKind.Utc).AddTicks(3193) },
                    { 3, 180m, "Installation suggestion for service Z", 1, true, false, false, 3, 1, new DateTime(2025, 2, 16, 12, 49, 37, 629, DateTimeKind.Utc).AddTicks(3195), new DateTime(2025, 2, 21, 12, 49, 37, 629, DateTimeKind.Utc).AddTicks(3196) }
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
                name: "IX_Comments_ExpertId1",
                table: "Comments",
                column: "ExpertId1");

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
