using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QL_SiQuan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QL_SiQuan.Data.Configuarations
{
    class QLLuongConfigurations : IEntityTypeConfiguration<QLLuong>
    {
        public void Configure(EntityTypeBuilder<QLLuong> builder)
        {
            builder.ToTable("QLLuong");
            builder.HasKey(x => x.IDLuong);
            builder.Property(x => x.IDLuong).ValueGeneratedOnAdd();
            builder.Property(x => x.IDSQ).IsRequired();
            builder.HasOne(x => x.SiQuan).WithMany(x => x.QLLuongs).HasForeignKey(x => x.IDSQ);
            builder.Property(x => x.HeSoLuong).IsRequired();
            builder.Property(x => x.LuongCoBan).IsRequired();
            builder.Property(x => x.HeSoPhuCap).IsRequired().HasDefaultValue<float>(0);
        }
    }
}
