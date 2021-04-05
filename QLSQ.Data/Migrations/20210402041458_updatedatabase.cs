using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLSQ.Data.Migrations
{
    public partial class updatedatabase : Migration
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
                name: "HeSoLuongTheoQuanHam",
                columns: table => new
                {
                    IDHeSoLuongQH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDQH = table.Column<int>(type: "int", nullable: false),
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
                    ThoiGianKetThucCT = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "QLNghiPhep",
                columns: table => new
                {
                    IDNP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBDNP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianNP = table.Column<int>(type: "int", nullable: false)
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
                    IDQH = table.Column<int>(type: "int", nullable: false),
                    IDCV = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_QLChucVu_QuanHam_IDQH",
                        column: x => x.IDQH,
                        principalTable: "QuanHam",
                        principalColumn: "IDQH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QLChucVu_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QLLuong",
                columns: table => new
                {
                    IDLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    IDHeSoLuongQH = table.Column<int>(type: "int", nullable: false),
                    IDLuongCB = table.Column<int>(type: "int", nullable: false),
                    IDHeSoPhuCapCV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLLuong", x => x.IDLuong);
                    table.ForeignKey(
                        name: "FK_QLLuong_HeSoLuongTheoQuanHam_IDHeSoLuongQH",
                        column: x => x.IDHeSoLuongQH,
                        principalTable: "HeSoLuongTheoQuanHam",
                        principalColumn: "IDHeSoLuongQH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QLLuong_HeSoPhuCapTheoChucVu_IDHeSoPhuCapCV",
                        column: x => x.IDHeSoPhuCapCV,
                        principalTable: "HeSoPhuCapTheoChucVu",
                        principalColumn: "IDHeSoPhuCapCV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QLLuong_LuongCoBan_IDLuongCB",
                        column: x => x.IDLuongCB,
                        principalTable: "LuongCoBan",
                        principalColumn: "IDLuongCB",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QLLuong_SiQuan_IDSQ",
                        column: x => x.IDSQ,
                        principalTable: "SiQuan",
                        principalColumn: "IDSQ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Mota", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("37fe170e-027e-4e7f-aba5-15743063aeb2"), "8c875327-79c9-4be5-8ffe-a945574bcc6f", "Administrator Role", "admin", "admin" },
                    { new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"), "4ceefbd4-c1bc-4d7b-af70-7f30339d685a", "Si Quan Role", "Si Quan", "Si Quan" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208"), 0, "d81045d1-6008-4719-9d63-da4c2dbb052a", "dovantuan@gmail.com", true, false, null, "dovantuan@gmail.com", "dovantuan", "AQAAAAEAACcQAAAAEMmLpZWrYwQ4ik233Ie6ukTIzb0vmv3Q6gLxWBDfXbjXQn/lzm5jpBJfKIqx/mEJqQ==", null, false, "", false, "dovantuan" },
                    { new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb"), 0, "b78cd81d-5018-41f6-bd9a-c61d3cb3583b", "vuvancanh@gmail.com", true, false, null, "vuvancanh@gmail.com", "vuvancanh", "AQAAAAEAACcQAAAAEPhTBZ8Iqd52SNS7Fz6OeL1J7faB0xkXD/nLIhgAh5wS6guHhshCmW79RZdBqalkMA==", null, false, "", false, "vuvancanh" },
                    { new Guid("ef234b11-ccc7-45d3-ba16-5ebf721ee6c8"), 0, "2d8a025d-1210-427a-b451-99ea411b7fa7", "dinhducbac1998@gmail.com", true, false, null, "dinhducbac1998@gmail.com", "admin", "AQAAAAEAACcQAAAAEGMEHTdj0qYPAmPn47M4upkfgYLCFa7usxpd2kpATT/xm7KQDkU7psRu2l3nhEg0cQ==", null, false, "", false, "admin" },
                    { new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9"), 0, "16e42bc8-ed04-4404-90c5-86715103afab", "lethihien@gmail.com", true, false, null, "lethihien@gmail.com", "lethihien", "AQAAAAEAACcQAAAAEMUIcNxPy3iyc0f5X63RJLzHI59iK9UQB2PTqDPdcz33HtPhxbvmWWUA+U/pT167Bg==", null, false, "", false, "lethihien" },
                    { new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba"), 0, "6b2129a9-8e9f-492a-8a8c-f289a94876e1", "nguyenvanhoan@gmail.com", true, false, null, "nguyenvanhoan@gmail.com", "nguyenvanhoan", "AQAAAAEAACcQAAAAEInH0QthzrkNI/w3U6fp4O/qVzZRgOKTZFCvN3GS+Erxilx9RQHpGHDINBvHL/tFkg==", null, false, "", false, "nguyenvanhoan" },
                    { new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee"), 0, "ab0e32ca-e5c7-46e3-b65a-730df989f0b4", "lethigiang@gmail.com", true, false, null, "lethigiang@gmail.com", "lethigiang", "AQAAAAEAACcQAAAAEDyiNNfgA8QHRpYRcPPqFJXlWo6I+n+B8GcqkM1MFSQRM+eZOIwnXtSwVMUAkheD/Q==", null, false, "", false, "lethigiang" }
                });

            migrationBuilder.InsertData(
                table: "BoPhan",
                columns: new[] { "IDBP", "TenBP" },
                values: new object[,]
                {
                    { 5, "Đơn vị" },
                    { 4, "Khoa" },
                    { 3, "Trợ lý" },
                    { 1, "Ban giám hiệu" },
                    { 2, "Phòng" }
                });

            migrationBuilder.InsertData(
                table: "LuongCoBan",
                columns: new[] { "IDLuongCB", "LuongCB" },
                values: new object[] { 1, 1429000m });

            migrationBuilder.InsertData(
                table: "QuanHam",
                columns: new[] { "IDQH", "TenQH" },
                values: new object[,]
                {
                    { 6, "Trung Tá" },
                    { 7, "Thượng Tá" },
                    { 5, "Thiếu Tá" },
                    { 8, "Đại tá" },
                    { 9, "Thiếu Tướng" },
                    { 10, "Trung Tướng" },
                    { 4, "Đại Úy" },
                    { 3, "Thượng Úy" },
                    { 12, "Đại Tướng" },
                    { 1, "Thiếu Úy" },
                    { 11, "Thượng Tướng" },
                    { 2, "Trung Úy" }
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
                    { 14, 4, "Chủ nhiệm bộ môn" },
                    { 21, 5, "Trung đội trưởng" },
                    { 20, 5, "Phó đại đội trưởng" },
                    { 19, 5, "Đại đội trưởng" },
                    { 18, 5, "Phó tiểu đoàn trưởng" },
                    { 17, 5, "Tiểu đoàn trưởng" },
                    { 16, 4, "Nhân viên" },
                    { 15, 4, "Giáo viên" },
                    { 13, 4, "Phó chủ nhiệm khoa" },
                    { 12, 4, "Chủ nhiệm khoa" },
                    { 11, 3, "Chủ nhiệm chính trị" },
                    { 10, 3, "Chủ nhiệm kỹ thuật" },
                    { 9, 3, "Chủ nhiệm hậu cần" },
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
                columns: new[] { "IDHeSoLuongQH", "HeSoLuong", "IDQH" },
                values: new object[,]
                {
                    { 5, 6f, 5 },
                    { 6, 6.6f, 6 },
                    { 7, 7.3f, 7 },
                    { 8, 8f, 8 },
                    { 9, 8.6f, 9 },
                    { 10, 9.2f, 10 },
                    { 4, 5.4f, 4 },
                    { 12, 10.4f, 12 },
                    { 2, 4.6f, 2 },
                    { 1, 4.2f, 1 },
                    { 11, 9.8f, 11 },
                    { 3, 5f, 3 }
                });

            migrationBuilder.InsertData(
                table: "SiQuan",
                columns: new[] { "IDSQ", "GioiTinh", "HoTen", "NgaySinh", "QueQuan", "SDT", "UserId" },
                values: new object[,]
                {
                    { 5, "M", "Vũ Văn Cảnh", new DateTime(1984, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0374123456", new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb") },
                    { 4, "M", "Nguyễn Văn Hoàn", new DateTime(1987, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0374231456", new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba") },
                    { 3, "F", "Lê Thị Giang", new DateTime(1985, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0373568745", new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee") },
                    { 2, "M", "Đỗ Văn Tuấn", new DateTime(1985, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0374561237", new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208") },
                    { 1, "F", "Lê Thị Hiền", new DateTime(1985, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0377526687", new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9") }
                });

            migrationBuilder.InsertData(
                table: "HeSoPhuCapTheoChucVu",
                columns: new[] { "IDHeSoPhuCapCV", "HeSoPhuCap", "IDCV" },
                values: new object[] { 1, 0.25f, 15 });

            migrationBuilder.InsertData(
                table: "QLChucVu",
                columns: new[] { "IDQLCV", "IDCV", "IDQH", "IDSQ" },
                values: new object[,]
                {
                    { 1, 15, 8, 1 },
                    { 2, 15, 8, 2 },
                    { 3, 15, 5, 3 },
                    { 4, 15, 6, 4 },
                    { 5, 15, 8, 5 }
                });

            migrationBuilder.InsertData(
                table: "QLCongTac",
                columns: new[] { "IDCT", "DiaChiCT", "IDSQ", "ThoiGianBatDauCT", "ThoiGianKetThucCT" },
                values: new object[,]
                {
                    { 1, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 1, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 2, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 3, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 4, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 5, new DateTime(2005, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "QLDangVien",
                columns: new[] { "IDQLDV", "IDSQ", "NgayVaoDang", "NoiVaoDang" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 2, 2, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 3, 3, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 4, 4, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 5, 5, new DateTime(2005, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" }
                });

            migrationBuilder.InsertData(
                table: "QLLuong",
                columns: new[] { "IDLuong", "IDHeSoLuongQH", "IDHeSoPhuCapCV", "IDLuongCB", "IDSQ" },
                values: new object[,]
                {
                    { 1, 8, 1, 1, 1 },
                    { 2, 8, 1, 1, 2 },
                    { 3, 5, 1, 1, 3 },
                    { 4, 6, 1, 1, 4 },
                    { 5, 8, 1, 1, 5 }
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
                name: "IX_QLChucVu_IDCV",
                table: "QLChucVu",
                column: "IDCV");

            migrationBuilder.CreateIndex(
                name: "IX_QLChucVu_IDQH",
                table: "QLChucVu",
                column: "IDQH");

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
                name: "IX_QLLuong_IDHeSoLuongQH",
                table: "QLLuong",
                column: "IDHeSoLuongQH");

            migrationBuilder.CreateIndex(
                name: "IX_QLLuong_IDHeSoPhuCapCV",
                table: "QLLuong",
                column: "IDHeSoPhuCapCV");

            migrationBuilder.CreateIndex(
                name: "IX_QLLuong_IDLuongCB",
                table: "QLLuong",
                column: "IDLuongCB");

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
                name: "QLChucVu");

            migrationBuilder.DropTable(
                name: "QLCongTac");

            migrationBuilder.DropTable(
                name: "QLDangVien");

            migrationBuilder.DropTable(
                name: "QLLuong");

            migrationBuilder.DropTable(
                name: "QLNghiPhep");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "SiQuanImage");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "HeSoLuongTheoQuanHam");

            migrationBuilder.DropTable(
                name: "HeSoPhuCapTheoChucVu");

            migrationBuilder.DropTable(
                name: "LuongCoBan");

            migrationBuilder.DropTable(
                name: "SiQuan");

            migrationBuilder.DropTable(
                name: "QuanHam");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "BoPhan");
        }
    }
}
