using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class SiQuanImageConfigurations : IEntityTypeConfiguration<SiQuanImage>
    {
        public void Configure(EntityTypeBuilder<SiQuanImage> builder)
        {
            builder.ToTable("SiQuanImage");
            builder.HasKey(x => x.IDImage);
            builder.Property(x => x.IDImage).UseIdentityColumn();
            builder.Property(x => x.IDSQ).IsRequired();
            builder.HasOne(x => x.SiQuan).WithMany(x => x.SiQuanImages).HasForeignKey(a => a.IDSQ);
            builder.Property(x => x.ImagePath).IsRequired().IsUnicode(false).HasMaxLength(300);
            builder.Property(x => x.Caption).IsUnicode().HasMaxLength(300);
            builder.Property(x => x.IsDefault).IsRequired();
        }
    }
}
