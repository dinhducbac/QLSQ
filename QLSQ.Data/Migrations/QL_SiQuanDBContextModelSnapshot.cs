﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QL_SiQuan.Data.EF;

namespace QLSQ.Data.Migrations
{
    [DbContext(typeof(QL_SiQuanDBContext))]
    partial class QL_SiQuanDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("QL_SiQuan.Data.Entities.BoPhan", b =>
                {
                    b.Property<int>("IDBP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TenBP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IDBP");

                    b.ToTable("BoPhan");

                    b.HasData(
                        new
                        {
                            IDBP = 1,
                            TenBP = "Ban giám hiệu"
                        },
                        new
                        {
                            IDBP = 2,
                            TenBP = "Phòng"
                        },
                        new
                        {
                            IDBP = 3,
                            TenBP = "Trợ lý"
                        },
                        new
                        {
                            IDBP = 4,
                            TenBP = "Khoa"
                        },
                        new
                        {
                            IDBP = 5,
                            TenBP = "Đơn vị"
                        });
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.ChucVu", b =>
                {
                    b.Property<int>("IDCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IDBP")
                        .HasColumnType("int");

                    b.Property<string>("TenCV")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDCV");

                    b.HasIndex("IDBP");

                    b.ToTable("ChucVu");

                    b.HasData(
                        new
                        {
                            IDCV = 1,
                            IDBP = 1,
                            TenCV = "Hiệu trưởng"
                        },
                        new
                        {
                            IDCV = 2,
                            IDBP = 1,
                            TenCV = "Hiệu phó đào tạo"
                        },
                        new
                        {
                            IDCV = 3,
                            IDBP = 1,
                            TenCV = "Phó quân sự"
                        },
                        new
                        {
                            IDCV = 4,
                            IDBP = 1,
                            TenCV = "Phó kỹ thuật"
                        },
                        new
                        {
                            IDCV = 5,
                            IDBP = 2,
                            TenCV = "Trưởng phòng"
                        },
                        new
                        {
                            IDCV = 6,
                            IDBP = 2,
                            TenCV = "Phó phòng"
                        },
                        new
                        {
                            IDCV = 7,
                            IDBP = 2,
                            TenCV = "Trưởng ban"
                        },
                        new
                        {
                            IDCV = 8,
                            IDBP = 2,
                            TenCV = "Phó ban"
                        },
                        new
                        {
                            IDCV = 9,
                            IDBP = 3,
                            TenCV = "Chủ nhiệm hậu cần"
                        },
                        new
                        {
                            IDCV = 10,
                            IDBP = 3,
                            TenCV = "Chủ nhiệm kỹ thuật"
                        },
                        new
                        {
                            IDCV = 11,
                            IDBP = 3,
                            TenCV = "Chủ nhiệm chính trị"
                        },
                        new
                        {
                            IDCV = 12,
                            IDBP = 4,
                            TenCV = "Chủ nhiệm khoa"
                        },
                        new
                        {
                            IDCV = 13,
                            IDBP = 4,
                            TenCV = "Phó chủ nhiệm khoa"
                        },
                        new
                        {
                            IDCV = 14,
                            IDBP = 4,
                            TenCV = "Chủ nhiệm bộ môn"
                        },
                        new
                        {
                            IDCV = 15,
                            IDBP = 4,
                            TenCV = "Giáo viên"
                        },
                        new
                        {
                            IDCV = 16,
                            IDBP = 4,
                            TenCV = "Nhân viên"
                        },
                        new
                        {
                            IDCV = 17,
                            IDBP = 5,
                            TenCV = "Tiểu đoàn trưởng"
                        },
                        new
                        {
                            IDCV = 18,
                            IDBP = 5,
                            TenCV = "Phó tiểu đoàn trưởng"
                        },
                        new
                        {
                            IDCV = 19,
                            IDBP = 5,
                            TenCV = "Đại đội trưởng"
                        },
                        new
                        {
                            IDCV = 20,
                            IDBP = 5,
                            TenCV = "Phó đại đội trưởng"
                        },
                        new
                        {
                            IDCV = 21,
                            IDBP = 5,
                            TenCV = "Trung đội trưởng"
                        });
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLChucVu", b =>
                {
                    b.Property<int>("IDQLCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IDCV")
                        .HasColumnType("int");

                    b.Property<int>("IDQH")
                        .HasColumnType("int");

                    b.Property<int>("IDSQ")
                        .HasColumnType("int");

                    b.HasKey("IDQLCV");

                    b.HasIndex("IDCV");

                    b.HasIndex("IDQH");

                    b.HasIndex("IDSQ");

                    b.ToTable("QLChucVu");

                    b.HasData(
                        new
                        {
                            IDQLCV = 1,
                            IDCV = 15,
                            IDQH = 8,
                            IDSQ = 1
                        },
                        new
                        {
                            IDQLCV = 2,
                            IDCV = 15,
                            IDQH = 8,
                            IDSQ = 2
                        },
                        new
                        {
                            IDQLCV = 3,
                            IDCV = 15,
                            IDQH = 5,
                            IDSQ = 3
                        },
                        new
                        {
                            IDQLCV = 4,
                            IDCV = 15,
                            IDQH = 6,
                            IDSQ = 4
                        },
                        new
                        {
                            IDQLCV = 5,
                            IDCV = 15,
                            IDQH = 8,
                            IDSQ = 5
                        });
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLCongTac", b =>
                {
                    b.Property<int>("IDCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaChiCT")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("IDSQ")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianBatDauCT")
                        .HasColumnType("datetime2");

                    b.Property<int>("ThoiGianCT")
                        .HasColumnType("int");

                    b.HasKey("IDCT");

                    b.HasIndex("IDSQ");

                    b.ToTable("QLCongTac");

                    b.HasData(
                        new
                        {
                            IDCT = 1,
                            DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa",
                            IDSQ = 1,
                            ThoiGianBatDauCT = new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ThoiGianCT = 15
                        },
                        new
                        {
                            IDCT = 2,
                            DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa",
                            IDSQ = 2,
                            ThoiGianBatDauCT = new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ThoiGianCT = 15
                        },
                        new
                        {
                            IDCT = 3,
                            DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa",
                            IDSQ = 3,
                            ThoiGianBatDauCT = new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ThoiGianCT = 15
                        },
                        new
                        {
                            IDCT = 4,
                            DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa",
                            IDSQ = 4,
                            ThoiGianBatDauCT = new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ThoiGianCT = 15
                        },
                        new
                        {
                            IDCT = 5,
                            DiaChiCT = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa",
                            IDSQ = 5,
                            ThoiGianBatDauCT = new DateTime(2005, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ThoiGianCT = 17
                        });
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLDangVien", b =>
                {
                    b.Property<int>("IDQLDV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IDSQ")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayVaoDang")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiVaoDang")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IDQLDV");

                    b.HasIndex("IDSQ");

                    b.ToTable("QLDangVien");

                    b.HasData(
                        new
                        {
                            IDQLDV = 1,
                            IDSQ = 1,
                            NgayVaoDang = new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                        },
                        new
                        {
                            IDQLDV = 2,
                            IDSQ = 2,
                            NgayVaoDang = new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                        },
                        new
                        {
                            IDQLDV = 3,
                            IDSQ = 3,
                            NgayVaoDang = new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                        },
                        new
                        {
                            IDQLDV = 4,
                            IDSQ = 4,
                            NgayVaoDang = new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                        },
                        new
                        {
                            IDQLDV = 5,
                            IDSQ = 5,
                            NgayVaoDang = new DateTime(2005, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiVaoDang = "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa"
                        });
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLLuong", b =>
                {
                    b.Property<int>("IDLuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("HeSoLuong")
                        .HasColumnType("real");

                    b.Property<float>("HeSoPhuCap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<int>("IDSQ")
                        .HasColumnType("int");

                    b.Property<decimal>("LuongCoBan")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("IDLuong");

                    b.HasIndex("IDSQ");

                    b.ToTable("QLLuong");

                    b.HasData(
                        new
                        {
                            IDLuong = 1,
                            HeSoLuong = 8f,
                            HeSoPhuCap = 0f,
                            IDSQ = 1,
                            LuongCoBan = 1429000m
                        },
                        new
                        {
                            IDLuong = 2,
                            HeSoLuong = 8f,
                            HeSoPhuCap = 0f,
                            IDSQ = 2,
                            LuongCoBan = 1429000m
                        },
                        new
                        {
                            IDLuong = 3,
                            HeSoLuong = 6f,
                            HeSoPhuCap = 0f,
                            IDSQ = 3,
                            LuongCoBan = 1429000m
                        },
                        new
                        {
                            IDLuong = 4,
                            HeSoLuong = 6.6f,
                            HeSoPhuCap = 0f,
                            IDSQ = 4,
                            LuongCoBan = 1429000m
                        },
                        new
                        {
                            IDLuong = 5,
                            HeSoLuong = 8f,
                            HeSoPhuCap = 0f,
                            IDSQ = 5,
                            LuongCoBan = 1429000m
                        });
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLNghiPhep", b =>
                {
                    b.Property<int>("IDNP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IDSQ")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianBDNP")
                        .HasColumnType("datetime2");

                    b.Property<int>("ThoiGianNP")
                        .HasColumnType("int");

                    b.HasKey("IDNP");

                    b.HasIndex("IDSQ");

                    b.ToTable("QLNghiPhep");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QuanHam", b =>
                {
                    b.Property<int>("IDQH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TenQH")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDQH");

                    b.ToTable("QuanHam");

                    b.HasData(
                        new
                        {
                            IDQH = 1,
                            TenQH = "Thiếu Úy"
                        },
                        new
                        {
                            IDQH = 2,
                            TenQH = "Trung Úy"
                        },
                        new
                        {
                            IDQH = 3,
                            TenQH = "Thượng Úy"
                        },
                        new
                        {
                            IDQH = 4,
                            TenQH = "Đại Úy"
                        },
                        new
                        {
                            IDQH = 5,
                            TenQH = "Thiếu Tá"
                        },
                        new
                        {
                            IDQH = 6,
                            TenQH = "Trung Tá"
                        },
                        new
                        {
                            IDQH = 7,
                            TenQH = "Thượng Tá"
                        },
                        new
                        {
                            IDQH = 8,
                            TenQH = "Đại tá"
                        },
                        new
                        {
                            IDQH = 9,
                            TenQH = "Thiếu Tướng"
                        },
                        new
                        {
                            IDQH = 10,
                            TenQH = "Trung Tướng"
                        },
                        new
                        {
                            IDQH = 11,
                            TenQH = "Thượng Tướng"
                        },
                        new
                        {
                            IDQH = 12,
                            TenQH = "Đại Tướng"
                        });
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.SiQuan", b =>
                {
                    b.Property<int>("IDSQ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasDefaultValue("M");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("QueQuan")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.Property<Guid>("UserId")
                        .IsUnicode(false)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IDSQ");

                    b.ToTable("SiQuan");

                    b.HasData(
                        new
                        {
                            IDSQ = 1,
                            GioiTinh = "F",
                            HoTen = "Lê Thị Hiền",
                            NgaySinh = new DateTime(1985, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QueQuan = "Nghệ An",
                            SDT = "0377526687",
                            UserId = new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9")
                        },
                        new
                        {
                            IDSQ = 2,
                            GioiTinh = "M",
                            HoTen = "Đỗ Văn Tuấn",
                            NgaySinh = new DateTime(1985, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QueQuan = "Nghệ An",
                            SDT = "0374561237",
                            UserId = new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208")
                        },
                        new
                        {
                            IDSQ = 3,
                            GioiTinh = "F",
                            HoTen = "Lê Thị Giang",
                            NgaySinh = new DateTime(1985, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QueQuan = "Nghệ An",
                            SDT = "0373568745",
                            UserId = new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee")
                        },
                        new
                        {
                            IDSQ = 4,
                            GioiTinh = "M",
                            HoTen = "Nguyễn Văn Hoàn",
                            NgaySinh = new DateTime(1987, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QueQuan = "Nghệ An",
                            SDT = "0374231456",
                            UserId = new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba")
                        },
                        new
                        {
                            IDSQ = 5,
                            GioiTinh = "M",
                            HoTen = "Vũ Văn Cảnh",
                            NgaySinh = new DateTime(1984, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QueQuan = "Nghệ An",
                            SDT = "0374123456",
                            UserId = new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb")
                        });
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.ChucVu", b =>
                {
                    b.HasOne("QL_SiQuan.Data.Entities.BoPhan", "BoPhan")
                        .WithMany("ChucVus")
                        .HasForeignKey("IDBP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoPhan");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLChucVu", b =>
                {
                    b.HasOne("QL_SiQuan.Data.Entities.ChucVu", "ChucVu")
                        .WithMany("QLChucVus")
                        .HasForeignKey("IDCV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QL_SiQuan.Data.Entities.QuanHam", "QuanHam")
                        .WithMany("QLChucVus")
                        .HasForeignKey("IDQH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QL_SiQuan.Data.Entities.SiQuan", "SiQuan")
                        .WithMany("QLChucVus")
                        .HasForeignKey("IDSQ")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");

                    b.Navigation("QuanHam");

                    b.Navigation("SiQuan");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLCongTac", b =>
                {
                    b.HasOne("QL_SiQuan.Data.Entities.SiQuan", "SiQuan")
                        .WithMany("QLCongTacs")
                        .HasForeignKey("IDSQ")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SiQuan");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLDangVien", b =>
                {
                    b.HasOne("QL_SiQuan.Data.Entities.SiQuan", "SiQuan")
                        .WithMany("QLDangViens")
                        .HasForeignKey("IDSQ")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SiQuan");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLLuong", b =>
                {
                    b.HasOne("QL_SiQuan.Data.Entities.SiQuan", "SiQuan")
                        .WithMany("QLLuongs")
                        .HasForeignKey("IDSQ")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SiQuan");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QLNghiPhep", b =>
                {
                    b.HasOne("QL_SiQuan.Data.Entities.SiQuan", "SiQuan")
                        .WithMany("QLNghiPheps")
                        .HasForeignKey("IDSQ")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SiQuan");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.BoPhan", b =>
                {
                    b.Navigation("ChucVus");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.ChucVu", b =>
                {
                    b.Navigation("QLChucVus");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.QuanHam", b =>
                {
                    b.Navigation("QLChucVus");
                });

            modelBuilder.Entity("QL_SiQuan.Data.Entities.SiQuan", b =>
                {
                    b.Navigation("QLChucVus");

                    b.Navigation("QLCongTacs");

                    b.Navigation("QLDangViens");

                    b.Navigation("QLLuongs");

                    b.Navigation("QLNghiPheps");
                });
#pragma warning restore 612, 618
        }
    }
}
