using App.Domain.Core.Entities;
using App.Domain.Core.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration;

public class ExpertConfigurations : IEntityTypeConfiguration<Expert>
{
    public void Configure(EntityTypeBuilder<Expert> builder)
    {

        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName)
               .HasMaxLength(100);

        builder.Property(e => e.LastName)
               .HasMaxLength(100);

        builder.Property(e => e.PhoneNumber)
               .HasMaxLength(15);

        builder.Property(e => e.Email)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(e => e.ImagePath)
               .HasMaxLength(255);

        builder.Property(e => e.Wallet)
               .HasColumnType("decimal(18,2)")
               .HasDefaultValue(0); 

        builder.Property(e => e.IsActive)
               .HasDefaultValue(false); 

        builder.Property(e => e.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.Description)
               .HasMaxLength(500);  

        builder.Property(e => e.Gender)
               .IsRequired(false);

       
        builder.HasOne(e => e.ApplicationUser)
               .WithOne(u => u.Expert)
               .HasForeignKey<Expert>(e => e.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);


        

        //builder.HasOne(e => e.City)
        //       .WithMany()
        //       .HasForeignKey(e => e.CityId)
        //       .OnDelete(DeleteBehavior.SetNull);


        builder.HasMany(e => e.Skills)
             .WithMany(e => e.Experts);

        // Seed Test Data
        builder.HasData(new Expert
        {
            Id = 1,
            FirstName = "Ali",
            LastName = "Abd",
            Email = "Ali@gmail.com",
            Wallet = 0,  
            IsActive = false,
            CreatedAt = DateTime.Now,
            ApplicationUserId = 3,  
            CityId = 1,  
            Description = "Expert in web development and software architecture.",
            Gender = GenderEnum.Male 
        });
    }
}

