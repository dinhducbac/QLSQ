using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slide");
            builder.HasKey(x => x.SlideID);
            builder.Property(x => x.SlideID).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.SlideUrl).IsRequired();
            builder.Property(x => x.SlideName).IsRequired();
            builder.Property(x => x.SlideContent).IsRequired();
            builder.Property(x => x.SlideImage).IsRequired();
            builder.Property(x => x.SlideTimePost).IsRequired();
        }
    }
}
