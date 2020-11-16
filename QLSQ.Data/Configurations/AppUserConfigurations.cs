using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Configurations
{
    public class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser");
        }
    }
}
