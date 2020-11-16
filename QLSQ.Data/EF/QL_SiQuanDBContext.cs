
using Microsoft.EntityFrameworkCore;
using QL_SiQuan.Data.Configuarations;
using QL_SiQuan.Data.Entities;
using QL_SiQuan.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace QL_SiQuan.Data.EF
{
    public class QL_SiQuanDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure using fluent API
            modelBuilder.ApplyConfiguration(new SiQuanConfigurations());
            modelBuilder.ApplyConfiguration(new BoPhanConfigurations());
            modelBuilder.ApplyConfiguration(new QuanHamConfigurations());
            modelBuilder.ApplyConfiguration(new ChucVuConfigurations());
            modelBuilder.ApplyConfiguration(new QLChucVuConfigurations());
            modelBuilder.ApplyConfiguration(new QLCongTacConfigurations());
            modelBuilder.ApplyConfiguration(new QLDangVienConfigurations());
            modelBuilder.ApplyConfiguration(new QLLuongConfigurations());
            modelBuilder.ApplyConfiguration(new QLNghiPhepConfigurations());
            //modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
            //modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole").HasKey(x=> new {x.UserId,x.RoleId });
            //modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin").HasKey(x=>x.UserId);
            //modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
            //modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken").HasKey(x=>x.UserId);
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
        public QL_SiQuanDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SiQuan> SiQuans { get; set; }
        public DbSet<QLLuong> QLLuongs { get; set; }
        public DbSet<QLDangVien> QLDangViens { get; set; }
        public DbSet<QLNghiPhep> QLNghiPheps { get; set; }
        public DbSet<QLCongTac> QLCongTacs { get; set; }
        public DbSet<QuanHam> QuanHams { get; set; }
        public DbSet<BoPhan> BoPhans { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<QLChucVu> QLChucVus {get;set;}
        
    }
}
