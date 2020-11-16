using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QL_SiQuan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QL_SiQuan.Data.Configuarations
{
    class ChucVuConfigurations : IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.ToTable("ChucVu");
            builder.HasKey(x => x.IDCV);
            builder.Property(x => x.IDCV).ValueGeneratedOnAdd();
            builder.Property(x => x.TenCV).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.IDBP).IsRequired();
            builder.HasOne(x => x.BoPhan).WithMany(x => x.ChucVus).HasForeignKey(x => x.IDBP);
        }
    }
}
