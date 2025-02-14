using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration;

public class SubCategoryConfigurations : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(sc => sc.ImagePath)
               .HasMaxLength(500);

        builder.Property(sc => sc.IsActive)
               .HasDefaultValue(true);

        builder.Property(sc => sc.CreatAt)
               .HasDefaultValueSql("GETDATE()");

        builder.HasOne(sc => sc.Category)
               .WithMany(c => c.SubCategories)
               .HasForeignKey(sc => sc.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(sc => sc.ServiceSubCategories)
               .WithOne(ssc => ssc.SubCategory)
               .HasForeignKey(ssc => ssc.SubCategoryId);

        builder.HasData(
          // CategoryId = 1
          new SubCategory { Id = 1, Title = "نظافت و پذیرایی", CategoryId = 1, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 2, Title = "شستشو", CategoryId = 1, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 3, Title = "کارواش و دیتیلینگ", CategoryId = 1, IsActive = true, CreatAt = DateTime.Now },

          // CategoryId = 2
          new SubCategory { Id = 4, Title = "سرمایش و گرمایش", CategoryId = 2, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 5, Title = "تعمیرات ساختمان", CategoryId = 2, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 6, Title = "لوله کشی", CategoryId = 2, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 7, Title = "طراحی و بازسازی ساختمان", CategoryId = 2, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 8, Title = "برقکاری", CategoryId = 2, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 9, Title = "چوب و کابینت", CategoryId = 2, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 10, Title = "خدمات شیشه ای ساختمان", CategoryId = 2, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 11, Title = "باغبانی و فضای سبز", CategoryId = 2, IsActive = true, CreatAt = DateTime.Now },

          // CategoryId = 3
          new SubCategory { Id = 12, Title = "نصب و تعمیر لوازم خانگی", CategoryId = 3, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 13, Title = "خدمات کامپیوتری", CategoryId = 3, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 14, Title = "تعمیرات موبایل", CategoryId = 3, IsActive = true, CreatAt = DateTime.Now },

          // CategoryId = 4
          new SubCategory { Id = 15, Title = "باربری و جابجایی", CategoryId = 4, IsActive = true, CreatAt = DateTime.Now },

          // CategoryId = 5
          new SubCategory { Id = 16, Title = "خدمات و تعمیرات خودرو", CategoryId = 5, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 17, Title = "کارواش و دیتیلینگ", CategoryId = 5, IsActive = true, CreatAt = DateTime.Now },

          // CategoryId = 6
          new SubCategory { Id = 18, Title = "زیبایی بانوان", CategoryId = 6, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 19, Title = "پزشکی و پرستاری", CategoryId = 6, IsActive = true, CreatAt = DateTime.Now },
          new SubCategory { Id = 20, Title = "حیوانات خانگی", CategoryId = 6, IsActive = true, CreatAt = DateTime.Now }
          
      );

    }
}

