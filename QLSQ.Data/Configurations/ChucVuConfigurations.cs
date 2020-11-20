using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
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
