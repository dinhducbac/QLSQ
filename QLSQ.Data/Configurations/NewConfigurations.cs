using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class NewConfigurations : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.ToTable("New");
            builder.HasKey(x => x.NewID);
            builder.Property(x => x.NewID).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.NewName).IsRequired();
            builder.Property(x => x.NewContent).IsRequired();
            builder.Property(x => x.NewDatePost).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.NewCount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.NewCatetoryID).IsRequired();
            builder.HasOne(x => x.NewCatetory).WithMany(e => e.News).HasForeignKey(x => x.NewCatetoryID);
        }
    }
}
