using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
               .HasMaxLength(100);

        builder.Property(c => c.LastName)
               .HasMaxLength(100);

        builder.Property(c => c.PhoneNumber)
               .HasMaxLength(15);

        builder.Property(c => c.Mail)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(c => c.ImagePath)
               .HasMaxLength(255);

        builder.Property(c => c.Wallet)
               .HasColumnType("decimal(18,2)")
               .HasDefaultValue(0); 

        builder.Property(c => c.IsActive)
               .HasDefaultValue(false); 

        builder.Property(c => c.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        builder.HasOne(c => c.ApplicationUser)
               .WithOne(u => u.Customer)
               .HasForeignKey<Customer>(c => c.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.City)
               .WithMany()
               .HasForeignKey(c => c.CityId)
               .OnDelete(DeleteBehavior.SetNull);

        //builder.HasMany(c => c.Comments)
        //       .WithOne()
        //       .HasForeignKey(comment => comment.CustomerId)
        //       .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Requests)
               .WithOne()
               .HasForeignKey(request => request.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new Customer
        {
            Id = 1,
            FirstName = "Javad",
            LastName = "Sadeghi",
            Mail = "Javad@gmail.com",
            Wallet = 0,  
            IsActive = true,
            CreatedAt = DateTime.Now,
            ApplicationUserId = 2,  
            CityId = 1  
        });     
    }
}
