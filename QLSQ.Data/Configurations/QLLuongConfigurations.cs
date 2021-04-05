using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    class QLLuongConfigurations : IEntityTypeConfiguration<QLLuong>
    {
        public void Configure(EntityTypeBuilder<QLLuong> builder)
        {
            builder.ToTable("QLLuong");
            builder.HasKey(x => x.IDLuong);
            builder.Property(x => x.IDLuong).ValueGeneratedOnAdd();
            builder.Property(x => x.IDSQ).IsRequired();
            builder.HasOne(x => x.SiQuan).WithOne(x => x.QLLuongs).HasForeignKey<QLLuong>(a => a.IDSQ);
            builder.Property(x => x.IDHeSoLuongQH).IsRequired();
            builder.HasOne(x => x.HeSoLuongTheoQuanHam).WithMany(x=>x.QLLuongs).HasForeignKey(x=>x.IDHeSoLuongQH);
            builder.Property(x => x.IDLuongCB).IsRequired();
            builder.HasOne(x => x.LuongCoBan).WithMany(x => x.QLLuongs).HasForeignKey(x => x.IDLuongCB);
            builder.Property(x => x.IDHeSoPhuCapCV).IsRequired();
            builder.HasOne(x => x.HeSoPhuCapTheoChucVu).WithMany(x => x.QLLuongs).HasForeignKey(x => x.IDHeSoPhuCapCV);
        }
    }
}
