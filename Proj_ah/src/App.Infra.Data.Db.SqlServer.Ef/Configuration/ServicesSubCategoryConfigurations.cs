using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration;

public class ServicesSubCategoryConfigurations : IEntityTypeConfiguration<ServiceSubCategory>
{
    public void Configure(EntityTypeBuilder<ServiceSubCategory> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Title)
               .IsRequired()
               .HasMaxLength(200);
        builder.Property(s => s.ImagePath)
               .HasMaxLength(500);
        builder.Property(s => s.CreatAt)
               .HasDefaultValueSql("GETDATE()");
        builder.Property(s => s.IsActive)
               .HasDefaultValue(true);

        builder.HasOne(s => s.SubCategory)
               .WithMany(sub => sub.ServiceSubCategories)
               .HasForeignKey(s => s.SubCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
     // ساب کتگوری 1
     new ServiceSubCategory { Id = 1, Title = "خدمات نظافت و منزل", SubCategoryId = 1, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/1.jpg" },
     new ServiceSubCategory { Id = 2, Title = "سرویس ویژه نظافت", SubCategoryId = 1, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/2.jpg" },
     new ServiceSubCategory { Id = 3, Title = "سرویس لوکس نظافت", SubCategoryId = 1, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/3.jpg" },
     new ServiceSubCategory { Id = 4, Title = "نظافت راه پله", SubCategoryId = 1, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/4.jpg" },
     new ServiceSubCategory { Id = 5, Title = "سرویس نظافت فوری", SubCategoryId = 1, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/5.jpg" },
     new ServiceSubCategory { Id = 6, Title = "پذیرایی", SubCategoryId = 1, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/6.jpg" },
     new ServiceSubCategory { Id = 7, Title = "کارگر ساده", SubCategoryId = 1, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/7.jpg" },
     new ServiceSubCategory { Id = 8, Title = "سمپاشی فضای داخلی", SubCategoryId = 1, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/8.jpg" },

     // ساب کتگوری 2
     new ServiceSubCategory { Id = 9, Title = "شستشو در محل", SubCategoryId = 2, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/9.jpg" },
     new ServiceSubCategory { Id = 10, Title = "قالیشویی", SubCategoryId = 2, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/10.jpg" },
     new ServiceSubCategory { Id = 11, Title = "خشکشویی", SubCategoryId = 2, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/11.png" },
     new ServiceSubCategory { Id = 12, Title = "پرده شویی", SubCategoryId = 2, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/12.jpg" },

     // ساب کتگوری 3
     new ServiceSubCategory { Id = 13, Title = "کارواش سیار", SubCategoryId = 3, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/13.jpg" },
     new ServiceSubCategory { Id = 14, Title = "سرامیک خودرو", SubCategoryId = 3, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/14.jpg" },
     new ServiceSubCategory { Id = 15, Title = "موتورشویی خودرو", SubCategoryId = 3, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/15.jpg" },

     // ساب کتگوری 4
     new ServiceSubCategory { Id = 16, Title = "تعمیر و سرویس پکیج", SubCategoryId = 4, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/16.jpg" },
     new ServiceSubCategory { Id = 17, Title = "تعمیر و سرویس آبگرم کن", SubCategoryId = 4, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/17.jpg" },
     new ServiceSubCategory { Id = 18, Title = "نصب و تعمیر شوفاژ", SubCategoryId = 4, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/18.jpg" },
     new ServiceSubCategory { Id = 19, Title = "تعمیر و نگهداری موتورخانه", SubCategoryId = 4, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/19.jpg" },

     // ساب کتگوری 5
     new ServiceSubCategory { Id = 20, Title = "سنگ کاری", SubCategoryId = 5, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/20.jpg" },
     new ServiceSubCategory { Id = 21, Title = "نقاشی ساختمان", SubCategoryId = 5, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/21.jpeg" },
     new ServiceSubCategory { Id = 22, Title = "نصب کاغذ دیواری", SubCategoryId = 5, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/22.jpg" },
     new ServiceSubCategory { Id = 23, Title = "ساخت و نصب توری", SubCategoryId = 5, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/23.jpg" },
     new ServiceSubCategory { Id = 24, Title = "بنایی", SubCategoryId = 5, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/24.jpg" },
     new ServiceSubCategory { Id = 25, Title = "کلید سازی", SubCategoryId = 5, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/25.jpg" },
     new ServiceSubCategory { Id = 26, Title = "دریل کاری", SubCategoryId = 5, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/26.jpg" },

     // ساب کتگوری 6
     new ServiceSubCategory { Id = 27, Title = "خدمات لوله کشی ساختمان", SubCategoryId = 6, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/27.jpg" },
     new ServiceSubCategory { Id = 28, Title = "پمپ و منبع آب", SubCategoryId = 6, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/28.jpg" },
     new ServiceSubCategory { Id = 29, Title = "لوله کشی گاز", SubCategoryId = 6, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/29.webp" },
     new ServiceSubCategory { Id = 30, Title = "نصب و تعمیر وال هنگ", SubCategoryId = 6, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/30.jpg" },

     // ساب کتگوری 7
     new ServiceSubCategory { Id = 31, Title = "خدمات بازسازی خانه", SubCategoryId = 7, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/31.webp" },
     new ServiceSubCategory { Id = 32, Title = "مشاوره و بازسازی خانه", SubCategoryId = 7, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/32.jpg" },
     new ServiceSubCategory { Id = 33, Title = "دکوراسیون و طراحی ساختمان", SubCategoryId = 7, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/33.jpg" },

     // ساب کتگوری 8
     new ServiceSubCategory { Id = 34, Title = "سیم کشی و کابل کشی", SubCategoryId = 8, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/34.jpg" },
     new ServiceSubCategory { Id = 35, Title = "رفع اتصالی", SubCategoryId = 8, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/35.jpg" },
     new ServiceSubCategory { Id = 36, Title = "نصب لوستر و چراغ", SubCategoryId = 8, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/36.jpg" },
    new ServiceSubCategory { Id = 37, Title = "کلید و پریز", SubCategoryId = 8, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/37.jpg" },
    new ServiceSubCategory { Id = 38, Title = "نصب و تعویز فیوز", SubCategoryId = 8, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/38.png" },
    new ServiceSubCategory { Id = 39, Title = "نصب و تعمیر کرکره برقی", SubCategoryId = 8, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/39.jpg" },

    // ساب کتگوری 9
    new ServiceSubCategory { Id = 40, Title = "نجاری", SubCategoryId = 9, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/40.webp" },
    new ServiceSubCategory { Id = 41, Title = "تعمیرات مبلمان", SubCategoryId = 9, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/41.jpg" },
    new ServiceSubCategory { Id = 42, Title = "خدمات درب چوبی و ضدسرقت", SubCategoryId = 9, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/42.jpg" },

    // ساب کتگوری 10
    new ServiceSubCategory { Id = 43, Title = "پارتیشن شیشه ای", SubCategoryId = 10, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/43.png" },
    new ServiceSubCategory { Id = 44, Title = "شیشه بری و آینه کاری", SubCategoryId = 10, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/44.jpg" },
    new ServiceSubCategory { Id = 45, Title = "هندریل شیشه ای", SubCategoryId = 10, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/45.jpg" },
    new ServiceSubCategory { Id = 46, Title = "شیشه ریلی اسلاید", SubCategoryId = 10, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/46.jpg" },

    // ساب کتگوری 11
    new ServiceSubCategory { Id = 47, Title = "خدمات باغبانی", SubCategoryId = 11, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/47.webp" },
    new ServiceSubCategory { Id = 48, Title = "کاشت و تعویض گلدان", SubCategoryId = 11, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/48.jpg" },
    new ServiceSubCategory { Id = 49, Title = "مشاوره گل و گیاه", SubCategoryId = 11, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/49.webp" },
        // ساب کتگوری 12
    new ServiceSubCategory { Id = 50, Title = "تعمیر جارو برقی", SubCategoryId = 12, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/50.jpg" },
    new ServiceSubCategory { Id = 51, Title = "تعمیر چرخ خیاطی", SubCategoryId = 12, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/51.jpg" },
    new ServiceSubCategory { Id = 52, Title = "تعمیر پنکه", SubCategoryId = 12, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/52.jpg" },

    // ساب کتگوری 13
    new ServiceSubCategory { Id = 53, Title = "تعمیر کامپیوتر و لپ تاب", SubCategoryId = 13, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/53.jpg" },
    new ServiceSubCategory { Id = 54, Title = "تعمیر ماشین های اداری", SubCategoryId = 13, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/54.jpg" },
    new ServiceSubCategory { Id = 55, Title = "مودم و اینترنت", SubCategoryId = 13, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/55.jpg" },

    // ساب کتگوری 14
    new ServiceSubCategory { Id = 56, Title = "خدمات نرم افزاری", SubCategoryId = 14, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/56.jpg" },
    new ServiceSubCategory { Id = 57, Title = "خدمات باتری", SubCategoryId = 14, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/57.jpg" },
    new ServiceSubCategory { Id = 58, Title = "خدمات دوربین", SubCategoryId = 14, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/58.webp" },

    // ساب کتگوری 15
    new ServiceSubCategory { Id = 59, Title = "خدمات اسباب کشی", SubCategoryId = 15, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/59.jpg" },
    new ServiceSubCategory { Id = 60, Title = "سرویس بسته بندی", SubCategoryId = 15, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/60.jpg" },
    new ServiceSubCategory { Id = 61, Title = "کارگر جابه جایی", SubCategoryId = 15, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/61.jpg" },
    new ServiceSubCategory { Id = 62, Title = "اجاره انبار و سوله", SubCategoryId = 15, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/62.webp" },

    // ساب کتگوری 16
    new ServiceSubCategory { Id = 63, Title = "خدمات خودرو", SubCategoryId = 16, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/63.jpg" },
    new ServiceSubCategory { Id = 64, Title = "باتری به باتری", SubCategoryId = 16, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/64.jpg" },
    new ServiceSubCategory { Id = 65, Title = "امداد خودرو", SubCategoryId = 16, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/65.png" },
    new ServiceSubCategory { Id = 66, Title = "حمل خودرو", SubCategoryId = 16, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/66.jpg" },

    // ساب کتگوری 17
    new ServiceSubCategory { Id = 67, Title = "کارواش سیار", SubCategoryId = 17, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/67.jpg" },
    new ServiceSubCategory { Id = 68, Title = "کارواش نانو", SubCategoryId = 17, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/68.jpg" },
    new ServiceSubCategory { Id = 69, Title = "موتورشویی خودرو", SubCategoryId = 17, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/69.jpg" },
    new ServiceSubCategory { Id = 70, Title = "احیای رنگ", SubCategoryId = 17, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/70.jpg" },
        // ساب کتگوری 18
    new ServiceSubCategory { Id = 71, Title = "خدمات ناخن", SubCategoryId = 18, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/71.jpg" },
    new ServiceSubCategory { Id = 72, Title = "رنگ مو بانوان", SubCategoryId = 18, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/72.jpg" },
    new ServiceSubCategory { Id = 73, Title = "براشینگ مو", SubCategoryId = 18, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/73.jpg" },
    new ServiceSubCategory { Id = 74, Title = "کوتاهی مو بانوان", SubCategoryId = 18, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/74.jpg" },

    // ساب کتگوری 19
    new ServiceSubCategory { Id = 75, Title = "مراقبت و نگهداری", SubCategoryId = 19, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/75.jpg" },
    new ServiceSubCategory { Id = 76, Title = "معاینه پزشکی", SubCategoryId = 19, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/76.jpg" },
    new ServiceSubCategory { Id = 77, Title = "پیراپزشکی", SubCategoryId = 19, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/77.webp" },

    // ساب کتگوری 20
    new ServiceSubCategory { Id = 78, Title = "هتل های حیوانات خانگی", SubCategoryId = 20, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/78.jpg" },
    new ServiceSubCategory { Id = 79, Title = "خدمات دامپزشکی در محل", SubCategoryId = 20, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/79.jpg" },
    new ServiceSubCategory { Id = 80, Title = "خدمات شستشو و آراش حیوانات خانگی", SubCategoryId = 20, IsActive = true, CreatAt = DateTime.Now, ImagePath = "/assets/img/services/80.jpg" }



);


    }
}
