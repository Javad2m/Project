using App.Domain.Core.Entities;
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


    }

}
