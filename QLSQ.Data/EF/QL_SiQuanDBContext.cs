
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QL_SiQuan.Data.Extensions;
using QLSQ.Data.Configurations;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.EF
{
    public class QL_SiQuanDBContext : IdentityDbContext<AppUser, AppRole, Guid>
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
            modelBuilder.ApplyConfiguration(new AppUserConfigurations());
            modelBuilder.ApplyConfiguration(new AppRoleConfigurations());
            modelBuilder.ApplyConfiguration(new SiQuanImageConfigurations());
            modelBuilder.ApplyConfiguration(new HeSoLuongTheoQuanHamConfiguarations());
            modelBuilder.ApplyConfiguration(new HeSoPhuCapTheoChucVuConfigurations());
            modelBuilder.ApplyConfiguration(new LuongCoBanConfigrations());
            modelBuilder.ApplyConfiguration(new QLKhenThuongKiLuatConfigurations());
            modelBuilder.ApplyConfiguration(new QlQuaTrinhDaoTaoConfigurations());
            modelBuilder.ApplyConfiguration(new QLGiaDinhSQConfigurations());
            modelBuilder.ApplyConfiguration(new QLQuanHamConfigurations());
            modelBuilder.ApplyConfiguration(new NewConfigurations());
            modelBuilder.ApplyConfiguration(new NewImageConfigurations());
            modelBuilder.ApplyConfiguration(new SlideConfiguration());
            modelBuilder.ApplyConfiguration(new NewCatetoryConfigurations());
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken").HasKey(x => x.UserId);
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
        public QL_SiQuanDBContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<QLLuong> QLLuongs { get; set; }
        public DbSet<QLDangVien> QLDangViens { get; set; }
        public DbSet<QLNghiPhep> QLNghiPheps { get; set; }
        public DbSet<QLCongTac> QLCongTacs { get; set; }
        public DbSet<QuanHam> QuanHams { get; set; }
        public DbSet<BoPhan> BoPhans { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<QLChucVu> QLChucVus { get; set; }
        public DbSet<SiQuanImage> SiQuanImages { get; set; }
        public DbSet<HeSoLuongTheoQuanHam> HeSoLuongTheoQuanHams { get; set; }
        public DbSet<HeSoPhuCapTheoChucVu> HeSoPhuCapTheoChucVus { get; set; }
        public DbSet<LuongCoBan> LuongCoBans { get; set; }
        public DbSet<SiQuan> SiQuans { get; set; }
        public DbSet<QLKhenThuongKiLuat> QLKhenThuongKiLuats { get; set; }
        public DbSet<QLQuaTrinhDaoTao> QLQuaTrinhDaoTaos { get; set; }
        public DbSet<QLGiaDinhSQ> QLGiaDinhSQs { get; set; }
        public DbSet<QLQuanHam> QLQuanHams { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<NewImage> NewImages { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<NewCatetory> NewCatetories { get; set; }
        //public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<AppRole> AppRoles { get; set; }
    }
}
