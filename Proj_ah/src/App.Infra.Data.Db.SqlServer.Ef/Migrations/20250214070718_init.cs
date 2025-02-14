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
                    { 1, 0, "62c52fac-4bc3-47ec-9c63-ec4f582d186c", "Admin@gmail.com", false, false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEI6IJjCz2LAZYJNusNu2APyeTeVTVizwMiY5gZDTteUwJMjX4hXKGSKoFMhQw9jhXg==", null, false, "b91b4de7-ab64-42f2-a5b1-1fa3a9525e3f", false, "Admin@gmail.com" },
                    { 2, 0, "ca67a02c-0e0d-42a5-a743-875ce378e308", "Javad@gmail.com", false, false, false, null, "JAVAD@GMAIL.COM", "JAVAD@GMAIL.COM", "AQAAAAIAAYagAAAAEHCdfk44tZXQ59TgH3yMh2ZRbXRuAQOTs4lluHi/WQhhVz6pSLlwlOXeP+ppsM0DLg==", null, false, "10b19a55-7b10-45b2-b02e-4c3a5e5d570e", false, "Javad@gmail.com" },
                    { 3, 0, "e365a241-0db6-4a65-a03c-c2dbebd1554f", "Ali@gmail.com", false, false, false, null, "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAEEGlrO/2riHuqYSKkh9WM4YRCHqgP90g9tc/iqPmJOpk+S0ymMbwd++wnDlDVROPTw==", null, false, "be73f1ea-9583-4e00-8576-d376741c5d56", false, "Ali@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatAt", "ImagePath", "IsActive", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 14, 10, 37, 17, 851, DateTimeKind.Local).AddTicks(5147), "\\Images\\icon\\tamiz.png", true, false, "تمیز کاری" },
                    { 2, new DateTime(2025, 2, 14, 10, 37, 17, 851, DateTimeKind.Local).AddTicks(5387), "\\Images\\icon\\sakhteman.png", true, false, "ساختمان" },
                    { 3, new DateTime(2025, 2, 14, 10, 37, 17, 851, DateTimeKind.Local).AddTicks(5389), "\\Images\\icon\\ashya.png", true, false, "تعمیرات اشیا" },
                    { 4, new DateTime(2025, 2, 14, 10, 37, 17, 851, DateTimeKind.Local).AddTicks(5390), "\\Images\\icon\\asbabkeshi.png", true, false, "اسباب کشی و حمل بار" },
                    { 5, new DateTime(2025, 2, 14, 10, 37, 17, 851, DateTimeKind.Local).AddTicks(5392), "\\Images\\icon\\khodro.png", true, false, "خودرو" },
                    { 6, new DateTime(2025, 2, 14, 10, 37, 17, 851, DateTimeKind.Local).AddTicks(5393), "\\Images\\icon\\zibaii.png", true, false, "سلامت و زیبایی" }
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
                values: new object[] { 1, 1, new DateTime(2025, 2, 14, 10, 37, 17, 849, DateTimeKind.Local).AddTicks(4321), "Admin@gmail.com", "Javad", null, true, false, "Moradi", 100.5m });

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
                values: new object[] { 1, 2, 1, null, new DateTime(2025, 2, 14, 10, 37, 17, 862, DateTimeKind.Local).AddTicks(3691), "Javad", null, true, false, "Sadeghi", "Javad@gmail.com", null });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "ApplicationUserId", "CityId", "CityId1", "CreatedAt", "Description", "Email", "FirstName", "Gender", "ImagePath", "IsDeleted", "LastName", "PhoneNumber" },
                values: new object[] { 1, 3, 1, null, new DateTime(2025, 2, 14, 10, 37, 17, 866, DateTimeKind.Local).AddTicks(8495), "Expert in web development and software architecture.", "Ali@gmail.com", "Ali", 1, null, false, "Abd", null });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatAt", "ImagePath", "IsActive", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(507), null, true, false, "نظافت و پذیرایی" },
                    { 2, 1, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(618), null, true, false, "شستشو" },
                    { 3, 1, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(620), null, true, false, "کارواش و دیتیلینگ" },
                    { 4, 2, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(621), null, true, false, "سرمایش و گرمایش" },
                    { 5, 2, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(622), null, true, false, "تعمیرات ساختمان" },
                    { 6, 2, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(623), null, true, false, "لوله کشی" },
                    { 7, 2, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(624), null, true, false, "طراحی و بازسازی ساختمان" },
                    { 8, 2, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(625), null, true, false, "برقکاری" },
                    { 9, 2, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(626), null, true, false, "چوب و کابینت" },
                    { 10, 2, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(627), null, true, false, "خدمات شیشه ای ساختمان" },
                    { 11, 2, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(628), null, true, false, "باغبانی و فضای سبز" },
                    { 12, 3, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(629), null, true, false, "نصب و تعمیر لوازم خانگی" },
                    { 13, 3, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(630), null, true, false, "خدمات کامپیوتری" },
                    { 14, 3, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(631), null, true, false, "تعمیرات موبایل" },
                    { 15, 4, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(632), null, true, false, "باربری و جابجایی" },
                    { 16, 5, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(633), null, true, false, "خدمات و تعمیرات خودرو" },
                    { 17, 5, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(634), null, true, false, "کارواش و دیتیلینگ" },
                    { 18, 6, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(635), null, true, false, "زیبایی بانوان" },
                    { 19, 6, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(636), null, true, false, "پزشکی و پرستاری" },
                    { 20, 6, new DateTime(2025, 2, 14, 10, 37, 17, 875, DateTimeKind.Local).AddTicks(637), null, true, false, "حیوانات خانگی" }
                });

            migrationBuilder.InsertData(
                table: "ServiceSubCategories",
                columns: new[] { "Id", "CreatAt", "ImagePath", "IsActive", "IsDeleted", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8253), "\\Images\\services\\1.jpg", true, false, 1, "خدمات نظافت و منزل" },
                    { 2, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8464), "\\Images\\services\\2.jpg", true, false, 1, "سرویس ویژه نظافت" },
                    { 3, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8465), "\\Images\\services\\3.jpg", true, false, 1, "سرویس لوکس نظافت" },
                    { 4, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8467), "\\Images\\services\\4.jpg", true, false, 1, "نظافت راه پله" },
                    { 5, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8468), "\\Images\\services\\5.jpg", true, false, 1, "سرویس نظافت فوری" },
                    { 6, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8469), "\\Images\\services\\6.jpg", true, false, 1, "پذیرایی" },
                    { 7, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8470), "\\Images\\services\\7.jpg", true, false, 1, "کارگر ساده" },
                    { 8, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8471), "\\Images\\services\\8.jpg", true, false, 1, "سمپاشی فضای داخلی" },
                    { 9, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8472), "\\Images\\services\\9.jpg", true, false, 2, "شستشو در محل" },
                    { 10, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8473), "\\Images\\services\\10.jpg", true, false, 2, "قالیشویی" },
                    { 11, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8474), "\\Images\\services\\11.png", true, false, 2, "خشکشویی" },
                    { 12, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8476), "\\Images\\services\\12.jpg", true, false, 2, "پرده شویی" },
                    { 13, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8477), "\\Images\\services\\13.jpg", true, false, 3, "کارواش سیار" },
                    { 14, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8478), "\\Images\\services\\14.jpg", true, false, 3, "سرامیک خودرو" },
                    { 15, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8479), "\\Images\\services\\15.jpg", true, false, 3, "موتورشویی خودرو" },
                    { 16, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8480), "\\Images\\services\\16.jpg", true, false, 4, "تعمیر و سرویس پکیج" },
                    { 17, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8491), "\\Images\\services\\17.jpg", true, false, 4, "تعمیر و سرویس آبگرم کن" },
                    { 18, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8492), "\\Images\\services\\18.jpg", true, false, 4, "نصب و تعمیر شوفاژ" },
                    { 19, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8493), "\\Images\\services\\19.jpg", true, false, 4, "تعمیر و نگهداری موتورخانه" },
                    { 20, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8494), "\\Images\\services\\20.jpg", true, false, 5, "سنگ کاری" },
                    { 21, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8495), "\\Images\\services\\21.jpeg", true, false, 5, "نقاشی ساختمان" },
                    { 22, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8496), "\\Images\\services\\22.jpg", true, false, 5, "نصب کاغذ دیواری" },
                    { 23, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8497), "\\Images\\services\\23.jpg", true, false, 5, "ساخت و نصب توری" },
                    { 24, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8498), "\\Images\\services\\24.jpg", true, false, 5, "بنایی" },
                    { 25, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8500), "\\Images\\services\\25.jpg", true, false, 5, "کلید سازی" },
                    { 26, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8501), "\\Images\\services\\26.jpg", true, false, 5, "دریل کاری" },
                    { 27, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8502), "\\Images\\services\\27.jpg", true, false, 6, "خدمات لوله کشی ساختمان" },
                    { 28, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8503), "\\Images\\services\\28.jpg", true, false, 6, "پمپ و منبع آب" },
                    { 29, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8504), "\\Images\\services\\29.webp", true, false, 6, "لوله کشی گاز" },
                    { 30, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8505), "\\Images\\services\\30.jpg", true, false, 6, "نصب و تعمیر وال هنگ" },
                    { 31, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8506), "\\Images\\services\\31.webp", true, false, 7, "خدمات بازسازی خانه" },
                    { 32, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8507), "\\Images\\services\\32.jpg", true, false, 7, "مشاوره و بازسازی خانه" },
                    { 33, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8509), "\\Images\\services\\33.jpg", true, false, 7, "دکوراسیون و طراحی ساختمان" },
                    { 34, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8510), "\\Images\\services\\34.jpg", true, false, 8, "سیم کشی و کابل کشی" },
                    { 35, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8518), "\\Images\\services\\35.jpg", true, false, 8, "رفع اتصالی" },
                    { 36, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8519), "\\Images\\services\\36.jpg", true, false, 8, "نصب لوستر و چراغ" },
                    { 37, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8520), "\\Images\\services\\37.jpg", true, false, 8, "کلید و پریز" },
                    { 38, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8522), "\\Images\\services\\38.png", true, false, 8, "نصب و تعویز فیوز" },
                    { 39, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8523), "\\Images\\services\\39.jpg", true, false, 8, "نصب و تعمیر کرکره برقی" },
                    { 40, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8524), "\\Images\\services\\40.webp", true, false, 9, "نجاری" },
                    { 41, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8525), "\\Images\\services\\41.jpg", true, false, 9, "تعمیرات مبلمان" },
                    { 42, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8526), "\\Images\\services\\42.jpg", true, false, 9, "خدمات درب چوبی و ضدسرقت" },
                    { 43, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8527), "\\Images\\services\\43.png", true, false, 10, "پارتیشن شیشه ای" },
                    { 44, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8528), "\\Images\\services\\44.jpg", true, false, 10, "شیشه بری و آینه کاری" },
                    { 45, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8529), "\\Images\\services\\45.jpg", true, false, 10, "هندریل شیشه ای" },
                    { 46, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8531), "\\Images\\services\\46.jpg", true, false, 10, "شیشه ریلی اسلاید" },
                    { 47, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8532), "\\Images\\services\\47.webp", true, false, 11, "خدمات باغبانی" },
                    { 48, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8533), "\\Images\\services\\48.jpg", true, false, 11, "کاشت و تعویض گلدان" },
                    { 49, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8534), "\\Images\\services\\49.webp", true, false, 11, "مشاوره گل و گیاه" },
                    { 50, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8535), "\\Images\\services\\50.jpg", true, false, 12, "تعمیر جارو برقی" },
                    { 51, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8536), "\\Images\\services\\51.jpg", true, false, 12, "تعمیر چرخ خیاطی" },
                    { 52, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8537), "\\Images\\services\\52.jpg", true, false, 12, "تعمیر پنکه" },
                    { 53, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8545), "\\Images\\services\\53.jpg", true, false, 13, "تعمیر کامپیوتر و لپ تاب" },
                    { 54, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8547), "\\Images\\services\\54.jpg", true, false, 13, "تعمیر ماشین های اداری" },
                    { 55, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8548), "\\Images\\services\\55.jpg", true, false, 13, "مودم و اینترنت" },
                    { 56, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8549), "\\Images\\services\\56.jpg", true, false, 14, "خدمات نرم افزاری" },
                    { 57, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8550), "\\Images\\services\\57.jpg", true, false, 14, "خدمات باتری" },
                    { 58, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8551), "\\Images\\services\\58.webp", true, false, 14, "خدمات دوربین" },
                    { 59, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8552), "\\Images\\services\\59.jpg", true, false, 15, "خدمات اسباب کشی" },
                    { 60, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8553), "\\Images\\services\\60.jpg", true, false, 15, "سرویس بسته بندی" },
                    { 61, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8555), "\\Images\\services\\61.jpg", true, false, 15, "کارگر جابه جایی" },
                    { 62, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8556), "\\Images\\services\\62.webp", true, false, 15, "اجاره انبار و سوله" },
                    { 63, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8557), "\\Images\\services\\63.jpg", true, false, 16, "خدمات خودرو" },
                    { 64, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8558), "\\Images\\services\\64.jpg", true, false, 16, "باتری به باتری" },
                    { 65, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8559), "\\Images\\services\\65.png", true, false, 16, "امداد خودرو" },
                    { 66, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8560), "\\Images\\services\\66.jpg", true, false, 16, "حمل خودرو" },
                    { 67, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8561), "\\Images\\services\\67.jpg", true, false, 17, "کارواش سیار" },
                    { 68, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8562), "\\Images\\services\\68.jpg", true, false, 17, "کارواش نانو" },
                    { 69, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8563), "\\Images\\services\\69.jpg", true, false, 17, "موتورشویی خودرو" },
                    { 70, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8564), "\\Images\\services\\70.jpg", true, false, 17, "احیای رنگ" },
                    { 71, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8565), "\\Images\\services\\71.jpg", true, false, 18, "خدمات ناخن" },
                    { 72, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8567), "\\Images\\services\\72.jpg", true, false, 18, "رنگ مو بانوان" },
                    { 73, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8568), "\\Images\\services\\73.jpg", true, false, 18, "براشینگ مو" },
                    { 74, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8569), "\\Images\\services\\74.jpg", true, false, 18, "کوتاهی مو بانوان" },
                    { 75, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8570), "\\Images\\services\\75.jpg", true, false, 19, "مراقبت و نگهداری" },
                    { 76, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8571), "\\Images\\services\\76.jpg", true, false, 19, "معاینه پزشکی" },
                    { 77, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8572), "\\Images\\services\\77.webp", true, false, 19, "پیراپزشکی" },
                    { 78, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8573), "\\Images\\services\\78.jpg", true, false, 20, "هتل های حیوانات خانگی" },
                    { 79, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8574), "\\Images\\services\\79.jpg", true, false, 20, "خدمات دامپزشکی در محل" },
                    { 80, new DateTime(2025, 2, 14, 10, 37, 17, 873, DateTimeKind.Local).AddTicks(8575), "\\Images\\services\\80.jpg", true, false, 20, "خدمات شستشو و آراش حیوانات خانگی" }
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
