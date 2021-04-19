using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class QLGiaDinhSQConfigurations : IEntityTypeConfiguration<QLGiaDinhSQ>
    {
        public void Configure(EntityTypeBuilder<QLGiaDinhSQ> builder)
        {
            builder.ToTable("QLGiaDinhSQ");
            builder.HasKey(x=>x.IDQLGDSQ);
            builder.Property(x => x.IDQLGDSQ).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IDSQ).IsRequired();
            builder.HasOne(x => x.SiQuan).WithMany(x => x.QLGiaDinhSQs).HasForeignKey(x => x.IDSQ);
            builder.Property(x => x.QuanHe).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.HoTen).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.NgaySinh).IsRequired();
            builder.Property(x => x.GhiChu).IsRequired().HasMaxLength(1000);
        }
    }
}
