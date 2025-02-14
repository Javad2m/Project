using App.Domain.Core.Entities;
using App.Domain.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration;

public class AdminConfigurations : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {

        builder.HasKey(a => a.Id);

        // Properties configuration
        builder.Property(a => a.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.Email)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(a => a.ImagePath)
               .HasMaxLength(255);

        builder.Property(a => a.Wallet)
               .HasColumnType("decimal(18,2)")
               .HasDefaultValue(0); ;

        builder.Property(a => a.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        builder.Property(a => a.IsActive)
               .HasDefaultValue(true);

        // Relationship with ApplicationUser (1:1 relationship)
        builder.HasOne(a => a.ApplicationUser)
               .WithOne(u => u.Admin)
               .HasForeignKey<Admin>(a => a.ApplicationUserId)
               .OnDelete(DeleteBehavior.NoAction);

        // Seed Test Data
        builder.HasData(new Admin
        {
            Id = 1,
            FirstName = "Javad",
            LastName = "Moradi",
            Email = "Admin@gmail.com",
            Wallet = 100.50f,
            CreatedAt = DateTime.Now,
            IsActive = true,
            ApplicationUserId = 1
        });
    
}
}
