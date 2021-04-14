using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    class QLCongTacConfigurations : IEntityTypeConfiguration<QLCongTac>
    {
        public void Configure(EntityTypeBuilder<QLCongTac> builder)
        {
            builder.ToTable("QLCongTac");
            builder.HasKey(x => x.IDCT);
            builder.Property(x => x.IDCT).ValueGeneratedOnAdd();
            builder.Property(x => x.IDSQ).IsRequired(true);
            builder.HasOne(x => x.SiQuan).WithMany(x => x.QLCongTacs).HasForeignKey(x => x.IDSQ);
            builder.Property(x => x.DiaChiCT).IsRequired(true).IsUnicode(true).HasMaxLength(300);
            builder.Property(x => x.ThoiGianBatDauCT).IsRequired(true);
            builder.Property(x => x.ThoiGianKetThucCT).IsRequired(true);
            builder.Property(x => x.CongTacState).IsRequired().HasDefaultValue(1);
        }
    }
}
