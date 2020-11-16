using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QL_SiQuan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QL_SiQuan.Data.Configuarations
{
    class BoPhanConfigurations : IEntityTypeConfiguration<BoPhan>
    {
        public void Configure(EntityTypeBuilder<BoPhan> builder)
        {
            builder.ToTable("BoPhan");
            builder.HasKey(x => x.IDBP);
            builder.Property(x => x.IDBP).ValueGeneratedOnAdd();
            builder.Property(x => x.TenBP).IsRequired(true).IsUnicode(true).HasMaxLength(20);
        }
    }
}
