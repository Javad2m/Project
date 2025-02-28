using App.Domain.AppServices;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Entities.Configs;
using App.Domain.Services;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using App.Infra.Data.Repos.Ef.Repositories;
using Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(o => {
    o.ClearProviders();
    o.AddSerilog();
}).UseSerilog((context, config) =>
{
    config.WriteTo.Console();
    config.WriteTo.Seq("http://localhost:5341", apiKey: "IwCY4CHobFsgkD0fJXw8");
});




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

var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found."); ;


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var siteSetting = configuration.GetSection("SiteSetting").Get<SiteSettings>();

builder.Services.AddSingleton(siteSetting);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(siteSetting.ConnectionStrings.SqlConnection));


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
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

//app.UseSerilogRequestLogging();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
