using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class HeSoPhuCapTheoChucVuConfigurations : IEntityTypeConfiguration<HeSoPhuCapTheoChucVu>
    {
        public void Configure(EntityTypeBuilder<HeSoPhuCapTheoChucVu> builder)
        {
            builder.ToTable("HeSoPhuCapTheoChucVu");
            builder.HasKey(x => x.IDHeSoPhuCapCV);
            builder.Property(x => x.IDHeSoPhuCapCV).ValueGeneratedOnAdd();
            builder.Property(x => x.IDCV).IsRequired();
            builder.HasOne(x => x.ChucVu).WithMany(x => x.HeSoPhuCapTheoChucVus).HasForeignKey(x => x.IDCV);
            builder.Property(x => x.HeSoPhuCap).IsRequired();
        }
    }
}
