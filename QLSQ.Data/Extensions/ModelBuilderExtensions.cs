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
            modelBuilder.Entity<NewCatetory>().HasData(
                new NewCatetory
                {
                    NewCatetoryID = 1,
                    NewCatetoryName = "Đào tạo"
                },
                 new NewCatetory
                 {
                     NewCatetoryID = 2,
                     NewCatetoryName = "Giáo dục QPAN"
                 },
                  new NewCatetory
                  {
                      NewCatetoryID = 3,
                      NewCatetoryName = "Khoa học và công nghệ"
                  },
                   new NewCatetory
                   {
                       NewCatetoryID = 4,
                       NewCatetoryName = "Tuyển sinh"
                   },
                    new NewCatetory
                    {
                        NewCatetoryID = 5,
                        NewCatetoryName = "Hội thảo - Hội nghị"
                    }
            );
            modelBuilder.Entity<New>().HasData(
                new New
                {
                    NewID = 1,
                    NewName = "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”",
                    NewContent = "<p>&emsp; Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. </p>  <p>&emsp; Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. </p>  <p>&emsp; Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.</p>",
                    NewDatePost = DateTime.Parse("03/04/2021 10:46"),
                    NewCount = 1,
                    NewCatetoryID = 2
                },
                 new New
                 {
                     NewID = 2,
                     NewName = "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”",
                     NewContent = "<p>&emsp; Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. </p>  <p>&emsp; Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. </p>  <p>&emsp; Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.</p>",
                     NewDatePost = DateTime.Parse("03/04/2021 10:46"),
                     NewCount = 1,
                     NewCatetoryID = 2
                 },
                  new New
                  {
                      NewID = 3,
                      NewName = "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”",
                      NewContent = "<p>&emsp; Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. </p>  <p>&emsp; Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. </p>  <p>&emsp; Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.</p>",
                      NewDatePost = DateTime.Parse("03/04/2021 10:46"),
                      NewCount = 1,
                      NewCatetoryID = 2
                  },
                   new New
                   {
                       NewID = 4,
                       NewName = "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”",
                       NewContent = "<p>&emsp; Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. </p>  <p>&emsp; Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. </p>  <p>&emsp; Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.</p>",
                       NewDatePost = DateTime.Parse("03/04/2021 10:46"),
                       NewCount = 1,
                       NewCatetoryID = 2
                   },
                    new New
                    {
                        NewID = 5,
                        NewName = "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”",
                        NewContent = "<p>&emsp; Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. </p>  <p>&emsp; Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. </p>  <p>&emsp; Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.</p>",
                        NewDatePost = DateTime.Parse("03/04/2021 10:46"),
                        NewCount = 1,
                        NewCatetoryID = 2
                    },
                     new New
                     {
                         NewID = 6,
                         NewName = "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”",
                         NewContent = "<p>&emsp; Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. </p>  <p>&emsp; Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. </p>  <p>&emsp; Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.</p>",
                         NewDatePost = DateTime.Parse("03/04/2021 10:46"),
                         NewCount = 1,
                         NewCatetoryID = 2
                     },
                     new New
                     {
                         NewID = 9,
                         NewName = "Ban đề tài cấp Bộ Quốc phòng tổ chức khảo sát, tọa đàm tại các đơn vị thông tin trên địa bàn Quân khu 5",
                         NewContent = "<p>&emsp;Chiều ngày 04/4/2018, tại Lữ đoàn Thông tin 575/QK5 (Đà Nẵng), Ban đề tài cấp Bộ Quốc phòng “Phát triển lý luận tổ chức, bảo đảm thông tin liên lạc trong tác chiến phòng thủ quân khu” đã tổ chức tọa đàm, trao đổi sau khi khảo sát, thu thập thông tin tại các đơn vị thông tin trên địa bàn Quân khu 5. Đại tá, PGS.TS Bùi Sơn Hà - Hiệu trưởng, Chủ nhiệm đề tài chủ trì buổi tọa đàm.</p>  <p>&emsp;Tham dự tọa đàm có đại biểu Bộ Tham mưu Quân khu 5; đại biểu Lữ đoàn Thông tin 132/Binh chủng Thông tin liên lạc; đại biểu Bộ chỉ huy quân sự thành phố Đà Nẵng; đại biểu chỉ huy Phòng Thông tin Quân khu; Chỉ huy Lữ đoàn, ban chỉ huy các tiểu đoàn và cán bộ, sĩ quan các cơ quan trực thuộc Lữ đoàn Thông tin 575.</p>    <p>&emsp;Sau khi nghe báo cáo đề dẫn và gợi ý của đồng chí Chủ nhiệm đề tài, các đại biểu đã tiến hành thảo luận, trao đổi, đóng góp ý kiến làm rõ những luận chứng, đồng thời cung cấp thêm các luận cứ khoa học cho đề tài. Nội dung thảo luận xoay quanh các vấn đề: xây dựng thế trận thông tin liên lạc của quân khu; Tổ chức hệ thống thông tin trong tác chiến phòng thủ quân khu; công tác phối hợp giữa thông tin quân khu với các lực lượng thông tin khác trên địa bàn; tổ chức biên chế trang bị phương tiện thông tin của lực lượng thông tin quân khu; thực trạng trang bị phương tiện thông tin và định hướng phát triển trong tương lai; thực trạng nguồn nhân lực bảo đảm thông tin liên lạc; công tác huấn luyện, luyện tập, diễn tập; những khó khăn, kiến nghị của các đơn vị thông tin quân khu; ...</p>    <p>&emsp;Buổi tọa đàm đã diễn ra sôi nổi và thành công tốt đẹp. Ban đề tài đã nhận được nhiều ý kiến đóng góp bổ ích từ kinh nghiệm thực tiễn tổ chức, bảo đảm thông tin liên lạc và xây dựng đơn vị của các đại biểu. Qua đó, Ban đề tài tiếp tục nghiên cứu hoàn chỉnh các nội dung chính cần giải quyết mà mục tiêu đề tài đã đặt ra. Theo kế hoạch, ban đề tài sẽ tiếp tục khảo sát, nghiên cứu thực tiễn tại một số quân khu và các đơn vị thông tin trong toàn quân.</p>",
                         NewDatePost = DateTime.Parse("2021-05-11 15:22:00.0000000"),
                         NewCount = 0,
                         NewCatetoryID = 3
                     },
                     new New
                     {
                         NewID = 10,
                         NewName = "Trường Đại học Thông tin liên lạc đạt giải cao tại vòng Sơ khảo Cuộc đua số năm 2019 do FPT tổ chức",
                         NewContent = "<p>&emsp;Chiều ngày 16/01, vòng Sơ khảo Cuộc đua số năm 2019 do Tập đoàn FPT tổ chức đã chính thức diễn ra tại Hội trường F, Trường Đại học Bách khoa Đà Nẵng với 12 đội đại diện cho 4 trường đại học thuộc khu vực Miền Trung tham gia tranh tài. Trường Đại học thông tin liên lạc có 6 đội tham gia (SQ26/Tiểu đoàn 26, TCU STT/Tiểu đoàn 30, TCU Racer/Tiểu đoàn 28, H20/Hệ 20, AT_AI/Khoa Kỹ thuật viễn thông, K6_AITech/Khoa Công nghệ thông tin).</p>  <p>&emsp;Ngoài 6 đội của Trường Đại học thông tin liên lạc còn có 1 đội của Trường Đại học Nha Trang, 2 đội của Trường Đại học Quy Nhơn và 3 đội của Trường Đại học Bách khoa Đà Nẵng. Các đội tham gia tranh tài qua 3 phần thi với thể thức loại trực tiếp: Xử lý ảnh, Phản biện và Lập trình nhanh. Cơ cấu điểm cho 3 phần lần lượt là 40%, 30% và 30%. Sẽ có 6 đội đạt điểm số cao nhất ở phần Xử lý ảnh được Ban Tổ chức lựa chọn vào thi phần Phản biện. Ở phần Phản biện, Ban Tổ chức lựa chọn 4 đội có điểm số cao nhất để vào thi phần Lập trình nhanh. Hai đội đạt điểm cao nhất ở vòng Sơ khảo sẽ được lựa chọn thi vòng Bán kết vào tháng 3 năm 2019 tại thành phố Hồ Chí Minh.</p>     <p>&emsp;Trong phần Xử lý ảnh: Các đội tiến hành lập trình cho chiếc xe ảo chạy trên sa hình, thời gian lập trình là 30 phút, thời gian chạy là 2 phút. Kết thúc phần Xử lý ảnh có 3 đội của Nhà trường đứng ở vị trí thứ 2, 3, 6 (đội SQ26/Tiểu đoàn 26, đội TCU Racer/Tiểu đoàn 28, đội TCU STT/Tiểu đoàn 30) và lọt vào vòng trong. Cùng đi tiếp vào vòng trong có đội Cosntu2 của Trường Đại học Nha Trang (đứng ở vị trí thứ 1) và 2 đội của Trường Đại học Bách khoa Đà Nẵng (đứng ở vị trí thứ 4 và thứ 5).</p>     <p>&emsp;Trong phần thi Phản biện: Các đội thi có 2 phút để trình bày thuật toán, 2 phút trả lời chất vấn của đội bạn và 3 phút trả lời các câu hỏi của Ban Giám khảo. Kết quả sau phần thi Phản biện, đội Cosntu2 của Trường Đại học Nha Trang vẫn tiếp tục đứng ở vị trí thứ 1, xếp thứ 2 là đội SQ26/Tiểu đoàn 26, xếp thứ 3 là đội TCU Racer/Tiểu đoàn 28, thứ 4 là đội Duckies của Trường Đại học Bách khoa Đà Nẵng và tiếp tục đi tiếp vào phần thi Lập trình nhanh.</p>",
                         NewDatePost = DateTime.Parse("2021-05-11 15:22:00.0000000"),
                         NewCount = 0,
                         NewCatetoryID = 3
                     },
                     new New
                     {
                         NewID = 11,
                         NewName = "Đội SQ26 - TCU chiến thắng rực rỡ tại vòng bán kết Cuộc thi Cuộc đua số khu vực miền Nam",
                         NewContent = "<p>&emsp;Được khởi động từ tháng 11/2018 với sự đồng hành của VTV (Đài truyền hình Việt Nam) và sự bảo trợ của Bộ Khoa học và Công nghệ, Bộ Thông tin và Truyền thông.... Vòng bán kết cuộc thi Cuộc đua số 2018 - 2019 khu vực miền Nam đã diễn ra lúc 14.00 ngày 07/4/2019 tại Nhà thi đấu Đại học Bách khoa (Cơ sở 2), Đại học quốc gia TP.Hồ Chí Minh, làng Đại học quốc gia, thị xã Dĩ An, tỉnh Bình Dương.  Vòng sơ khảo ở hai khu vực Nam bộ và miền Trung, Tây Nguyên trong tháng 1/2019, đã chọn ra 8 đội xuất sắc nhất vào vòng bán kết khu vực miền Nam. Trong đó, đến từ ĐH Bách khoa TP.Hồ Chí Minh có 2 đội: KOR và PPL Lover; 2 đại diện của Trường ĐH Lạc Hồng là đội LHU Speed và LHU The Walkers. Hai thành viên của ĐH Khoa học tự nhiên TP.Hồ Chí Minh là HCMUS Team 09 và Dateh IT cùng đội CDSNT2 (Trường ĐH Nha Trang) và SQ26 của Trường ĐH Thông tin liên lạc.</p>     <p>&emsp;Đề thi tại vòng bán kết năm nay (theo đánh giá của Ban Tổ chức và các chuyên gia) được cho là khó hơn nhiều so với hai năm trước. Các đội thi sẽ phải lập trình để xe chạy được theo làn đường trong điều kiện ánh sáng thay đổi; tránh đi lên vỉa hè; khoanh vùng, xác định và tránh được các vật cản (với hình dáng bất kỳ) xuất hiện trên đường, tự động phân tích loại vật cản để từ đó ra quyết định di chuyển; nhận dạng và hành động được theo biển báo giao thông được thay đổi ngẫu nhiên. Để đáp ứng với các bài toán công nghệ ngày càng cao đó, tại cuộc thi năm nay, FPT cũng đã cho nâng cấp mô hình xe tự hành lên tỷ lệ 1/7 thay cho 1/10 so với trước.</p>      <p>&emsp;Theo thể lệ của cuộc thi, mỗi đội có 2 lượt thi đấu trên sa hình (1 lượt trên sân đỏ và 1 lượt trên sân xanh). Mỗi lượt gồm 2 phút chuẩn bị và 3 phút thi đấu; các đội chuẩn bị xong đưa xe vào vạch xuất phát, sau hiệu lệnh của trọng tài, xe đua phải tự động xuất phát. Trong 3 phút thi đấu của mỗi lượt, mỗi đội có thể chạy số vòng tùy ý, Ban Tổ chức sẽ tính điểm dựa trên vòng thi có kết quả cao nhất của đội thi. Khi xe bị sự cố...hoặc vi phạm quy chế cuộc thi, lượt chạy đó không được tính, đội thi phải đưa xe quay về vạch xuất phát và thi lại (không giới hạn lượt khởi động lại).</p>     <p>&emsp;Kết quả thi đấu được tính theo thời gian ngắn nhất khi đội thi hoàn thành một vòng đua hoàn chỉnh (tính từ điểm xuất phát, đi qua các mốc địa điểm do Ban Tổ chức đặt sẵn, quay về điểm ban đầu). Nếu đội thi không hoàn thành được trọn vẹn một vòng đua, kết quả được tính theo quãng đường xa nhất đội đó đi được. Trong trường hợp 2 đội có cùng quãng đường, đội thi có thời gian xe chạy ít hơn được tính kết quả cao hơn.</p>",
                         NewDatePost = DateTime.Parse("2021-05-11 15:22:00.0000000"),
                         NewCount = 0,
                         NewCatetoryID = 3
                     },
                     new New
                     {
                         NewID = 12,
                         NewName = "Sáng tạo, làm chủ công nghệ quân sự",
                         NewContent = "<p>&emsp;Nhà máy Z755 (Binh chủng Thông tin liên lạc) là doanh nghiệp quốc phòng và an ninh, cơ sở bảo đảm kỹ thuật thông tin liên lạc (TTLL) quân sự cấp chiến lược của quân đội. Để hoàn thành tốt nhiệm vụ được giao, Đảng ủy, Ban giám đốc nhà máy đã triển khai nhiều giải pháp đồng bộ; trong đó coi trọng nâng cao chất lượng thực hiện Cuộc vận động “Phát huy truyền thống, cống hiến tài năng, xứng danh Bộ đội Cụ Hồ” (gọi tắt là Cuộc vận động).</p>    <p>&emsp;Đại tá Nguyễn Ngọc Anh, Chính ủy nhà máy, cho biết: 5 năm qua, các nội dung của Cuộc vận động luôn được thể hiện trong tất cả các chỉ tiêu thi đua quyết thắng hằng năm của đơn vị; là trọng tâm, trọng điểm của nhiều đợt thi đua cao điểm, đột kích. Chúng tôi cụ thể hóa thực hiện cuộc vận động với các nhiệm vụ xây dựng tổ chức đảng, xây dựng đơn vị và các phong trào khác, như: “Ngành hậu cần quân đội làm theo lời Bác Hồ dạy”, “Đơn vị quản lý tài chính tốt”, “Nâng cao năng lực quản trị doanh nghiệp”, “Lao động giỏi, lao động sáng tạo”, “Năng suất, chất lượng hiệu quả”, “Phát huy sáng kiến, cải tiến kỹ thuật” và mô hình 5S (sàng lọc, sắp xếp, sạch sẽ, săn sóc, sẵn sàng)...</p>  <p>&emsp;Qua quá trình thực hiện cuộc vận động đã tạo môi trường thuận lợi để cán bộ, đảng viên, công nhân viên, người lao động nhà máy phát huy tinh thần tự lực, tự cường, say mê nghiên cứu, sáng tạo những sản phẩm công nghệ cao phục vụ công tác bảo đảm TTLL quân sự và đời sống dân sinh. Đặc biệt, trước yêu cầu khai thác, ứng dụng hệ thống thiết bị công nghệ hiện đại vào chế tạo, sửa chữa, cung cấp thiết bị thông tin cho các đơn vị toàn quân, Đảng ủy, Ban giám đốc nhà máy ưu tiên phát triển nguồn nhân lực, khuyến khích cán bộ, nhân viên “cống hiến tài năng” ứng dụng vào thực tiễn, nâng cao chất lượng công tác chuyên môn. Theo đó, phong trào thi đua sáng tạo diễn ra sôi nổi ở các cơ quan, đơn vị, hoàn thành nhiều sáng kiến có giá trị. Trong 5 năm gần đây, nhà máy đã có gần 200 đề tài khoa học, sáng kiến cải tiến kỹ thuật; trong đó có hơn 20 đề tài được trao giải “Tuổi trẻ sáng tạo” cấp toàn quân và cấp binh chủng. Các đề tài, sáng kiến được ứng dụng thực tiễn làm lợi cho tập thể hàng chục tỷ đồng.</p>    <p>&emsp;Theo Đại tá Đặng Quang Khải, Giám đốc Nhà máy Z755, nhờ thực hiện cuộc vận động, trình độ chuyên môn nghiệp vụ của đội ngũ cán bộ, nhân viên không ngừng được nâng lên. Nhà máy đã nghiên cứu thành công một số sản phẩm có giá trị lớn, như: Máy phát chuyên dụng 91Z phục vụ biển, đảo; thiết bị thu phát siêu cao tần trong hệ thống Vsat; an-ten sóng ngắn dùng cho cơ động; máy Ozone quân sự... Các đề tài nghiên cứu có tính đột phá, hàm lượng trí tuệ và tính ứng dụng cao, góp phần giúp nhà máy làm chủ công nghệ sửa chữa trang bị thông tin và sản xuất vật tư kỹ thuật, phát triển đồng bộ cho các phương tiện vô tuyến điện thế hệ mới, thông tin vệ tinh, vi-ba số và nhiều thiết bị điện tử khác. Nhà máy từng bước chinh phục những kỹ thuật hiện đại đáp ứng tốt yêu cầu nhiệm vụ.</p>    <p>&emsp;Với chủ trương “đi tắt đón đầu” và những kết quả thiết thực từ cuộc vận động, Nhà máy Z755 đang nỗ lực xây dựng đội ngũ cán bộ, kỹ sư, nhân viên chuyên môn có trình độ cao, say mê tìm tòi, sáng tạo, cải tiến kỹ thuật, ứng dụng công nghệ trong thực hiện nhiệm vụ. “Đây là lực lượng nòng cốt, sáng tạo, cống hiến tài năng xây dựng nhà máy trở thành cơ sở nghiên cứu, sửa chữa, sản xuất và ứng dụng khoa học, kỹ thuật thông tin công nghệ cao hàng đầu của quân đội”, Đại tá Nguyễn Ngọc Anh nhấn mạnh.</p>",
                         NewDatePost = DateTime.Parse("2021-05-11 15:22:00.0000000"),
                         NewCount = 0,
                         NewCatetoryID = 3
                     },
                     new New
                     {
                         NewID = 13,
                         NewName = "Trường Sĩ quan Thông tin tặng máy sát khuẩn các trường trên địa bàn tỉnh Khánh Hòa",
                         NewContent = "<p>&emsp; Trường Sĩ quan Thông tin vừa tổ chức trao máy phun dung dịch sát khuẩn tay tự động tặng các trường trên địa bàn tỉnh Khánh Hòa nhân dịp học sinh đi học trở lại sau thời gian nghỉ vì dịch Covid-19.</p>    <p>&emsp;Các trường được tặng máy phun dung dịch sát khuẩn tay tự động gồm: Cao đẳng Sư phạm Trung ương Nha Trang; THPT Hermann; THCS Mai Xuân Thưởng; Tiểu học Vĩnh Hòa; Tiểu học Vĩnh Phước; THCS Lý Thường Kiệt; Tiểu học Lộc Thọ và THCS Lý Thái Tổ.</p>    <p>&emsp;Máy phun dung dịch sát khuẩn tay tự động do cán bộ, giảng viên của Trường Sĩ quan Thông tin thiết kế, có chức năng phun sương dung dịch với một lượng vừa đủ để sát trùng hai tay hoàn toàn tự động mà không cần chạm tay vào máy. Đây là một trong những sản phẩm nghiên cứu khoa học hết sức có ý nghĩa mà trước đó cán bộ, giảng viên nhà trường đã nghiên cứu, chế tạo để phục vụ công tác phòng, chống dịch Covid-19.</p>",
                         NewDatePost = DateTime.Parse("2021-05-11 15:22:00.0000000"),
                         NewCount = 0,
                         NewCatetoryID = 3
                     },
                     new New
                     {
                         NewID = 14,
                         NewName = "Thư viện ứng dụng công nghệ 4.0 ở Trường Sĩ quan Thông tin",
                         NewContent = "<p>&emsp;Nhờ hệ thống thư viện áp dụng công nghệ 4.0 ở Trường Sĩ quan Thông tin (SQTT), đội ngũ giáo viên, học viên nhà trường được tiếp cận một kho học liệu và thư viện sách số hóa rất phong phú. Cùng với đọc sách truyền thống, nguồn sách, giáo trình được số hóa góp phần nâng cao chất lượng dạy và học.</p>    <p>&emsp;Đồng bộ giải pháp tiếp cận tri thức</p>    <p>&emsp;Đến Trung tâm Học liệu-Thư viện (TTHL-TV), Trường SQTT, nhiều người không khỏi ngỡ ngàng về quy mô cũng như không gian yên tĩnh, thoáng đãng. Tại đây, nhiều phương pháp, cách làm khoa học tạo nên một môi trường tiếp cận tri thức rất thuận lợi, với những phần việc và cách làm sáng tạo, như: Xây dựng cơ sở dữ liệu thư mục và toàn văn, số hóa giáo trình, tài liệu theo chương trình môn học... Đến nay, đơn vị đã số hóa và đưa lên mạng 380 đầu sách, gần 70.000 trang toàn văn (trong tổng số gần 1.200 đầu sách, hơn 240.000 trang toàn văn), gồm sách tiếng Việt hơn 900 cuốn, sách tiếng Anh gần 300 cuốn. Các loại tài liệu số đưa lên mạng đã nhanh chóng được người dùng khai thác có hiệu quả phục vụ huấn luyện. TTHL-TV có tổng diện tích 4.200m2, được đầu tư hiện đại và thông minh, có kho giáo trình, hội trường, các phòng đọc tự chọn, đọc điện tử, truy cập internet, phòng mượn, kho giáo trình mật, các phòng hội thảo. Thư viện hoạt động theo hai khu vực chính: Thư viện truyền thống và thư viện điện tử-thư viện số, quản lý bằng công nghệ kiểm soát sóng vô tuyến điện RFID, gồm: Cổng an ninh, trạm thủ thư đa nhiệm, máy kiểm kê cầm tay.</p>  <p>&emsp;Hiện nay, thư viện điện tử của nhà trường được khai thác hiệu quả phục vụ yêu cầu giáo dục-đào tạo và nghiên cứu khoa học. Bạn đọc toàn trường có thể truy cập website TTHL-TV để khai thác tài liệu trong mọi thời gian, từ các địa điểm của cơ quan, khoa giáo viên và đơn vị thông qua mạng LAN của trường. Các hoạt động giao dịch mượn, trả sách của bạn đọc và công tác nghiệp vụ thư viện được thực hiện thông qua mạng máy tính và phần mềm tin học chuyên dụng của tập đoàn CMC (phần mềm quản lý Thư viện điện tử Ilib4.6, phần mềm thư viện số DLIB3.0). TTHL-TV nhà trường đã liên kết với 14 học viện, nhà trường và đơn vị trong quân đội thông qua mạng LAN và mạng MISTEN/Bộ Quốc phòng. Đặc biệt, thư viện nhà trường đã đưa website TTHL-TV lên internet. Các hoạt động liên thông, liên kết qua internet với TTHL-TV Trường Đại học Nha Trang và Trường Đại học Bách khoa TP Hồ Chí Minh... rất thuận lợi cho cán bộ, giảng viên, học viên, sinh viên nghiên cứu học tập. Trung tâm đã cấp hơn 1.300 thẻ bạn đọc mã vạch trong tổng số gần 3.500 thẻ bạn đọc mã vạch phục vụ nhu cầu mượn, trả sách tại thư viện.</p>    <p>&emsp;Trung tá, PGS, TS Nguyễn Hải Hà, Trưởng phòng Khoa học quân sự nhà trường, cho biết: “Ngay sau khi TTHL-TV đi vào hoạt động, nhà trường đã tiến hành đồng bộ nhiều giải pháp, khuyến khích cán bộ, giảng viên, học viên coi đây là một địa chỉ học tập không thể thiếu. Đặc biệt, chúng tôi tập trung sắp xếp kế hoạch học tập trên giảng đường, thời gian sinh hoạt ở đơn vị để học viên có quỹ thời gian đến với thư viện. Nơi đây có một không gian lý tưởng để học tập, vừa tạo điều kiện cho giảng viên, học viên nghiên cứu, học tập.</ p >    < p > &emsp; Tự học tập, nghiên cứu hiệu quả</ p >    < p > &emsp; Trung úy Hoàng Văn Huy, học viên đến từ Vùng 4 Hải quân đang theo lớp tiếng Anh B1 tại nhà trường, cho biết: “TTHL - TV của nhà trường thực sự là địa chỉ cần tìm đến đáp ứng nhu cầu học tập, nghiên cứu. Đến đây, mọi yêu cầu về học liệu đều được đáp ứng đầy đủ và có một không gian rất thú vị”.</ p >    < p > &emsp; Điều đặc biệt, Trường SQTT có nhiều cách làm sáng tạo, đồng hành với người học, như: Trong quá trình học tập, nếu có nhu cầu về giáo trình, tài liệu, học viên chỉ cần báo với trung tâm, sẽ có người mang tài liệu xuống tận tiểu đoàn quản lý học viên để giảng viên, sinh viên mượn nghiên cứu.Với giáo trình, tài liệu mật, học viên đều được cấp thẻ mượn nghiên cứu trực tiếp tại thư viện. Học viên các đơn vị, các khoa cần sách lập kế hoạch mượn và gửi cho trung tâm qua email mạng LAN.Trung tâm HL - TV sẽ rà soát lịch huấn luyện và thực tế giáo trình, tài liệu trong kho để cho mượn theo kế hoạch. Đây là quy chế tổ chức và hoạt động của TTHL - TV.Bên cạnh đó, các phòng đọc sách tự chọn, phòng đọc điện tử, phòng internet, phòng mượn... phục vụ bạn đọc toàn trường nghiên cứu, tham khảo tất cả các ngày trong tuần và các buổi tối thứ 2, thứ 5.Nguồn sách, giáo trình, tài liệu cho thư viện thường xuyên được bổ sung, cập nhật nhu cầu của bạn đọc, giáo trình, tài liệu theo các chuyên ngành mới. Trung tá QNCN Vũ Hải Sơn, Thư viện trưởng, cho biết: “Cán bộ, nhân viên chúng tôi thường xuyên tổ chức lực lượng trực bảo đảm phục vụ tốt nhất nhu cầu của người học. </p>    <p>&emsp;Các loại tài liệu số đưa lên mạng nhanh chóng được người dùng khai thác có hiệu quả, phục vụ tốt nhiệm vụ huấn luyện. Trung tâm là đơn vị khai thác tốt các trang thiết bị hiện đại được cấp, cập nhật và sử dụng thành thạo các phần mềm tự động hóa, nâng cao hiệu quả số hóa tài liệu, từng bước đáp ứng tiêu chí xây dựng nhà trường thông minh; tạo môi trường thân thiện, thu hút bạn đọc đến TTHL-TV học tập, nghiên cứu, tham khảo...</p>",
                         NewDatePost = DateTime.Parse("2021-05-11 15:22:00.0000000"),
                         NewCount = 0,
                         NewCatetoryID = 3
                     },
                       new New
                       {
                           NewID = 15,
                           NewName = "Những điều cần biết về tuyển sinh đại học quân sự vào Trường Sĩ quan Thông tin năm 2021 (Ký hiệu trường: TTH)",
                           NewContent = "<p>Những điều cần biết về tuyển sinh đại học quân sự vào Trường Sĩ quan Thông tin năm 2021 (Ký hiệu trường: TTH)</p>    <p>Ngành đào tạo: Chỉ huy - Tham mưu Thông tin; Mã ngành: 7860221</p>    <p>Địa chỉ: Số 101 đường Mai Xuân Thưởng, phường Vĩnh Hòa, Thành phố Nha Trang, tỉnh Khánh Hòa.</p>    <p>Điện thoại: 02583 831805; 0982100596. Fax: 02583 832055</p>    <p>Website: http://www.tcu.edu.vn ; Email: tcu@tsqtt.edu.vn</p>    <p>1. Chỉ tiêu tuyển sinh năm 2021</p>    <p>- Tổng chỉ tiêu: 395. Trong đó Miền Bắc (từ tỉnh Quảng Bình trở ra): 257; Miền Nam (từ tỉnh Quảng Trị trở vào): 138.</p>    <p>+ Tuyển 03 chỉ tiêu đi đào tạo ở nước ngoài;</p>    <p>+ Tuyển 12 chỉ tiêu đi đào tạo ở trường ngoài Quân đội;</p>    <p>+ Số chỉ tiêu trúng tuyển còn lại, Nhà trường tổ chức đào tạo: Ngành Chỉ huy Tham mưu thông tin (chuyên ngành thông tin: Lục quân, Hải quân, Phòng không - Không quân); Ngành Chỉ huy Tham mưu Tác chiến không gian mạng.</p>    <p>- Tổ hợp môn xét tuyển: A00 (Toán, Vật lý, Hóa học); A01 (Toán, Vật lý, Tiếng Anh). Thực hiện lấy cùng một điểm chuẩn đối với tổ hợp xét tuyển A00, tổ hợp xét tuyển A01; một điểm chung với đối tượng thí sinh là quân nhân và thanh niên ngoài quân đội. Điểm trúng tuyển theo chỉ tiêu của khu vực phía Bắc, phía Nam.</p>    <p>2. Đối tượng tuyển sinh</p>    <p>- Nam thanh niên ngoài Quân đội (kể cả quân nhân đã xuất ngũ và công dân hoàn thành nghĩa vụ tham gia công an nhân dân) số lượng đăng ký dự tuyển không hạn chế.</p>    <p>- Hạ sĩ quan, binh sĩ đang phục vụ tại ngũ theo quy định của pháp luật về nghĩa vụ quân sự, có thời gian phục vụ tại ngũ 12 tháng trở lên, tính đến tháng 4 năm 2021 (quân nhân nhập ngũ từ năm 2020 trở về trước); quân nhân chuyên nghiệp, công nhân và viên chức quốc phòng phục vụ trong quân đội đủ 12 tháng trở lên, tính đến tháng 9 năm 2021.</p>    <p>- Yêu cầu về độ tuổi: Tính đến năm 2021.</p>    <p>+ Thanh niên ngoài Quân đội từ 17 đến 21 tuổi;</p>    <p>+ Quân nhân tại ngũ hoặc đã xuất ngũ và công dân hoàn thành nghĩa vụ tham gia công an nhân dân từ 18 đến 23 tuổi.</p>    <p>3. Phương thức tuyển sinh</p>    <p>- Xét tuyển trên cơ sở kết quả Kỳ thi tốt nghiệp THPT năm 2021 và thí sinh (thanh niên ngoài Quân đội kể cả quân nhân đã xuất ngũ và công dân hoàn thành nghĩa vụ tham gia công an nhân dân) phải qua sơ tuyển tại Ban Tuyển sinh quân sự (TSQS) cấp quận, huyện, thị xã, thành phố trực thuộc tỉnh, quân nhân tại ngũ sơ tuyển tại Ban TSQS cấp trung đoàn và tương đương).</p>    <p>- Thí sinh đăng ký và dự Kỳ thi tốt nghiệp THPT năm 2021 theo quy định của Bộ GD&ĐT.</p>    <p>- Xét tuyển thẳng theo quy định hiện hành.</p>    <p>4. Điều kiện sơ tuyển đối với thí sinh đăng ký xét tuyển</p>    <p>- Thí sinh tự nguyện đăng ký dự tuyển vào Trường Sĩ quan Thông tin:</p>    <p>+ Khi tốt nghiệp chấp hành sự phân công công tác của Bộ Quốc phòng;</p>    <p>+ Lý lịch chính trị gia đình và bản thân rõ ràng, đủ điều kiện để kết nạp vào Đảng Cộng sản Việt Nam;</p>    <p>+ Phẩm chất đạo đức tốt, là Đảng viên Đảng Cộng sản Việt Nam hoặc Đoàn viên Đoàn Thanh niên Cộng sản Hồ Chí Minh;</p>    <p>+ Là quân nhân phải được đơn vị đánh giá hoàn thành tốt nhiệm vụ trong thời gian phục vụ tại ngũ.</p>    <p>- Sức khoẻ:</p>    <p>+ Tuyển chọn thí sinh đạt Điểm 1 và Điểm 2 theo Quy định tại Thông tư  liên tịch số 16/2016/TTLT-BYT-BQP ngày 30/6/2016 của Bộ trưởng Bộ Y tế, Bộ trưởng Bộ Quốc phòng;</p>    <p>+ Thí sinh cao từ 1,65 m trở lên, cân nặng từ 50 kg trở lên;</p>    <p>+ Thí sinh có hộ khẩu thường trú từ 3 năm trở lên thuộc khu vực 1, hải đảo và thí sinh là người dân tộc thiểu số, dự tuyển vào Trường phải đạt chiều cao từ 1,62 m trở lên;</p>    <p>+ Thí sinh các dân tộc: Cống, Mảng, Pu Péo, Si La, Cờ Lao, Bố Y, La Ha, Ngái, Chứt, Ơ Đu, Brâu, Rơ Măm, Lô Lô, Lự, Pà Thẻn, La Hủ dự tuyển vào Trường phải đạt chiều cao từ 1,60 m trở lên, các tiêu chuẩn khác thực hiện như đối với thí sinh là người dân tộc thiểu số nói chung.</p>    <p>- Không tuyển thí sinh: mắt mắc tật khúc xạ cận thị, trên cơ thể có hình xăm, chữ xăm.</p>    <p>5. Hồ sơ đăng ký sơ tuyển và xét tuyển</p>    <p>- Mỗi thí sinh phải làm 02 loại hồ sơ riêng biệt:</p>    <p>+ Một bộ hồ sơ đăng ký dự Kỳ thi tốt nghiệp THPT do Bộ GD&ĐT phát hành;</p>    <p>+ Một bộ hồ sơ đăng ký sơ tuyển do Ban Tuyển sinh quân sự Bộ Quốc phòng phát hành thống nhất trong toàn quốc, gồm: 03 phiếu đăng ký sơ tuyển; 01 phiếu khám sức khỏe; 01 bản thẩm tra, xác minh chính trị; 01 giấy chứng nhận được hưởng ưu tiên đối với những thí sinh thuộc diện ưu tiên (nếu có); 04 ảnh chụp thẳng chân dung (kiểu chứng minh nhân dân), cỡ 4x6 cm, trên nền phông màu xanh hoặc vàng, trong thời hạn 6 tháng tính đến thời điểm đăng ký dự tuyển;</p>    <p>- Thí sinh phải đăng ký xét tuyển nguyện vọng 1 (nguyện vọng cao nhất) vào Trường Sĩ quan Thông tin ngay từ khi làm hồ sơ sơ tuyển; các nguyện vọng còn lại thí sinh đăng ký vào các trường ngoài Quân đội, thực hiện đăng ký theo quy định của Bộ GD&ĐT.</p>    <p>- Sau khi có kết quả thi tốt nghiệp THPT năm 2021, thí sinh được điều chỉnh nguyện vọng đăng ký xét tuyển theo quy định của Bộ GD&ĐT. Đối với việc điều chỉnh đăng ký xét tuyển vào các trường quân đội, cho phép thí sinh được điều chỉnh nguyện vọng đăng ký xét tuyển (nguyện vọng 1) theo nhóm các trường bao gồm các học viện: Hậu cần, Hải quân, Biên phòng, Phòng không - Không quân (hệ chỉ huy tham mưu) và các trường sĩ quan: Lục quân 1, Lục quân 2, Chính trị, Đặc công, Pháo binh, Tăng - Thiếp giáp, Phòng hóa, Thông tin, Công binh theo đúng vùng  miền và đối tượng tuyển sinh.</p>    <p> - Xét tuyển đợt 1:</p>    <p>+ Nhà trường chỉ xét tuyển đào tạo đại học quân sự đối với những thí sinh đã qua sơ tuyển, có đủ tiêu chuẩn theo quy định của Bộ Quốc phòng;</p>    <p>+ Tham dự Kỳ thi tốt nghiệp THPT năm 2021 để lấy kết quả xét tuyển đại học;</p>    <p>+ Các bài thi, môn thi phù hợp với tổ hợp các môn thi để xét tuyển vào các trường trong Quân đội mà thí sinh đăng ký.</p>    <p>- Đăng ký xét tuyển nguyện vọng 1 (nguyện vọng cao nhất) vào hệ đào tạo đại học quân sự Trường Sĩ quan Thông tin hoặc nhóm trường thí sinh được điều chỉnh nguyện vọng xét tuyển (nguyện vọng 1) theo đúng tổ hợp môn xét tuyển của trường. Xét điểm từ cao xuống thấp. Khi chỉ tiêu còn thiếu do thí sinh không đến nhập học hoặc khi thí sinh đến nhập học nhưng không đủ tiêu chuẩn nhập học bị loại, Nhà trường xét tuyển bổ sung theo quyết định của Ban TSQS Bộ Quốc phòng. Quy trình xét tuyển thực hiện theo quy chế của Bộ GD&ĐT, Bộ Quốc phòng và bảo đảm đúng tỷ lệ vùng, miền.</p>    <p>6. Công bố kết quả tuyển sinh, báo gọi nhập học</p>    <p>- Năm 2021 Nhà trường công bố công khai kết quả tuyển sinh theo quy chế của Bộ GD&ĐT trên trang thông tin điện tử của Trường tại www.tcu.edu.vn.</p>    <p>- Sau khi được Ban TSQS Bộ Quốc phòng thông báo điểm chuẩn tuyển sinh, Nhà trường gửi giấy báo gọi nhập học đối với thí sinh trúng tuyển theo quy định.</p>",
                           NewDatePost = DateTime.Parse("2021-05-12 08:15:18.0000000"),
                           NewCount = 0,
                           NewCatetoryID = 4
                       },
                       new New
                       {
                           NewID = 16,
                           NewName = "Trường Đại học Thông tin liên lạc thông báo tuyển sinh các lớp tiếng Nhật ngắn hạn",
                           NewContent = "<p>&emsp;Trường Đại học Thông Tin Liên Lạc – Trung tâm công nghệ thông tin và ngoại ngữ (Mitech) cùng hợp tác với công ty Valley Campus Sài Gòn (VCS) và các doanh nghiệp của Nhật Bản tổ chức chương trình đào tạo hướng nghiệp nhằm định hướng nghề nghiệp, tạo môi trường cho sinh viên tiếp xúc các cơ hội học tập và làm việc tại Nhật Bản thông qua các chương trình học bổng du học, chương trình internship tại Nhật Bản dành cho sinh viên các trường đại học, chương trình kỹ sư cầu nối (BrSE), chương trình làm việc tại Nhật… Để có thể đáp ứng yêu cầu về năng lực về tiếng Nhật, giúp sinh viên tự tin  ứng tuyển các chương trình nêu trên, Trung tâm tổ chức các lớp Tiếng nhật các cấp độ. Cụ thể như sau:</p>    <p><b>1. Đối tượng tuyển sinh</b></p>    <p>- Người yêu thích và muốn bắt đầu làm quen với tiếng Nhật;</p>    <p>- Muốn học tiếng Nhật để tham dự các kì thi JLPT từ N5~N1.</p>    <p>- Muốn học tiếng Nhật để chuẩn bị cho các kỳ du học, thực tập sinh , tu nghiệp sinh, kỹ sư, kỹ thuật viên đi học tập và làm việc tại Nhật Bản.</p>    <p>- Muốn học tiếng Nhật để làm việc tại các công ty Nhật Bản ở Việt Nam.</p>  <p><b>2. Thời gian khai giảng (dự kiến):</b> Ngày 23; 23 tháng 07 năm 2020. (Đăng kí từ ngày 24/06/2020.).</p>    <p><b>3. Địa điểm:</b> Trung tâm Công nghệ Thông tin và ngoại ngữ - trường đại học thông tin liên lạc – 101B Mai Xuân Thưởng, Nha Trang, Khánh Hòa.</p>    <p><b>5. Liên hệ:</b></p>    <p><b>Điện thoại :</b> </p>    <p>098 2838352 (Mr Thuận)</p>    <p>0347 705 507 (Ms Hằng)</p>    <p>Email: valleycampussaigon@gmail.com</p>    <p>Gmail:  valleycampussaigon@gmail.com</p>",
                           NewDatePost = DateTime.Parse("2021-05-12 08:15:18.0000000"),
                           NewCount = 0,
                           NewCatetoryID = 1
                       },
                       new New
                       {
                           NewID = 18,
                           NewName = "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”",
                           NewContent = "<p>&emsp;Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường.&nbsp;</p><p>&emsp;Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng.</p><p>&emsp;Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.</p>",
                           NewDatePost = DateTime.Parse("2021-05-12 08:15:18.0000000"),
                           NewCount = 0,
                           NewCatetoryID = 5
                       }
            );
            modelBuilder.Entity<NewImage>().HasData(
                new NewImage
                {
                    NewImageID = 3,
                    NewID = 1,
                    ImagePath = "26-3S1.jpg",
                    DateCreated = DateTime.Parse("2021-05-11 14:46:04.1351113"),
                    FileSize = 1195802
                },
                new NewImage
                {
                    NewImageID = 4,
                    NewID = 2,
                    ImagePath = "26-3S1.jpg",
                    DateCreated = DateTime.Parse("2021-05-11 14:46:04.1351113"),
                    FileSize = 1195802
                },
                new NewImage
                {
                    NewImageID = 5,
                    NewID = 3,
                    ImagePath = "26-3S1.jpg",
                    DateCreated = DateTime.Parse("2021-05-11 14:46:04.1351113"),
                    FileSize = 1195802
                },
                new NewImage
                {
                    NewImageID = 6,
                    NewID = 4,
                    ImagePath = "26-3S1.jpg",
                    DateCreated = DateTime.Parse("2021-05-11 14:46:04.1351113"),
                    FileSize = 1195802
                },
                new NewImage
                {
                    NewImageID = 7,
                    NewID = 5,
                    ImagePath = "26-3S1.jpg",
                    DateCreated = DateTime.Parse("2021-05-11 14:46:04.1351113"),
                    FileSize = 1195802
                },
                new NewImage
                {
                    NewImageID = 8,
                    NewID = 6,
                    ImagePath = "26-3S1.jpg",
                    DateCreated = DateTime.Parse("2021-05-11 14:46:04.1351113"),
                    FileSize = 1195802
                },
                 new NewImage
                 {
                     NewImageID = 9,
                     NewID = 9,
                     ImagePath = "Toadamdetai.jpg",
                     DateCreated = DateTime.Parse("2021-05-11 15:22:00.5904483"),
                     FileSize = 105219
                 },
                 new NewImage
                 {
                     NewImageID = 10,
                     NewID = 10,
                     ImagePath = "CDS0.jpeg",
                     DateCreated = DateTime.Parse("2021-05-11 15:28:27.1009599"),
                     FileSize = 82202
                 }
            ); 
            modelBuilder.Entity<Slide>().HasData(
                new Slide
                {
                    SlideID = 1,
                    SlideUrl = "#",
                    SlideName = "Trường sĩ quan thông tin - Đại học thông tin liên lạc",
                    SlideContent = "Thông tin tuyển sinh đại học quân sự 2021",
                    SlideImage = "TuyenSinh2021.jpg",
                    SlideTimePost = DateTime.Parse("2021-04-04")
                },
                 new Slide
                 {
                     SlideID = 2,
                     SlideUrl = "#",
                     SlideName = "Trường sĩ quan thông tin - Đại học thông tin liên lạc",
                     SlideContent = "Thông tin tuyển sinh đại học quân sự 2021",
                     SlideImage = "TuyenSinh2021.jpg",
                     SlideTimePost = DateTime.Parse("2021-04-04")
                 },
                  new Slide
                  {
                      SlideID = 3,
                      SlideUrl = "#",
                      SlideName = "Trường sĩ quan thông tin - Đại học thông tin liên lạc",
                      SlideContent = "Thông tin tuyển sinh đại học quân sự 2021",
                      SlideImage = "TuyenSinh2021.jpg",
                      SlideTimePost = DateTime.Parse("2021-04-04")
                  },
                   new Slide
                   {
                       SlideID = 4,
                       SlideUrl = "#",
                       SlideName = "Trường sĩ quan thông tin - Đại học thông tin liên lạc",
                       SlideContent = "Khánh thành trung tâm CNTT-NN",
                       SlideImage = "TuyenSinh2021.jpg",
                       SlideTimePost = DateTime.Parse("2021-04-04")
                   }
            );


        }
    }
}
