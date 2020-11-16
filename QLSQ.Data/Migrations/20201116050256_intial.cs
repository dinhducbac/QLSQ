using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLSQ.Data.Migrations
{
    public partial class intial : Migration
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
                name: "QLCongTac",
                columns: table => new
                {
                    IDCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    DiaChiCT = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ThoiGianBatDauCT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCT = table.Column<int>(type: "int", nullable: false)
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
                name: "QLLuong",
                columns: table => new
                {
                    IDLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSQ = table.Column<int>(type: "int", nullable: false),
                    HeSoLuong = table.Column<float>(type: "real", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    HeSoPhuCap = table.Column<float>(type: "real", nullable: false, defaultValue: 0f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLLuong", x => x.IDLuong);
                    table.ForeignKey(
                        name: "FK_QLLuong_SiQuan_IDSQ",
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

            migrationBuilder.InsertData(
                table: "BoPhan",
                columns: new[] { "IDBP", "TenBP" },
                values: new object[,]
                {
                    { 1, "Ban giám hiệu" },
                    { 2, "Phòng" },
                    { 3, "Trợ lý" },
                    { 4, "Khoa" },
                    { 5, "Đơn vị" }
                });

            migrationBuilder.InsertData(
                table: "QuanHam",
                columns: new[] { "IDQH", "TenQH" },
                values: new object[,]
                {
                    { 12, "Đại Tướng" },
                    { 11, "Thượng Tướng" },
                    { 10, "Trung Tướng" },
                    { 9, "Thiếu Tướng" },
                    { 8, "Đại tá" },
                    { 7, "Thượng Tá" },
                    { 6, "Trung Tá" },
                    { 5, "Thiếu Tá" },
                    { 4, "Đại Úy" },
                    { 3, "Thượng Úy" },
                    { 2, "Trung Úy" },
                    { 1, "Thiếu Úy" }
                });

            migrationBuilder.InsertData(
                table: "SiQuan",
                columns: new[] { "IDSQ", "GioiTinh", "HoTen", "NgaySinh", "QueQuan", "SDT", "UserId" },
                values: new object[,]
                {
                    { 1, "F", "Lê Thị Hiền", new DateTime(1985, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0377526687", new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9") },
                    { 2, "M", "Đỗ Văn Tuấn", new DateTime(1985, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0374561237", new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208") },
                    { 3, "F", "Lê Thị Giang", new DateTime(1985, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0373568745", new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee") },
                    { 4, "M", "Nguyễn Văn Hoàn", new DateTime(1987, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0374231456", new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba") },
                    { 5, "M", "Vũ Văn Cảnh", new DateTime(1984, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghệ An", "0374123456", new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb") }
                });

            migrationBuilder.InsertData(
                table: "ChucVu",
                columns: new[] { "IDCV", "IDBP", "TenCV" },
                values: new object[,]
                {
                    { 1, 1, "Hiệu trưởng" },
                    { 21, 5, "Trung đội trưởng" },
                    { 20, 5, "Phó đại đội trưởng" },
                    { 19, 5, "Đại đội trưởng" },
                    { 17, 5, "Tiểu đoàn trưởng" },
                    { 16, 4, "Nhân viên" },
                    { 15, 4, "Giáo viên" },
                    { 14, 4, "Chủ nhiệm bộ môn" },
                    { 13, 4, "Phó chủ nhiệm khoa" },
                    { 12, 4, "Chủ nhiệm khoa" },
                    { 18, 5, "Phó tiểu đoàn trưởng" },
                    { 10, 3, "Chủ nhiệm kỹ thuật" },
                    { 9, 3, "Chủ nhiệm hậu cần" },
                    { 8, 2, "Phó ban" },
                    { 7, 2, "Trưởng ban" },
                    { 6, 2, "Phó phòng" },
                    { 5, 2, "Trưởng phòng" },
                    { 4, 1, "Phó kỹ thuật" },
                    { 3, 1, "Phó quân sự" },
                    { 2, 1, "Hiệu phó đào tạo" },
                    { 11, 3, "Chủ nhiệm chính trị" }
                });

            migrationBuilder.InsertData(
                table: "QLCongTac",
                columns: new[] { "IDCT", "DiaChiCT", "IDSQ", "ThoiGianBatDauCT", "ThoiGianCT" },
                values: new object[,]
                {
                    { 3, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 3, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 5, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 5, new DateTime(2005, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 17 },
                    { 2, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 2, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 1, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 1, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 4, "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa", 4, new DateTime(2007, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 }
                });

            migrationBuilder.InsertData(
                table: "QLDangVien",
                columns: new[] { "IDQLDV", "IDSQ", "NgayVaoDang", "NoiVaoDang" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 5, 5, new DateTime(2005, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 3, 3, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 1, 1, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" },
                    { 4, 4, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trường Sĩ quan Thông tin, Nha Trang, Khánh Hòa" }
                });

            migrationBuilder.InsertData(
                table: "QLLuong",
                columns: new[] { "IDLuong", "HeSoLuong", "IDSQ", "LuongCoBan" },
                values: new object[,]
                {
                    { 4, 6.6f, 4, 1429000m },
                    { 1, 8f, 1, 1429000m },
                    { 2, 8f, 2, 1429000m },
                    { 3, 6f, 3, 1429000m },
                    { 5, 8f, 5, 1429000m }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ChucVu_IDBP",
                table: "ChucVu",
                column: "IDBP");

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
                name: "IX_QLLuong_IDSQ",
                table: "QLLuong",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_QLNghiPhep_IDSQ",
                table: "QLNghiPhep",
                column: "IDSQ");

            migrationBuilder.CreateIndex(
                name: "IX_SiQuan_UserId",
                table: "SiQuan",
                column: "UserId",
                unique: true);
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
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "QuanHam");

            migrationBuilder.DropTable(
                name: "SiQuan");

            migrationBuilder.DropTable(
                name: "BoPhan");

            migrationBuilder.DropTable(
                name: "AppUser");
        }
    }
}
