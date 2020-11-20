using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    class QLDangVienConfigurations : IEntityTypeConfiguration<QLDangVien>
    {
        public void Configure(EntityTypeBuilder<QLDangVien> builder)
        {
            builder.ToTable("QLDangVien");
            builder.HasKey(x => x.IDQLDV);
            builder.Property(x => x.IDQLDV).ValueGeneratedOnAdd();
            builder.Property(x => x.IDSQ).IsRequired(true);
            builder.HasOne(x => x.SiQuan).WithMany(x => x.QLDangViens).HasForeignKey(x => x.IDSQ);
            builder.Property(x => x.NgayVaoDang).IsRequired(true);
            builder.Property(x => x.NoiVaoDang).IsRequired(true).IsUnicode(true).HasMaxLength(200);
        }
    }
}
