using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    class QLNghiPhepConfigurations : IEntityTypeConfiguration<QLNghiPhep>
    {
        public void Configure(EntityTypeBuilder<QLNghiPhep> builder)
        {
            builder.ToTable("QLNghiPhep");
            builder.HasKey(x => x.IDNP);
            builder.Property(x => x.IDNP).ValueGeneratedOnAdd();
            builder.Property(x => x.IDSQ).IsRequired();
            builder.HasOne(x => x.SiQuan).WithMany(x => x.QLNghiPheps).HasForeignKey(x => x.IDSQ);
            builder.Property(x => x.ThoiGianBDNP).IsRequired();
            builder.Property(x => x.ThoiGianKTNP).IsRequired();
            builder.Property(x => x.NghiPhepState).IsRequired().HasDefaultValue(0);
        }
    }
}
