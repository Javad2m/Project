using App.Domain.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
               .IsRequired()
               .HasMaxLength(255);

        builder.HasMany(c => c.Customers)
               .WithOne(c => c.City)
               .HasForeignKey(c => c.CityId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(c => c.Experts)
               .WithOne(e => e.City)
               .HasForeignKey(e => e.CityId)
               .OnDelete(DeleteBehavior.SetNull);

        // Seed Test Data
        builder.HasData(
       new City { Id = 1, Title = "تهران" },
       new City { Id = 2, Title = "مشهد" },
       new City { Id = 3, Title = "اصفهان" },
       new City { Id = 4, Title = "شیراز" },
       new City { Id = 5, Title = "تبریز" },
       new City { Id = 6, Title = "اهواز" },
       new City { Id = 7, Title = "کرمانشاه" },
       new City { Id = 8, Title = "زاهدان" },
       new City { Id = 9, Title = "یزد" },
       new City { Id = 10, Title = "اراک" },
       new City { Id = 11, Title = "کرمان" },
       new City { Id = 12, Title = "همدان" },
       new City { Id = 13, Title = "قم" },
       new City { Id = 14, Title = "رشت" },
       new City { Id = 15, Title = "ارومیه" },
       new City { Id = 16, Title = "سنندج" },
       new City { Id = 17, Title = "گرگان" },
       new City { Id = 18, Title = "شاهرود" },
       new City { Id = 19, Title = "بوشهر" },
       new City { Id = 20, Title = "خرم‌آباد" },
       new City { Id = 21, Title = "قزوین" },
       new City { Id = 22, Title = "ساری" },
       new City { Id = 23, Title = "ماهشهر" },
       new City { Id = 24, Title = "بابل" },
       new City { Id = 25, Title = "زنجان" }
       );
    }
}


