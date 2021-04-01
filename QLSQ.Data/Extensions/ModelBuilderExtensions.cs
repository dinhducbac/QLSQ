using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLSQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QL_SiQuan.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var RoleAdminId = new Guid("37FE170E-027E-4E7F-ABA5-15743063AEB2");
            var RoleSQId = new Guid("42FF6F47-9EDD-451F-BF03-DB895DFCFFF9");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = RoleAdminId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Mota = "Administrator Role"
                },
                 new AppRole
                 {
                     Id = RoleSQId,
                     Name = "Si Quan",
                     NormalizedName = "Si Quan",
                     Mota = "Si Quan Role"
                 }
            );

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = new Guid("EF234B11-CCC7-45D3-BA16-5EBF721EE6C8"),
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "dinhducbac1998@gmail.com",
                    NormalizedEmail = "dinhducbac1998@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "02011998ducbac"),
                    SecurityStamp = string.Empty
                },
                new AppUser
                {
                    Id = new Guid("9ECE85C8-A453-4FFC-B5AB-BF7D4C3365F9"),
                    UserName = "lethihien",
                    NormalizedUserName = "lethihien",
                    Email = "lethihien@gmail.com",
                    NormalizedEmail = "lethihien@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "hien123"),
                    SecurityStamp = string.Empty
                },
                new AppUser
                {
                    Id = new Guid("78B61FF5-714B-4C2E-9566-6DF4396B1208"),
                    UserName = "dovantuan",
                    NormalizedUserName = "dovantuan",
                    Email = "dovantuan@gmail.com",
                    NormalizedEmail = "dovantuan@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "tuan123"),
                    SecurityStamp = string.Empty
                },
                new AppUser
                {
                    Id = new Guid("4C39EE3B-0277-4B32-8173-261988CCE2EE"),
                    UserName = "lethigiang",
                    NormalizedUserName = "lethigiang",
                    Email = "lethigiang@gmail.com",
                    NormalizedEmail = "lethigiang@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "giang123"),
                    SecurityStamp = string.Empty
                },
                new AppUser
                {
                    Id = new Guid("2C31D31E-1520-48EE-9E62-2311829CF7BA"),
                    UserName = "nguyenvanhoan",
                    NormalizedUserName = "nguyenvanhoan",
                    Email = "nguyenvanhoan@gmail.com",
                    NormalizedEmail = "nguyenvanhoan@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "hoan123"),
                    SecurityStamp = string.Empty
                },
                new AppUser
                {
                    Id = new Guid("41A8E023-7C08-46BB-858C-5A3B219818CB"),
                    UserName = "vuvancanh",
                    NormalizedUserName = "vuvancanh",
                    Email = "vuvancanh@gmail.com",
                    NormalizedEmail = "vuvancanh@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "canh123"),
                    SecurityStamp = string.Empty
                }
            );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = RoleAdminId,
                    UserId = new Guid("EF234B11-CCC7-45D3-BA16-5EBF721EE6C8")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = RoleSQId,
                    UserId = new Guid("9ECE85C8-A453-4FFC-B5AB-BF7D4C3365F9")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = RoleSQId,
                    UserId = new Guid("78B61FF5-714B-4C2E-9566-6DF4396B1208")
                },
                 new IdentityUserRole<Guid>
                 {
                     RoleId = RoleSQId,
                     UserId = new Guid("4C39EE3B-0277-4B32-8173-261988CCE2EE")
                 },
                 new IdentityUserRole<Guid>
                 {
                     RoleId = RoleSQId,
                     UserId = new Guid("2C31D31E-1520-48EE-9E62-2311829CF7BA")
                 },
                 new IdentityUserRole<Guid>
                 {
                     RoleId = RoleSQId,
                     UserId = new Guid("41A8E023-7C08-46BB-858C-5A3B219818CB")
                 }
            );
            modelBuilder.Entity<SiQuan>().HasData(
                new SiQuan {
                    IDSQ = 1,
                    UserId = new Guid("9ECE85C8-A453-4FFC-B5AB-BF7D4C3365F9"),
                    HoTen = "Lê Thị Hiền",
                    NgaySinh = DateTime.Parse("1985-01-02")
                ,
                    GioiTinh = "F",
                    QueQuan = "Nghệ An",
                    SDT = "0377526687" },
                new SiQuan
                {
                    IDSQ = 2,
                    UserId = new Guid("78B61FF5-714B-4C2E-9566-6DF4396B1208"),
                    HoTen = "Đỗ Văn Tuấn",
                    NgaySinh = DateTime.Parse("1985-05-09")
                ,
                    GioiTinh = "M",
                    QueQuan = "Nghệ An",
                    SDT = "0374561237"
                },
                new SiQuan
                {
                    IDSQ = 3,
                    UserId = new Guid("4C39EE3B-0277-4B32-8173-261988CCE2EE"),
                    HoTen = "Lê Thị Giang",
                    NgaySinh = DateTime.Parse("1985-09-04")
                ,
                    GioiTinh = "F",
                    QueQuan = "Nghệ An",
                    SDT = "0373568745"
                },
                new SiQuan
                {
                    IDSQ = 4,
                    UserId = new Guid("2C31D31E-1520-48EE-9E62-2311829CF7BA"),
                    HoTen = "Nguyễn Văn Hoàn",
                    NgaySinh = DateTime.Parse("1987-11-28")
                ,
                    GioiTinh = "M",
                    QueQuan = "Nghệ An",
                    SDT = "0374231456"
                },
                new SiQuan
                {
                    IDSQ = 5,
                    UserId = new Guid("41A8E023-7C08-46BB-858C-5A3B219818CB"),
                    HoTen = "Vũ Văn Cảnh",
                    NgaySinh = DateTime.Parse("1984-12-10")
                ,
                    GioiTinh = "M",
                    QueQuan = "Nghệ An",
                    SDT = "0374123456"
                }
            );
            modelBuilder.Entity<QuanHam>().HasData(
                new QuanHam { IDQH = 1, TenQH = "Thiếu Úy" },
                new QuanHam { IDQH = 2, TenQH = "Trung Úy" },
                new QuanHam { IDQH = 3, TenQH = "Thượng Úy" },
                new QuanHam { IDQH = 4, TenQH = "Đại Úy" },
                new QuanHam { IDQH = 5, TenQH = "Thiếu Tá" },
                new QuanHam { IDQH = 6, TenQH = "Trung Tá" },
                new QuanHam { IDQH = 7, TenQH = "Thượng Tá" },
                new QuanHam { IDQH = 8, TenQH = "Đại tá" },
                new QuanHam { IDQH = 9, TenQH = "Thiếu Tướng" },
                new QuanHam { IDQH = 10, TenQH = "Trung Tướng" },
                new QuanHam { IDQH = 11, TenQH = "Thượng Tướng" },
                new QuanHam { IDQH = 12, TenQH = "Đại Tướng" }
            );
            modelBuilder.Entity<QLDangVien>().HasData(
                new QLDangVien {
                    IDQLDV = 1,
                    IDSQ = 1,
                    NgayVaoDang = DateTime.Parse("2007-08-13"),
                    NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                },
                new QLDangVien
                {
                    IDQLDV = 2,
                    IDSQ = 2,
                    NgayVaoDang = DateTime.Parse("2007-08-13"),
                    NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                },
                new QLDangVien
                {
                    IDQLDV = 3,
                    IDSQ = 3,
                    NgayVaoDang = DateTime.Parse("2007-08-13"),
                    NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                },
                new QLDangVien
                {
                    IDQLDV = 4,
                    IDSQ = 4,
                    NgayVaoDang = DateTime.Parse("2007-08-13"),
                    NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                },
                new QLDangVien
                {
                    IDQLDV = 5,
                    IDSQ = 5,
                    NgayVaoDang = DateTime.Parse("2005-09-25"),
                    NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                }
            );
            modelBuilder.Entity<BoPhan>().HasData(
                new BoPhan { IDBP = 1, TenBP= "Ban giám hiệu"},
                new BoPhan { IDBP = 2, TenBP = "Phòng" },
                new BoPhan { IDBP = 3, TenBP = "Trợ lý"},
                new BoPhan { IDBP = 4, TenBP = "Khoa" },
                new BoPhan { IDBP = 5, TenBP = "Đơn vị"}
            );
            modelBuilder.Entity<ChucVu>().HasData(
                new ChucVu { IDCV = 1, TenCV = "Hiệu trưởng", IDBP= 1 },
                new ChucVu { IDCV = 2, TenCV = "Hiệu phó đào tạo", IDBP = 1 },
                new ChucVu { IDCV = 3, TenCV = "Phó quân sự", IDBP = 1 },
                new ChucVu { IDCV = 4, TenCV = "Phó kỹ thuật", IDBP = 1 },
                new ChucVu { IDCV = 5, TenCV = "Trưởng phòng", IDBP = 2 },
                new ChucVu { IDCV = 6, TenCV = "Phó phòng", IDBP = 2 },
                new ChucVu { IDCV = 7, TenCV = "Trưởng ban", IDBP = 2 },
                new ChucVu { IDCV = 8, TenCV = "Phó ban", IDBP = 2 },
                new ChucVu { IDCV = 9, TenCV = "Chủ nhiệm hậu cần", IDBP = 3 },
                new ChucVu { IDCV = 10, TenCV = "Chủ nhiệm kỹ thuật", IDBP = 3 },
                new ChucVu { IDCV = 11, TenCV = "Chủ nhiệm chính trị", IDBP = 3 },
                new ChucVu { IDCV = 12, TenCV = "Chủ nhiệm khoa", IDBP = 4 },
                new ChucVu { IDCV = 13, TenCV = "Phó chủ nhiệm khoa", IDBP = 4 },
                new ChucVu { IDCV = 14, TenCV = "Chủ nhiệm bộ môn", IDBP = 4 },
                new ChucVu { IDCV = 15, TenCV = "Giáo viên", IDBP = 4 },
                new ChucVu { IDCV = 16, TenCV = "Nhân viên", IDBP = 4 },
                new ChucVu { IDCV = 17, TenCV = "Tiểu đoàn trưởng", IDBP = 5 },
                new ChucVu { IDCV = 18, TenCV = "Phó tiểu đoàn trưởng", IDBP = 5 },
                new ChucVu { IDCV = 19, TenCV = "Đại đội trưởng", IDBP = 5 },
                new ChucVu { IDCV = 20, TenCV = "Phó đại đội trưởng", IDBP = 5 },
                new ChucVu { IDCV = 21, TenCV = "Trung đội trưởng", IDBP = 5 }
                );
            modelBuilder.Entity<QLChucVu>().HasData(
                new QLChucVu { IDQLCV = 1, IDSQ = 1, IDQH = 8, IDCV = 15},
                new QLChucVu { IDQLCV = 2, IDSQ = 2, IDQH = 8, IDCV = 15 },
                new QLChucVu { IDQLCV = 3, IDSQ = 3, IDQH = 5, IDCV = 15 },
                new QLChucVu { IDQLCV = 4, IDSQ = 4, IDQH = 6, IDCV = 15 },
                new QLChucVu { IDQLCV = 5, IDSQ = 5, IDQH = 8, IDCV = 15 }
            );
            modelBuilder.Entity<QLLuong>().HasData(
                new QLLuong { IDLuong = 1, IDSQ = 1, HeSoLuong = 8.0F, LuongCoBan = 1429000, HeSoPhuCap = 0F },
                new QLLuong { IDLuong = 2, IDSQ = 2, HeSoLuong = 8.0F, LuongCoBan = 1429000, HeSoPhuCap = 0F },
                new QLLuong { IDLuong = 3, IDSQ = 3, HeSoLuong = 6.0F, LuongCoBan = 1429000, HeSoPhuCap = 0F },
                new QLLuong { IDLuong = 4, IDSQ = 4, HeSoLuong = 6.6F, LuongCoBan = 1429000, HeSoPhuCap = 0F },
                new QLLuong { IDLuong = 5, IDSQ = 5, HeSoLuong = 8.0F, LuongCoBan = 1429000, HeSoPhuCap = 0F }
            );
            modelBuilder.Entity<QLCongTac>().HasData(
                new QLCongTac { 
                    IDCT = 1,
                    IDSQ = 1, 
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 
                    ThoiGianBatDauCT = DateTime.Parse("2007-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13")
                },
                new QLCongTac {
                    IDCT = 2,
                    IDSQ = 2, 
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 
                    ThoiGianBatDauCT = DateTime.Parse("2007-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13")
                },
                new QLCongTac {
                    IDCT = 3,
                    IDSQ = 3, 
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 
                    ThoiGianBatDauCT = DateTime.Parse("2007-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13")
                },
                new QLCongTac
                {
                    IDCT = 4,
                    IDSQ = 4,
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa",
                    ThoiGianBatDauCT = DateTime.Parse("2007-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13")
                },
                new QLCongTac
                {
                    IDCT = 5,
                    IDSQ = 5,
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa",
                    ThoiGianBatDauCT = DateTime.Parse("2005-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13")
                }
            );
        }
    }
}
