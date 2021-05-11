using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class NewCatetoryConfigurations : IEntityTypeConfiguration<NewCatetory>
    {
        public void Configure(EntityTypeBuilder<NewCatetory> builder)
        {
            builder.ToTable("NewCatetory");
            builder.HasKey(x => x.NewCatetoryID);
            builder.Property(x => x.NewCatetoryID).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.NewCatetoryName).IsRequired();
        }
    }
}
