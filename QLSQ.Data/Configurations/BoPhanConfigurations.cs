using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
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
