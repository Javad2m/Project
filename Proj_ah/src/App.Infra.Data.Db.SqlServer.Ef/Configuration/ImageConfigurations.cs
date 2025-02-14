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

public class ImageConfigurations : IEntityTypeConfiguration<Image>
{

    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Path)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasOne(i => i.Request)
               .WithMany(r => r.Images)
               .HasForeignKey(i => i.RequestId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
