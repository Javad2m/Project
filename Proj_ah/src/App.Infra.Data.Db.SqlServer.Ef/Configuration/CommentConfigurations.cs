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

public class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CommentText)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(c => c.CreatAt)
            .IsRequired();

      

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true);

        builder.Property(c => c.IsAccept)
            .HasDefaultValue(false);

        builder.HasOne(c => c.Customer)
       .WithMany(cu => cu.Comments)
       .HasForeignKey(c => c.CustomerId)
       .OnDelete(DeleteBehavior.NoAction);


        //builder.HasOne(c => c.Expert)
        //    .WithMany()
        //    .HasForeignKey(c => c.ExpertId)
        //    .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
        new Comment
        {
            Id = 1,
            CommentText = "This is a great comment!",
            CreatAt = DateTime.Now,
            CustomerId = 1,
            ExpertId = 1,
            Score = 5,
            IsActive = true,
            IsAccept = true,
            IsDeleted = false
            
        },
        new Comment
        {
            Id = 2,
            CommentText = "This is another comment.",
            CreatAt = DateTime.Now,
            CustomerId = 1,
            ExpertId = 1,
            Score = 4,
            IsActive = true,
            IsAccept = false,
            IsDeleted = false
        },
          new Comment
          {
              Id = 3,
              CommentText = "This is bad comment.",
              CreatAt = DateTime.Now,
              CustomerId = 1,
              ExpertId = 1,
              Score = 3,
              IsActive = true,
              IsAccept = false,
              IsDeleted = false
          }
    );
    }
}
