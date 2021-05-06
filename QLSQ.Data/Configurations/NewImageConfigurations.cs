using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class NewImageConfigurations : IEntityTypeConfiguration<NewImage>
    {
        public void Configure(EntityTypeBuilder<NewImage> builder)
        {
            builder.ToTable("NewImage");
            builder.HasKey(x => x.NewImageID);
            builder.Property(x => x.NewImageID).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.NewID).IsRequired();
            builder.HasOne(x => x.New).WithMany(e => e.NewImages).HasForeignKey(x => x.NewID);
            builder.Property(x => x.ImagePath).IsRequired();
            builder.Property(x => x.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.FileSize).IsRequired();
        }
    }
}
