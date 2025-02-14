using App.Domain.Core.Entities;
using App.Domain.Core.Entities.BaseEntities;
using App.Infra.Data.Db.SqlServer.Ef.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Common;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.ApplyConfiguration(new AdminConfigurations());
        modelBuilder.ApplyConfiguration(new CategoryConfigurations());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfigurations());
        modelBuilder.ApplyConfiguration(new CustomerConfigurations());
        modelBuilder.ApplyConfiguration(new ExpertConfigurations());
        modelBuilder.ApplyConfiguration(new ImageConfigurations());
        modelBuilder.ApplyConfiguration(new RequestConfigurations());
        modelBuilder.ApplyConfiguration(new ServicesSubCategoryConfigurations());
        modelBuilder.ApplyConfiguration(new SubCategoryConfigurations());
        modelBuilder.ApplyConfiguration(new SuggestionConfigurations());




        ApplicationUserConfigurations.SeedUsers(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Expert> Experts { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<ServiceSubCategory> ServiceSubCategories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Suggestion> Suggestions { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Image> Images { get; set; }
}
