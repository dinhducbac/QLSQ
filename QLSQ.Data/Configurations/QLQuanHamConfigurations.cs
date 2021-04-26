using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class QLQuanHamConfigurations : IEntityTypeConfiguration<QLQuanHam>
    {
        public void Configure(EntityTypeBuilder<QLQuanHam> builder)
        {
            builder.HasKey(x => x.IDQLQH);
            builder.ToTable("QLQuanHam");
         
            builder.Property(x => x.IDQLQH).ValueGeneratedOnAdd();
            builder.Property(x => x.IDSQ).IsRequired();
            builder.HasOne(x => x.SiQuan).WithMany(e => e.QLQuanHams).HasForeignKey(x => x.IDSQ).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.IDQH).IsRequired();
            builder.HasOne(x => x.QuanHam).WithMany(e => e.QLQuanHams).HasForeignKey(x => x.IDQH).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.IDHeSoLuongTheoQH).IsRequired();
            builder.HasOne(x => x.HeSoLuongTheoQuanHam).WithMany(x => x.QLQuanHams).HasForeignKey(x => x.IDHeSoLuongTheoQH);
        }
    }
}
