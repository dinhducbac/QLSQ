using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    class HeSoLuongTheoQuanHamConfiguarations : IEntityTypeConfiguration<HeSoLuongTheoQuanHam>
    {
        public void Configure(EntityTypeBuilder<HeSoLuongTheoQuanHam> builder)
        {
            builder.ToTable("HeSoLuongTheoQuanHam");
            builder.HasKey(x => x.IDHeSoLuongQH);
            builder.Property(x => x.IDHeSoLuongQH).ValueGeneratedOnAdd();
            builder.Property(x => x.IDQH).IsRequired();      
            builder.HasOne(x => x.QuanHam).WithMany(x => x.HeSoLuongTheoQuanHams).HasForeignKey(x => x.IDQH);
            builder.Property(x => x.TenHeSoLuongQH).IsRequired();
            builder.Property(x=>x.HeSoLuong).IsRequired();
        }
    }
}
