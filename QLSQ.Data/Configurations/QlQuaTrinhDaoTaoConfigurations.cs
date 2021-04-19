using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class QlQuaTrinhDaoTaoConfigurations : IEntityTypeConfiguration<QLQuaTrinhDaoTao>
    {
        public void Configure(EntityTypeBuilder<QLQuaTrinhDaoTao> builder)
        {
            builder.ToTable("QLQuaTrinhDaoTao");
            builder.HasKey(x => x.IDQLQTDT);
            builder.Property(x => x.IDQLQTDT).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IDSQ).IsRequired();
            builder.HasOne(x => x.SiQuan).WithMany(x => x.QLQuaTrinhDaoTaos).HasForeignKey(x => x.IDSQ);
            builder.Property(x => x.TenTruong).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.NganhHoc).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.ThoiGianBDDT).IsRequired();
            builder.Property(x => x.ThoiGianKTDT).IsRequired();
            builder.Property(x => x.HinhThucDT).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.VanBang).IsRequired().HasMaxLength(1000);
        }
    }
}
