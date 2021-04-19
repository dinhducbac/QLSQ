using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class QLKhenThuongKiLuatConfigurations : IEntityTypeConfiguration<QLKhenThuongKiLuat>
    {
        public void Configure(EntityTypeBuilder<QLKhenThuongKiLuat> builder)
        {
            builder.ToTable("QLKhenThuongKiLuat");
            builder.HasKey(x=> x.IDQLKTKL);
            builder.Property(x => x.IDQLKTKL).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x=>x.IDSQ).IsRequired();
            builder.HasOne(x => x.SiQuan).WithMany(x => x.QLKhenThuongKiLuats).HasForeignKey(x => x.IDSQ);
            builder.Property(x => x.NgayThucHien).IsRequired();
            builder.Property(x => x.LoaiKTKL).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.HinhThuc).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.DonViCap).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.NoiDung).IsRequired().HasMaxLength(1000);
        }
    }
}
