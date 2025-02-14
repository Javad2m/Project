using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration;

public class ApplicationUserConfigurations
{

    public static void SeedUsers(ModelBuilder builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        //SeedUsers
        var users = new List<ApplicationUser>
        {
            new ApplicationUser()
            {
                Id = 1,
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            },
            new ApplicationUser()
        {
            Id = 2,
            UserName = "Javad@gmail.com",
            NormalizedUserName = "JAVAD@GMAIL.COM",
            Email = "Javad@gmail.com",
            NormalizedEmail = "JAVAD@GMAIL.COM",
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString()
        },
        new ApplicationUser()
        {
            Id = 3,
            UserName = "Ali@gmail.com",
            NormalizedUserName = "ALI@GMAIL.COM",
            Email = "Ali@gmail.com",
            NormalizedEmail = "ALI@GMAIL.COM",
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString()
        },
        };

        foreach (var user in users)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "123456");
            builder.Entity<ApplicationUser>().HasData(user);
        }

        // Seed Roles
        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole<int>() { Id = 2, Name = "Customer", NormalizedName = "Customer" },
            new IdentityRole<int>() { Id = 3, Name = "Expert", NormalizedName = "Expert" }
        );

        //Seed Role To Users
        builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
             new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
              new IdentityUserRole<int>() { RoleId = 3, UserId = 3 }
        );
    }
}
