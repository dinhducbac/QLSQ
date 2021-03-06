﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;
using System.Globalization;
using QLSQ.Data.Entities;

namespace QLSQ.Data.Configurations
{
    internal class SiQuanConfigurations : IEntityTypeConfiguration<SiQuan>
    {
        public void Configure(EntityTypeBuilder<SiQuan> builder)
        {
            builder.ToTable("SiQuan");
            builder.HasKey(x => x.IDSQ);
            builder.Property(x => x.IDSQ).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired(true).IsUnicode(false);
            builder.HasOne(x => x.AppUser).WithOne(a => a.SiQuan).HasForeignKey<SiQuan>(a => a.UserId);
            builder.Property(x => x.HoTen).IsRequired(true).IsUnicode(true).HasMaxLength(50);
            builder.Property(x => x.NgaySinh).IsRequired(true);
            builder.Property(x => x.GioiTinh).IsRequired(true).HasMaxLength(1).HasDefaultValue("M").IsUnicode(false);
            builder.Property(x => x.QueQuan).IsRequired(true).IsUnicode(true).HasMaxLength(300);
            builder.Property(x => x.SDT).IsRequired(true).HasMaxLength(11).IsUnicode(false);
        }
    }
}
