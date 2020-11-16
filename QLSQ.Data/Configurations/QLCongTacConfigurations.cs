using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QL_SiQuan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QL_SiQuan.Data.Configuarations
{
    class QLCongTacConfigurations : IEntityTypeConfiguration<QLCongTac>
    {
        public void Configure(EntityTypeBuilder<QLCongTac> builder)
        {
            builder.ToTable("QLCongTac");
            builder.HasKey(x=>x.IDCT);
            builder.Property(x => x.IDCT).ValueGeneratedOnAdd();
            builder.Property(x => x.IDSQ).IsRequired(true);
            builder.HasOne(x => x.SiQuan).WithMany(x => x.QLCongTacs).HasForeignKey(x => x.IDSQ);
            builder.Property(x => x.DiaChiCT).IsRequired(true).IsUnicode(true).HasMaxLength(300);
            builder.Property(x => x.ThoiGianBatDauCT).IsRequired(true);
            builder.Property(x => x.ThoiGianCT).IsRequired(true);

        }
    }
}
