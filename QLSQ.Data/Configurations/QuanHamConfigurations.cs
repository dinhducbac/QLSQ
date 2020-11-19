using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    class QuanHamConfigurations : IEntityTypeConfiguration<QuanHam>
    {
        public void Configure(EntityTypeBuilder<QuanHam> builder)
        {
            builder.ToTable("QuanHam");
            builder.HasKey(x => x.IDQH);
            builder.Property(x => x.IDQH).ValueGeneratedOnAdd();
            builder.Property(x => x.TenQH).IsRequired(true).IsUnicode(true).HasMaxLength(50);
        }
    }
}
