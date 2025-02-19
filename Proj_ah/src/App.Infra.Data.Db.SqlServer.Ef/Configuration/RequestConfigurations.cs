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

public class RequestConfigurations : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Description)
            .HasMaxLength(2000)
            .IsRequired(false);

        builder.Property(r => r.Status)
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.Property(r => r.DoneTime)
            .IsRequired(false);

        builder.Property(r => r.BasePrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.HasOne(r => r.Customer)
            .WithMany()
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.ServiceSubCategory)
            .WithMany()
            .HasForeignKey(r => r.ServiceSubCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Suggestions)
            .WithOne(s => s.Request)
            .HasForeignKey(s => s.RequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Images)
            .WithOne(i => i.Request)
            .HasForeignKey(i => i.RequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
       new Request
       {
           Id = 1,
           CustomerId = 1, 
           Status = RequestStatusEnum.CheckingAndWaitingExpert,
           Description = "Request for a detailed consultation on product X",
           ServiceSubCategoryId = 1, 
           CreatedAt = DateTime.UtcNow,
           DoneTime = null,
           BasePrice = 100.00f,
           IsDeleted = false
       },
       new Request
       {
           Id = 2,
           CustomerId = 1, 
           Status = RequestStatusEnum.CheckingAndWaitingExpert,
           Description = "Urgent request for a technical issue in product Y",
           ServiceSubCategoryId = 2, 
           CreatedAt = DateTime.UtcNow.AddDays(-1),
           DoneTime = DateTime.UtcNow.AddDays(1),
           BasePrice = 150.00f,
           IsDeleted = false
       },
       new Request
       {
           Id = 3,
           CustomerId = 1, 
           Status = RequestStatusEnum.CheckingAndWaitingExpert,
           Description = "Completed request for installation of service Z",
           ServiceSubCategoryId = 3,
           CreatedAt = DateTime.UtcNow.AddDays(-2),
           DoneTime = DateTime.UtcNow.AddDays(-1),
           BasePrice = 200.00f,
           IsDeleted = false
       }
   );
    }
}
