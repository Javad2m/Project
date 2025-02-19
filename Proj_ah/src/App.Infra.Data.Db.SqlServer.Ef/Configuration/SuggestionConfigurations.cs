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

public class SuggestionConfigurations : IEntityTypeConfiguration<Suggestion>
{
    public void Configure(EntityTypeBuilder<Suggestion> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Descripsion)
            .HasMaxLength(1000);

        builder.Property(s => s.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.SuggestedDate)
            .IsRequired();

        builder.Property(s => s.IsActive)
            .HasDefaultValue(true);

        builder.Property(s => s.Status)
            .IsRequired();

        builder.HasOne(s => s.Request)
            .WithMany(r => r.Suggestions)
            .HasForeignKey(s => s.RequestId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasOne(s => s.Expert) // 
           .WithMany(e => e.Suggestions)
           .HasForeignKey(s => s.ExpertId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
       new Suggestion
       {
           Id = 1,
           RequestId = 1, 
           ExpertId = 1,  
           Descripsion = "Detailed consultation suggestion for product X",
           Amount = 150.00f,
           IsWinner = false,
           SuggestedDate = DateTime.UtcNow,
           SuggestedDo = DateTime.UtcNow.AddDays(1),
           IsActive = true,
           Status = SuggestionStatusEnum.AwaitingReview,
           IsDeleted = false
       },
       new Suggestion
       {
           Id = 2,
           RequestId = 2, 
           ExpertId = 1,  
           Descripsion = "Urgent technical issue resolution suggestion for product Y",
           Amount = 200.00f,
           IsWinner = false,
           SuggestedDate = DateTime.UtcNow.AddDays(-2),
           SuggestedDo = DateTime.UtcNow.AddDays(1),
           IsActive = true,
           Status = SuggestionStatusEnum.AwaitingReview,
           IsDeleted = false
       },
       new Suggestion
       {
           Id = 3,
           RequestId = 3, 
           ExpertId = 1,  
           Descripsion = "Installation suggestion for service Z",
           Amount = 180.00f,
           IsWinner = false,
           SuggestedDate = DateTime.UtcNow.AddDays(-3),
           SuggestedDo = DateTime.UtcNow.AddDays(2),
           IsActive = true,
           Status = SuggestionStatusEnum.AwaitingReview,
           IsDeleted = false
       }
   );
    }

}
