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
            builder.HasOne(x => x.SiQuan).WithOne(e => e.QLLuongs).HasForeignKey<QLLuong>(x => x.IDSQ).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.IDQLQH).IsRequired();
            builder.HasOne(x => x.QLQuanHam).WithMany(e=>e.QLLuongs).HasForeignKey(x=>x.IDQLQH).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.IDLuongCB).IsRequired();
            builder.HasOne(x => x.LuongCoBan).WithMany(x => x.QLLuongs).HasForeignKey(x => x.IDLuongCB);
            builder.Property(x => x.IDQLCV).IsRequired();
            builder.HasOne(x => x.QLChucVu).WithMany(x => x.QLLuongs).HasForeignKey(x => x.IDQLCV);
        }
    }
}
