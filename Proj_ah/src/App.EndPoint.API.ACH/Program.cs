using App.Domain.AppServices;
using App.Domain.Core.Contracts;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Configs;
using App.Domain.Services;
using App.EndPoint.API.ACH.ActionFillter;
using App.Infra.Access.Dapper;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using App.Infra.Data.Repos.Ef.Repositories;
using Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Dapper;

var builder = WebApplication.CreateBuilder(args);


//var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found."); ;


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var siteSetting = configuration.GetSection("SiteSetting").Get<SiteSettings>();

builder.Services.AddSingleton(siteSetting);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(siteSetting.ConnectionStrings.SqlConnection));






// repo
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IServiceSubCategoryRepository, ServiceSubCategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();


// services
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IExpertServices, ExpertServices>();
builder.Services.AddScoped<ISuggestionServices, SuggestionServices>();
builder.Services.AddScoped<IRequestServices, RequestServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICommentServices, CommentServices>();
builder.Services.AddScoped<IServiceSubCategoryServices, ServiceSubCategoryServices>();
builder.Services.AddScoped<ISubCategoryServices, SubCategoryServices>();
builder.Services.AddScoped<ICityServices, CityServices>();


//appServices
builder.Services.AddScoped<IAccountAppServices, AccountAppServices>();
builder.Services.AddScoped<IAdminAppServices, AdminAppServices>();
builder.Services.AddScoped<ICustomerAppServices, CustomerAppServices>();
builder.Services.AddScoped<IExpertAppServices, ExpertAppServices>();
builder.Services.AddScoped<ISuggestionAppServices, SuggestionAppServices>();
builder.Services.AddScoped<IRequestAppServices, RequestAppServices>();
builder.Services.AddScoped<ICategoryAppServices, CategoryAppServices>();
builder.Services.AddScoped<ICommentAppServices, CommentAppServices>();
builder.Services.AddScoped<IServiceSubCategoryAppServices, ServiceSubCategoryAppServices>();
builder.Services.AddScoped<ISubCategoryAppServices, SubCategoryAppServices>();
builder.Services.AddScoped<ICityAppServices, CityAppServices>();


builder.Services.AddScoped<FillterApiKey>();


builder.Services.AddMemoryCache();


builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>()
 .AddErrorDescriber<PersianIdentityErrorDescriber>();




// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<FillterApiKey>();
});// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
