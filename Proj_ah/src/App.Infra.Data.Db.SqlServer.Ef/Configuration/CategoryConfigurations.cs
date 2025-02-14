using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(c => c.IsActive)
               .IsRequired();

        builder.Property(c => c.CreatAt)
               .IsRequired()
               .HasDefaultValueSql("GETDATE()");

        builder.HasData(
           new Category { Id = 1, Title = "تمیز کاری", IsActive = true, CreatAt = DateTime.Now, ImagePath = "\\Images\\icon\\tamiz.png" },
           new Category { Id = 2, Title = "ساختمان", IsActive = true, CreatAt = DateTime.Now, ImagePath = "\\Images\\icon\\sakhteman.png" },
           new Category { Id = 3, Title = "تعمیرات اشیا", IsActive = true, CreatAt = DateTime.Now, ImagePath = "\\Images\\icon\\ashya.png" },
           new Category { Id = 4, Title = "اسباب کشی و حمل بار", IsActive = true, CreatAt = DateTime.Now, ImagePath = "\\Images\\icon\\asbabkeshi.png" },
           new Category { Id = 5, Title = "خودرو", IsActive = true, CreatAt = DateTime.Now, ImagePath = "\\Images\\icon\\khodro.png" },
           new Category { Id = 6, Title = "سلامت و زیبایی", IsActive = true, CreatAt = DateTime.Now, ImagePath = "\\Images\\icon\\zibaii.png" }
     

        );
    }
}



