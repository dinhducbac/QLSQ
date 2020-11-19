using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    class QLChucVuConfigurations : IEntityTypeConfiguration<QLChucVu>
    {
        public void Configure(EntityTypeBuilder<QLChucVu> builder)
        {
            builder.ToTable("QLChucVu");
            builder.HasKey(x => x.IDQLCV);
            builder.Property(x => x.IDQLCV).ValueGeneratedOnAdd();
            builder.Property(x => x.IDSQ).IsRequired();
            builder.HasOne(x => x.SiQuan).WithMany(x => x.QLChucVus).HasForeignKey(x => x.IDSQ);
            builder.Property(x => x.IDQH).IsRequired();
            builder.HasOne(x => x.QuanHam).WithMany(x => x.QLChucVus).HasForeignKey(x => x.IDQH);
            builder.Property(x => x.IDCV).IsRequired();
            builder.HasOne(x => x.ChucVu).WithMany(x => x.QLChucVus).HasForeignKey(x => x.IDCV);
        }
    }
}
