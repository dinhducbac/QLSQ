using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class LuongCoBanConfigrations : IEntityTypeConfiguration<LuongCoBan>
    {
        public void Configure(EntityTypeBuilder<LuongCoBan> builder)
        {
            builder.ToTable("LuongCoBan");
            builder.HasKey(x => x.IDLuongCB);
            builder.Property(x => x.IDLuongCB).ValueGeneratedOnAdd();
            builder.Property(x => x.LuongCB).IsRequired();
        }
    }
}
