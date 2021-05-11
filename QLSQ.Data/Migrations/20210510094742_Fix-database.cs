using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLSQ.Data.Migrations
{
    public partial class Fixdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoPhan",
                columns: table => new
                {
                    IDBP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoPhan", x => x.IDBP);
                });

            migrationBuilder.CreateTable(
                name: "LuongCoBan",
                columns: table => new
                {
                    IDLuongCB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuongCB = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuongCoBan", x => x.IDLuongCB);
                });

            migrationBuilder.CreateTable(
                name: "NewCatetory",
                columns: table => new
                {
                    NewCatetoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewCatetoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewCatetory", x => x.NewCatetoryID);
                });

            migrationBuilder.CreateTable(
                name: "QuanHam",
                columns: table => new
                {
                    IDQH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHam", x => x.IDQH);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    SlideID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlideUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlideName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlideContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlideImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlideTimePost = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.SlideID);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SiQuan",
                columns: table => new
                {
                    IDSQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "M"),
                    QueQuan = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SDT = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiQuan", x => x.IDSQ);
                    table.ForeignKey(
                        name: "FK_SiQuan_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    IDCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDBP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.IDCV);
                    table.ForeignKey(
                        name: "FK_ChucVu_BoPhan_IDBP",
                        column: x => x.IDBP,
                        principalTable: "BoPhan",
                        principalColumn: "IDBP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "New",
                columns: table => new
                {
                    NewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewDatePost = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 10, 16, 47, 41, 806, DateTimeKind.Local).AddTicks(5614)),
                    NewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NewCatetoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_New", x => x.NewID);
                    table.ForeignKey(
                        name: "FK_New_NewCatetory_NewCatetoryID",
                        column: x => x.NewCatetoryID,
                        principalTable: "NewCatetory",
                        principalColumn: "NewCatetoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeSoLuongTheoQuanHam",
                columns: table => new
                {
                    IDHeSoLuongQH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDQH = table.Column<int>(type: "int", nullable: false),
                    TenHeSoLuongQH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeSoLuong = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeSoLuongTheoQuanHam", x => x.IDHeSoLuongQH);
                    table.ForeignKey(
                        name: "FK_HeSoLuongTheoQuanHam_QuanHam_IDQH",
                        column: x => x.IDQH,
                        principalTable: "QuanHam",
                        principalColumn: "IDQH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QLCongTac",
                columns: table => new
                {
                    IDCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    DiaChiCT = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ThoiGianBatDauCT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThucCT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CongTacState = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLCongTac", x => x.IDCT);
                    table.ForeignKey(
                        name: "FK_QLCongTac_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QLDangVien",
                columns: table => new
                {
                    IDQLDV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    NgayVaoDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiVaoDang = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLDangVien", x => x.IDQLDV);
                    table.ForeignKey(
                        name: "FK_QLDangVien_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QLGiaDinhSQ",
                columns: table => new
                {
                    IDQLGDSQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    QuanHe = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLGiaDinhSQ", x => x.IDQLGDSQ);
                    table.ForeignKey(
                        name: "FK_QLGiaDinhSQ_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QLKhenThuongKiLuat",
                columns: table => new
                {
                    IDQLKTKL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    NgayThucHien = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoaiKTKL = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HinhThuc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DonViCap = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLKhenThuongKiLuat", x => x.IDQLKTKL);
                    table.ForeignKey(
                        name: "FK_QLKhenThuongKiLuat_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QLNghiPhep",
                columns: table => new
                {
                    IDNP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBDNP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKTNP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NghiPhepState = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLNghiPhep", x => x.IDNP);
                    table.ForeignKey(
                        name: "FK_QLNghiPhep_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QLQuaTrinhDaoTao",
                columns: table => new
                {
                    IDQLQTDT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    TenTruong = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NganhHoc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ThoiGianBDDT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKTDT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhThucDT = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    VanBang = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLQuaTrinhDaoTao", x => x.IDQLQTDT);
                    table.ForeignKey(
                        name: "FK_QLQuaTrinhDaoTao_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiQuanImage",
                columns: table => new
                {
                    IDImage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiQuanImage", x => x.IDImage);
                    table.ForeignKey(
                        name: "FK_SiQuanImage_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeSoPhuCapTheoChucVu",
                columns: table => new
                {
                    IDHeSoPhuCapCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCV = table.Column<int>(type: "int", nullable: false),
                    HeSoPhuCap = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeSoPhuCapTheoChucVu", x => x.IDHeSoPhuCapCV);
                    table.ForeignKey(
                        name: "FK_HeSoPhuCapTheoChucVu_ChucVu_IDCV",
                        column: x => x.IDCV,
                        principalTable: "ChucVu",
                        principalColumn: "IDCV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QLChucVu",
                columns: table => new
                {
                    IDQLCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    IDCV = table.Column<int>(type: "int", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLChucVu", x => x.IDQLCV);
                    table.ForeignKey(
                        name: "FK_QLChucVu_ChucVu_IDCV",
                        column: x => x.IDCV,
                        principalTable: "ChucVu",
                        principalColumn: "IDCV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QLChucVu_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewImage",
                columns: table => new
                {
                    NewImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewID = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 10, 16, 47, 41, 812, DateTimeKind.Local).AddTicks(7426)),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewImage", x => x.NewImageID);
                    table.ForeignKey(
                        name: "FK_NewImage_New_NewID",
                        column: x => x.NewID,
                        principalTable: "New",
                        principalColumn: "NewID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QLQuanHam",
                columns: table => new
                {
                    IDQLQH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    IDQH = table.Column<int>(type: "int", nullable: false),
                    IDHeSoLuongTheoQH = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLQuanHam", x => x.IDQLQH);
                    table.ForeignKey(
                        name: "FK_QLQuanHam_HeSoLuongTheoQuanHam_IDHeSoLuongTheoQH",
                        column: x => x.IDHeSoLuongTheoQH,
                        principalTable: "HeSoLuongTheoQuanHam",
                        principalColumn: "IDHeSoLuongQH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QLQuanHam_QuanHam_IDQH",
                        column: x => x.IDQH,
                        principalTable: "QuanHam",
                        principalColumn: "IDQH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QLQuanHam_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QLLuong",
                columns: table => new
                {
                    IDLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    IDQLQH = table.Column<int>(type: "int", nullable: false),
                    IDQLCV = table.Column<int>(type: "int", nullable: false),
                    IDLuongCB = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLLuong", x => x.IDLuong);
                    table.ForeignKey(
                        name: "FK_QLLuong_LuongCoBan_IDLuongCB",
                        column: x => x.IDLuongCB,
                        principalTable: "LuongCoBan",
                        principalColumn: "IDLuongCB",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QLLuong_QLChucVu_IDQLCV",
                        column: x => x.IDQLCV,
                        principalTable: "QLChucVu",
                        principalColumn: "IDQLCV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QLLuong_QLQuanHam_IDQLQH",
                        column: x => x.IDQLQH,
                        principalTable: "QLQuanHam",
                        principalColumn: "IDQLQH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QLLuong_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Mota", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("37fe170e-027e-4e7f-aba5-15743063aeb2"), "b77da22c-c857-421b-b63a-299a8a070d1d", "Administrator Role", "admin", "admin" },
                    { new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"), "e2d46dca-7b99-4c96-9423-f41593205f30", "Si Quan Role", "Si Quan", "Si Quan" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("ef234b11-ccc7-45d3-ba16-5ebf721ee6c8"), 0, "fdc9dbe2-b024-4ad5-adc9-1029d38490d6", "dinhducbac1998@gmail.com", true, false, null, "dinhducbac1998@gmail.com", "admin", "AQAAAAEAACcQAAAAEKnRDwAjRkizAM/ZEa0LkVZkoYNcn3hkBONjVahmUKTjUsljZor7UCrCxUr8n0N4Vw==", null, false, "", false, "admin" },
                    { new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb"), 0, "f811ca96-2332-4f32-b052-04e7175310ab", "vuvancanh@gmail.com", true, false, null, "vuvancanh@gmail.com", "vuvancanh", "AQAAAAEAACcQAAAAEMcdEWQSu7uNwYgbRvjA67q32pc+8hP9Pps7W4ZQdsCz8+gTogrkG7edCkkzR/VfxQ==", null, false, "", false, "vuvancanh" },
                    { new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba"), 0, "257ca53d-1ab7-4913-90a9-bb1f0f2872cd", "nguyenvanhoan@gmail.com", true, false, null, "nguyenvanhoan@gmail.com", "nguyenvanhoan", "AQAAAAEAACcQAAAAEOF8xfw1yynHBSrOWe/EOtOUNb19nG1q50UjjLdiphOacZvZHcOdZ7LyGx9wtmGBng==", null, false, "", false, "nguyenvanhoan" },
                    { new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee"), 0, "891e0599-cac9-4ff5-8aaf-4a7dc035ff8b", "lethigiang@gmail.com", true, false, null, "lethigiang@gmail.com", "lethigiang", "AQAAAAEAACcQAAAAEK/mcAda06frKBup8J2DQVFrLclgTqzdUoVGmfcHB1Uwhipnl68cXV/1dtIXFrDrKg==", null, false, "", false, "lethigiang" },
                    { new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208"), 0, "0148017f-6b24-4d8b-a310-676bd7880065", "dovantuan@gmail.com", true, false, null, "dovantuan@gmail.com", "dovantuan", "AQAAAAEAACcQAAAAEPqOpzxpMuQutqCRm69AIl/lvuwFFYmE/+0MtBiP3IahHRHgbzOI9TM8iHDnvr9XQw==", null, false, "", false, "dovantuan" },
                    { new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9"), 0, "f6a1b36e-42c6-443d-8206-8617649fcc95", "lethihien@gmail.com", true, false, null, "lethihien@gmail.com", "lethihien", "AQAAAAEAACcQAAAAEAYLzJXGJtp9ihJKs2zmfpTfiARvjDmte52ot3dsWbCpgB5/nwLReQLz/FRSrEcmLQ==", null, false, "", false, "lethihien" }
                });

            migrationBuilder.InsertData(
                table: "BoPhan",
                columns: new[] { "IDBP", "TenBP" },
                values: new object[,]
                {
                    { 2, "Phòng" },
                    { 1, "Ban giám hiệu" },
                    { 3, "Trợ lý" },
                    { 5, "Đơn vị" },
                    { 4, "Khoa" }
                });

            migrationBuilder.InsertData(
                table: "LuongCoBan",
                columns: new[] { "IDLuongCB", "LuongCB" },
                values: new object[] { 1, 1429000m });

            migrationBuilder.InsertData(
                table: "NewCatetory",
                columns: new[] { "NewCatetoryID", "NewCatetoryName" },
                values: new object[,]
                {
                    { 2, "Giáo dục QPAN" },
                    { 3, "Khoa học và công nghệ" },
                    { 4, "Tuyển sinh" },
                    { 5, "Hội thảo - Hội nghị" },
                    { 1, "Đào tạo" }
                });

            migrationBuilder.InsertData(
                table: "QuanHam",
                columns: new[] { "IDQH", "TenQH" },
                values: new object[,]
                {
                    { 10, "Trung Tướng" },
                    { 9, "Thiếu Tướng" },
                    { 11, "Thượng Tướng" },
                    { 12, "Đại Tướng" },
                    { 1, "Thiếu Úy" },
                    { 2, "Trung Úy" },
                    { 3, "Thượng Úy" },
                    { 4, "Đại Úy" },
                    { 5, "Thiếu Tá" },
                    { 6, "Trung Tá" },
                    { 7, "Thượng Tá" },
                    { 8, "Đại tá" }
                });

            migrationBuilder.InsertData(
                table: "Slide",
                columns: new[] { "SlideID", "SlideContent", "SlideImage", "SlideName", "SlideTimePost", "SlideUrl" },
                values: new object[,]
                {
                    { 1, "Thông tin tuyển sinh đại học quân sự 2021", "TuyenSinh2021.jpg", "Trường sĩ quan thông tin - Đại học thông tin liên lạc", new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "#" },
                    { 2, "Thông tin tuyển sinh đại học quân sự 2021", "TuyenSinh2021.jpg", "Trường sĩ quan thông tin - Đại học thông tin liên lạc", new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "#" },
                    { 4, "Khánh thành trung tâm CNTT-NN", "TuyenSinh2021.jpg", "Trường sĩ quan thông tin - Đại học thông tin liên lạc", new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "#" },
                    { 3, "Thông tin tuyển sinh đại học quân sự 2021", "TuyenSinh2021.jpg", "Trường sĩ quan thông tin - Đại học thông tin liên lạc", new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "#" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"), new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb") },
                    { new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"), new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba") },
                    { new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"), new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee") },
                    { new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"), new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208") },
                    { new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"), new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9") },
                    { new Guid("37fe170e-027e-4e7f-aba5-15743063aeb2"), new Guid("ef234b11-ccc7-45d3-ba16-5ebf721ee6c8") }
                });

            migrationBuilder.InsertData(
                table: "ChucVu",
                columns: new[] { "IDCV", "IDBP", "TenCV" },
                values: new object[,]
                {
                    { 17, 5, "Tiểu đoàn trưởng" },
                    { 21, 5, "Trung đội trưởng" },
                    { 20, 5, "Phó đại đội trưởng" },
                    { 19, 5, "Đại đội trưởng" },
                    { 18, 5, "Phó tiểu đoàn trưởng" },
                    { 16, 4, "Nhân viên" },
                    { 15, 4, "Giáo viên" },
                    { 14, 4, "Chủ nhiệm bộ môn" },
                    { 13, 4, "Phó chủ nhiệm khoa" },
                    { 12, 4, "Chủ nhiệm khoa" },
                    { 10, 3, "Chủ nhiệm kỹ thuật" },
                    { 9, 3, "Chủ nhiệm hậu cần" },
                    { 11, 3, "Chủ nhiệm chính trị" },
                    { 7, 2, "Trưởng ban" },
                    { 6, 2, "Phó phòng" },
                    { 5, 2, "Trưởng phòng" },
                    { 4, 1, "Phó kỹ thuật" },
                    { 3, 1, "Phó quân sự" },
                    { 2, 1, "Hiệu phó đào tạo" },
                    { 1, 1, "Hiệu trưởng" },
                    { 8, 2, "Phó ban" }
                });

            migrationBuilder.InsertData(
                table: "HeSoLuongTheoQuanHam",
                columns: new[] { "IDHeSoLuongQH", "HeSoLuong", "IDQH", "TenHeSoLuongQH" },
                values: new object[,]
                {
                    { 3, 5f, 3, "Thượng Úy" },
                    { 4, 5.4f, 4, "Đại Úy" },
                    { 5, 6f, 5, "Thiếu Tá" },
                    { 10, 9.2f, 10, "Trung Tướng" },
                    { 6, 6.6f, 6, "Trung Tá" },
                    { 8, 8f, 8, "Đại Tá" },
                    { 7, 7.3f, 7, "Thượng Tá" },
                    { 2, 4.6f, 2, "Trung Úy" },
                    { 9, 8.6f, 9, "Thiếu Tướng" },
                    { 1, 4.2f, 1, "Thiếu Úy" },
                    { 12, 10.4f, 12, "Đại Tướng" },
                    { 11, 9.8f, 11, "Thượng Tướng" }
                });

            migrationBuilder.InsertData(
                table: "New",
                columns: new[] { "NewID", "NewCatetoryID", "NewContent", "NewCount", "NewDatePost", "NewName" },
                values: new object[,]
                {
                    { 5, 3, "Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.", 1, new DateTime(2021, 3, 4, 10, 46, 0, 0, DateTimeKind.Unspecified), "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”" },
                    { 4, 3, "Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.", 1, new DateTime(2021, 3, 4, 10, 46, 0, 0, DateTimeKind.Unspecified), "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”" },
                    { 3, 3, "Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.", 1, new DateTime(2021, 3, 4, 10, 46, 0, 0, DateTimeKind.Unspecified), "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”" },
                    { 2, 3, "Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.", 1, new DateTime(2021, 3, 4, 10, 46, 0, 0, DateTimeKind.Unspecified), "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”" },
                    { 1, 3, "Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.", 1, new DateTime(2021, 3, 4, 10, 46, 0, 0, DateTimeKind.Unspecified), "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”" },
                    { 6, 3, "Sáng 25/3/2021, tại giảng đường chuyên dùng A202, Khoa Công nghệ thông tin – Tác chiến không gian mạng tổ chức buổi báo cáo đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”. Đây là sản phẩm được nghiên cứu, xây dựng bởi nhóm tác giả bao gồm: Đại tá, ThS Nguyễn Thanh Hải, Chủ nhiệm khoa; Thiếu tá, ThS Nguyễn Văn Hoàn, giảng viên bộ môn Mạng máy tính; Đại uý, KS Hoàng Văn Long, giảng viên bộ môn Tác chiến không gian mạng. Buổi báo cáo là bước chuẩn bị quan trọng trước khi thực hiện báo cáo thông qua đề tài ở cấp Nhà trường. Tại buổi báo cáo, nhóm tác giả đã trình bày tóm tắt nội dung đề tài; nêu lên tính cấp thiết, mục tiêu, nhiệm vụ; phương pháp nghiên cứu, thực hiện cũng như những dự kiến bổ sung, phát triển tiếp theo của đề tài. Trong phần đóng góp ý kiến, các giảng viên đánh giá cao chất lượng, tính thiết thực của đề tài cũng như sự đầu tư thời gian, công sức của nhóm tác giả; bên cạnh đó, góp ý chỉnh sửa, bổ sung thêm một số nội dung để đề tài sát hợp hơn với nhiệm vụ đào tạo sĩ quan CH-TM Tác chiến không gian mạng. Buổi báo cáo đã phát huy được trí tuệ và kinh nghiệm tập thể, các ý kiến đóng góp đều tỉ mỉ và có tính xây dựng, góp phần hoàn thiện đề tài. Sau khi lắng nghe các ý kiến đóng góp, nhóm tác giả sẽ có đánh giá khách quan, toàn diện về những ưu điểm, kết quả đã đạt được; đồng thời, nhận ra các hạn chế, thiếu sót của đề tài; từ đó có hướng điều chỉnh, bổ sung nội dung để hoàn thiện đề tài, thực hiện phản biện chính thức trước Hội đồng khoa học Nhà trường theo đúng tiến độ quy định.", 1, new DateTime(2021, 3, 4, 10, 46, 0, 0, DateTimeKind.Unspecified), "Khoa Công nghệ thông tin – Tác chiến không gian mạng tiến hành thông qua đề tài: “Xây dựng kịch bản an toàn thông tin trên thiết bị tường lửa Fortigate”" }
                });

            migrationBuilder.InsertData(
                table: "SiQuan",
                columns: new[] { "IDSQ", "GioiTinh", "HoTen", "NgaySinh", "QueQuan", "SDT", "UserId" },
                values: new object[,]
                {
                    { 5, "M", "Vũ Văn Cảnh", new DateTime(1984, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0374123456", new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb") },
                    { 4, "M", "Nguyễn Văn Hoàn", new DateTime(1987, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0374231456", new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba") },
                    { 3, "F", "Lê Thị Giang", new DateTime(1985, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0373568745", new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee") }
                });

            migrationBuilder.InsertData(
                table: "SiQuan",
                columns: new[] { "IDSQ", "GioiTinh", "HoTen", "NgaySinh", "QueQuan", "SDT", "UserId" },
                values: new object[] { 2, "M", "Đỗ Văn Tuấn", new DateTime(1985, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0374561237", new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208") });

            migrationBuilder.InsertData(
                table: "SiQuan",
                columns: new[] { "IDSQ", "GioiTinh", "HoTen", "NgaySinh", "QueQuan", "SDT", "UserId" },
                values: new object[] { 1, "F", "Lê Thị Hiền", new DateTime(1985, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0377526687", new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9") });

            migrationBuilder.InsertData(
                table: "HeSoPhuCapTheoChucVu",
                columns: new[] { "IDHeSoPhuCapCV", "HeSoPhuCap", "IDCV" },
                values: new object[] { 1, 0.25f, 15 });

            migrationBuilder.InsertData(
                table: "QLChucVu",
                columns: new[] { "IDQLCV", "IDCV", "IDSQ", "NgayNhan" },
                values: new object[,]
                {
                    { 5, 15, 5, new DateTime(2006, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 15, 4, new DateTime(2008, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 15, 3, new DateTime(2008, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 15, 2, new DateTime(2008, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 15, 1, new DateTime(2008, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "QLCongTac",
                columns: new[] { "IDCT", "CongTacState", "DiaChiCT", "IDSQ", "ThoiGianBatDauCT", "ThoiGianKetThucCT" },
                values: new object[,]
                {
                    { 1, 1, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 1, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 2, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 3, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 4, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 5, new DateTime(2005, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "QLDangVien",
                columns: new[] { "IDQLDV", "IDSQ", "NgayVaoDang", "NoiVaoDang" },
                values: new object[,]
                {
                    { 5, 5, new DateTime(2005, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 3, 3, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 2, 2, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 1, 1, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 4, 4, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" }
                });

            migrationBuilder.InsertData(
                table: "QLGiaDinhSQ",
                columns: new[] { "IDQLGDSQ", "GhiChu", "HoTen", "IDSQ", "NgaySinh", "QuanHe" },
                values: new object[] { 1, "Nghề nghiệp: Test", "Test", 1, new DateTime(1967, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chồng" });

            migrationBuilder.InsertData(
                table: "QLKhenThuongKiLuat",
                columns: new[] { "IDQLKTKL", "DonViCap", "HinhThuc", "IDSQ", "LoaiKTKL", "NgayThucHien", "NoiDung" },
                values: new object[] { 1, "Trường sĩ quan thông tin", "Huân chương", 5, 1, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huân chương lao động hạng 3" });

            migrationBuilder.InsertData(
                table: "QLNghiPhep",
                columns: new[] { "IDNP", "IDSQ", "ThoiGianBDNP", "ThoiGianKTNP" },
                values: new object[] { 1, 1, new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "QLQuaTrinhDaoTao",
                columns: new[] { "IDQLQTDT", "HinhThucDT", "IDSQ", "NganhHoc", "TenTruong", "ThoiGianBDDT", "ThoiGianKTDT", "VanBang" },
                values: new object[] { 1, "Chính quy", 1, "Công nghệ thông tin", "Trường Sĩ quan Thông tin", new DateTime(2004, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cử nhân" });

            migrationBuilder.InsertData(
                table: "QLQuanHam",
                columns: new[] { "IDQLQH", "IDHeSoLuongTheoQH", "IDQH", "IDSQ" },
                values: new object[,]
                {
                    { 4, 6, 6, 4 },
                    { 1, 6, 6, 1 },
                    { 2, 6, 6, 2 },
                    { 3, 6, 6, 3 },
                    { 5, 6, 6, 5 }
                });

            migrationBuilder.InsertData(
                table: "QLLuong",
                columns: new[] { "IDLuong", "IDLuongCB", "IDQLCV", "IDQLQH", "IDSQ" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 1, 2, 2, 2 },
                    { 3, 1, 3, 3, 3 },
                    { 4, 1, 4, 4, 4 },
                    { 5, 1, 5, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChucVu_IDBP",
                table: "ChucVu",
                column: "IDBP");

            migrationBuilder.CreateIndex(
                name: "IX_HeSoLuongTheoQuanHam_IDQH",
                table: "HeSoLuongTheoQuanHam",
                column: "IDQH");

            migrationBuilder.CreateIndex(
                name: "IX_HeSoPhuCapTheoChucVu_IDCV",
                table: "HeSoPhuCapTheoChucVu",
                column: "IDCV");

            migrationBuilder.CreateIndex(
                name: "IX_New_NewCatetoryID",
                table: "New",
                column: "NewCatetoryID");

            migrationBuilder.CreateIndex(
                name: "IX_NewImage_NewID",
                table: "NewImage",
                column: "NewID");

            migrationBuilder.CreateIndex(
                name: "IX_QLChucVu_IDCV",
                table: "QLChucVu",
                column: "IDCV");

            migrationBuilder.CreateIndex(
                name: "IX_QLChucVu_IDSQ",
                table: "QLChucVu",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_QLCongTac_IDSQ",
                table: "QLCongTac",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_QLDangVien_IDSQ",
                table: "QLDangVien",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_QLGiaDinhSQ_IDSQ",
                table: "QLGiaDinhSQ",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_QLKhenThuongKiLuat_IDSQ",
                table: "QLKhenThuongKiLuat",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_QLLuong_IDLuongCB",
                table: "QLLuong",
                column: "IDLuongCB");

            migrationBuilder.CreateIndex(
                name: "IX_QLLuong_IDQLCV",
                table: "QLLuong",
                column: "IDQLCV");

            migrationBuilder.CreateIndex(
                name: "IX_QLLuong_IDQLQH",
                table: "QLLuong",
                column: "IDQLQH");

            migrationBuilder.CreateIndex(
                name: "IX_QLLuong_IDSQ",
                table: "QLLuong",
                column: "IDSQ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QLNghiPhep_IDSQ",
                table: "QLNghiPhep",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_QLQuanHam_IDHeSoLuongTheoQH",
                table: "QLQuanHam",
                column: "IDHeSoLuongTheoQH");

            migrationBuilder.CreateIndex(
                name: "IX_QLQuanHam_IDQH",
                table: "QLQuanHam",
                column: "IDQH");

            migrationBuilder.CreateIndex(
                name: "IX_QLQuanHam_IDSQ",
                table: "QLQuanHam",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_QLQuaTrinhDaoTao_IDSQ",
                table: "QLQuaTrinhDaoTao",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_SiQuan_UserId",
                table: "SiQuan",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiQuanImage_IDSQ",
                table: "SiQuanImage",
                column: "IDSQ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRole");

            migrationBuilder.DropTable(
                name: "HeSoPhuCapTheoChucVu");

            migrationBuilder.DropTable(
                name: "NewImage");

            migrationBuilder.DropTable(
                name: "QLCongTac");

            migrationBuilder.DropTable(
                name: "QLDangVien");

            migrationBuilder.DropTable(
                name: "QLGiaDinhSQ");

            migrationBuilder.DropTable(
                name: "QLKhenThuongKiLuat");

            migrationBuilder.DropTable(
                name: "QLLuong");

            migrationBuilder.DropTable(
                name: "QLNghiPhep");

            migrationBuilder.DropTable(
                name: "QLQuaTrinhDaoTao");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "SiQuanImage");

            migrationBuilder.DropTable(
                name: "Slide");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "New");

            migrationBuilder.DropTable(
                name: "LuongCoBan");

            migrationBuilder.DropTable(
                name: "QLChucVu");

            migrationBuilder.DropTable(
                name: "QLQuanHam");

            migrationBuilder.DropTable(
                name: "NewCatetory");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "HeSoLuongTheoQuanHam");

            migrationBuilder.DropTable(
                name: "SiQuan");

            migrationBuilder.DropTable(
                name: "BoPhan");

            migrationBuilder.DropTable(
                name: "QuanHam");

            migrationBuilder.DropTable(
                name: "AppUser");
        }
    }
}
