﻿using Microsoft.AspNetCore.Identity;
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
                new BoPhan { IDBP = 1, TenBP = "Ban giám hiệu" },
                new BoPhan { IDBP = 2, TenBP = "Phòng" },
                new BoPhan { IDBP = 3, TenBP = "Trợ lý" },
                new BoPhan { IDBP = 4, TenBP = "Khoa" },
                new BoPhan { IDBP = 5, TenBP = "Đơn vị" }
            );
            modelBuilder.Entity<ChucVu>().HasData(
                new ChucVu { IDCV = 1, TenCV = "Hiệu trưởng", IDBP = 1 },
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
                new QLChucVu { IDQLCV = 1, IDSQ = 1, IDCV = 15, NgayNhan = DateTime.Parse("2008-03-21") },
                new QLChucVu { IDQLCV = 2, IDSQ = 2, IDCV = 15, NgayNhan = DateTime.Parse("2008-03-21") },
                new QLChucVu { IDQLCV = 3, IDSQ = 3, IDCV = 15, NgayNhan = DateTime.Parse("2008-03-21") },
                new QLChucVu { IDQLCV = 4, IDSQ = 4, IDCV = 15, NgayNhan = DateTime.Parse("2008-03-21") },
                new QLChucVu { IDQLCV = 5, IDSQ = 5, IDCV = 15, NgayNhan = DateTime.Parse("2006-03-21"), }
            );
            modelBuilder.Entity<HeSoLuongTheoQuanHam>().HasData(
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 1, IDQH = 1, TenHeSoLuongQH="Thiếu Úy", HeSoLuong = 4.2f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 2, IDQH = 2, TenHeSoLuongQH = "Trung Úy", HeSoLuong = 4.6f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 3, IDQH = 3, TenHeSoLuongQH = "Thượng Úy", HeSoLuong = 5.0f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 4, IDQH = 4, TenHeSoLuongQH = "Đại Úy", HeSoLuong = 5.4f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 5, IDQH = 5, TenHeSoLuongQH = "Thiếu Tá", HeSoLuong = 6.0f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 6, IDQH = 6, TenHeSoLuongQH = "Trung Tá", HeSoLuong = 6.6f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 7, IDQH = 7, TenHeSoLuongQH = "Thượng Tá", HeSoLuong = 7.3f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 8, IDQH = 8, TenHeSoLuongQH = "Đại Tá", HeSoLuong = 8.0f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 9, IDQH = 9, TenHeSoLuongQH = "Thiếu Tướng", HeSoLuong = 8.6f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 10, IDQH = 10, TenHeSoLuongQH = "Trung Tướng", HeSoLuong = 9.2f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 11, IDQH = 11, TenHeSoLuongQH = "Thượng Tướng", HeSoLuong = 9.8f },
                new HeSoLuongTheoQuanHam { IDHeSoLuongQH = 12, IDQH = 12, TenHeSoLuongQH = "Đại Tướng", HeSoLuong = 10.4f }
            );
            modelBuilder.Entity<HeSoPhuCapTheoChucVu>().HasData(
                new HeSoPhuCapTheoChucVu{ IDHeSoPhuCapCV = 1, IDCV = 15, HeSoPhuCap = 0.25f}
                );
            modelBuilder.Entity<LuongCoBan>().HasData(
                new LuongCoBan { IDLuongCB=1,LuongCB = 1429000 }
                );
            modelBuilder.Entity<QLQuanHam>().HasData(
                new QLQuanHam { IDQLQH = 1, IDSQ = 1, IDQH = 6, IDHeSoLuongTheoQH = 6 },
                new QLQuanHam { IDQLQH = 2, IDSQ = 2, IDQH = 6, IDHeSoLuongTheoQH = 6 },
                new QLQuanHam { IDQLQH = 3, IDSQ = 3, IDQH = 6, IDHeSoLuongTheoQH = 6 },
                new QLQuanHam { IDQLQH = 4, IDSQ = 4, IDQH = 6, IDHeSoLuongTheoQH = 6 },
                new QLQuanHam { IDQLQH = 5, IDSQ = 5, IDQH = 6, IDHeSoLuongTheoQH = 6 }
            );
            modelBuilder.Entity<QLLuong>().HasData(
                new QLLuong { IDLuong = 1, IDSQ = 1, IDQLQH = 1, IDLuongCB = 1, IDQLCV = 1 },
                new QLLuong { IDLuong = 2, IDSQ = 2, IDQLQH = 2, IDLuongCB = 1, IDQLCV = 2 },
                new QLLuong { IDLuong = 3, IDSQ = 3, IDQLQH = 3, IDLuongCB = 1, IDQLCV = 3 },
                new QLLuong { IDLuong = 4, IDSQ = 4, IDQLQH = 4, IDLuongCB = 1, IDQLCV = 4 },
                new QLLuong { IDLuong = 5, IDSQ = 5, IDQLQH = 5, IDLuongCB = 1, IDQLCV = 5 }
            );
            modelBuilder.Entity<QLCongTac>().HasData(
                new QLCongTac { 
                    IDCT = 1,
                    IDSQ = 1, 
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 
                    ThoiGianBatDauCT = DateTime.Parse("2007-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13"),
                    CongTacState = 1
                },
                new QLCongTac {
                    IDCT = 2,
                    IDSQ = 2, 
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 
                    ThoiGianBatDauCT = DateTime.Parse("2007-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13"),
                    CongTacState = 1
                },
                new QLCongTac {
                    IDCT = 3,
                    IDSQ = 3, 
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 
                    ThoiGianBatDauCT = DateTime.Parse("2007-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13"),
                    CongTacState = 1
                },
                new QLCongTac
                {
                    IDCT = 4,
                    IDSQ = 4,
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa",
                    ThoiGianBatDauCT = DateTime.Parse("2007-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13"),
                    CongTacState = 1
                },
                new QLCongTac
                {
                    IDCT = 5,
                    IDSQ = 5,
                    DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa",
                    ThoiGianBatDauCT = DateTime.Parse("2005-9-13"),
                    ThoiGianKetThucCT = DateTime.Parse("2030-9-13"),
                    CongTacState = 1
                }
            );
            modelBuilder.Entity<QLNghiPhep>().HasData(
                new QLNghiPhep
                {
                    IDNP = 1,
                    IDSQ = 1,
                    ThoiGianBDNP = DateTime.Parse("2019-9-13"),
                    ThoiGianKTNP = DateTime.Parse("2019-10-13"),
                    NghiPhepState = 0
                }
            );
            modelBuilder.Entity<QLKhenThuongKiLuat>().HasData(
                new QLKhenThuongKiLuat
                {
                    IDQLKTKL =1,
                    IDSQ = 5,
                    NgayThucHien = DateTime.Parse("2020-6-13"),
                    LoaiKTKL = 1,
                    HinhThuc = "Huân chương",
                    DonViCap = "Trường sĩ quan thông tin",
                    NoiDung = "Huân chương lao động hạng 3"
                }
            );
            modelBuilder.Entity<QLQuaTrinhDaoTao>().HasData(
                new QLQuaTrinhDaoTao
                {
                    IDQLQTDT = 1,
                    IDSQ = 1, 
                    TenTruong = "Trường Sĩ quan Thông tin",
                    NganhHoc = "Công nghệ thông tin",
                    ThoiGianBDDT = DateTime.Parse("2004-9-4"),
                    ThoiGianKTDT = DateTime.Parse("2007-6-20"),
                    HinhThucDT = "Chính quy",
                    VanBang = "Cử nhân"
                }                   
            );
            modelBuilder.Entity<QLGiaDinhSQ>().HasData(
                new QLGiaDinhSQ
                {
                    IDQLGDSQ = 1,
                    IDSQ = 1,
                    QuanHe = "Chồng",
                    HoTen= "Test",
                    NgaySinh = DateTime.Parse("1967-8-13"),
                    GhiChu ="Nghề nghiệp: Test"
                }
            );
        }
    }
}
