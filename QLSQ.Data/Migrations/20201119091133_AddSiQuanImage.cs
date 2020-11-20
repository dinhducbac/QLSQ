using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLSQ.Data.Migrations
{
    public partial class AddSiQuanImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    FileSize = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("37fe170e-027e-4e7f-aba5-15743063aeb2"),
                column: "ConcurrencyStamp",
                value: "9c09c061-a562-465c-88b7-758dbef80278");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"),
                column: "ConcurrencyStamp",
                value: "b1bb27e3-bd4d-4013-9134-884567469451");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de2fed7a-02ec-4ca8-8baa-223c68e2d6bb", "AQAAAAEAACcQAAAAEGbwSE0+LGUvsQXclquRn5WVi9g7QfLWNv1MsngwWg0TUqt90OG6a5g94ZxNoEQiPA==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2fa6522-bedc-45ec-9b86-3af40b71eab2", "AQAAAAEAACcQAAAAEDNbMTS2JgfzmqJgblhbL/AaTjKX6QZUDazaSye2MlGsrPKUOLTuDlXbL+11euBwAw==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51009b80-6ce8-4596-a3a7-7ca3a80f5484", "AQAAAAEAACcQAAAAEFpOYcYP27vhq4PuZaR+JMCuhQEU1sbca5d2jJyzHAjQNiiEi/cQ1Y0Pu2xak3h+lg==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71950c0e-d309-48d3-9680-dd582e6c3231", "AQAAAAEAACcQAAAAELPvg3jG8RQtb+SgBubNVvvAGR/hA6QVxmABeVqdhY4mjAF5iwYRxMDEdZitzVWQmw==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bea84dff-63d3-4b5f-a482-a114b7936bc2", "AQAAAAEAACcQAAAAEHHLqIc3hott18ODUKTeo5AzgVZ+ecBde9ZfS+E73flpV71k81Pdfi8ryBA6a+AOWw==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("ef234b11-ccc7-45d3-ba16-5ebf721ee6c8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c078af4e-4390-45c3-bd8e-ad6a00f18a52", "AQAAAAEAACcQAAAAENaAlar7Ki1EmSBrKqzgp96nCyob1Iv+QpTGlag9PsTVx+n2y+fhftiRUpb1x/SAZQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_SiQuanImage_IDSQ",
                table: "SiQuanImage",
                column: "IDSQ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiQuanImage");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("37fe170e-027e-4e7f-aba5-15743063aeb2"),
                column: "ConcurrencyStamp",
                value: "9214e5a0-e405-467e-a529-fc733f5a4f27");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"),
                column: "ConcurrencyStamp",
                value: "fd2b3bed-fc2c-467e-9d4d-c1520b5acff5");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d15995ad-8052-47c6-90a3-7ec20c45f848", "AQAAAAEAACcQAAAAEChTvPLfAlV90nL2qi9D8AkhO+LXIeA8VOKEZxymAnFV9JcgMHnYUkUly3D1tujCHg==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a223c20-8ab1-4a5a-8ea5-578204e2cfa4", "AQAAAAEAACcQAAAAEBlGIbeJs+6upU/Joy4+JVFVRBBH4OLiWVkU/QWL+PgkXaFIB3IRKdiAQSq2U++aZg==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "859c423f-e49d-431b-9f74-244f82e72ced", "AQAAAAEAACcQAAAAEOZmgAKMjxa4LUXnxDVRuXtVZ4jLNPZBugQXJZ+gbDKUZVLKYhf4ScLAIWXO/DeObw==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1047e55b-3449-4de4-bc00-3e451588f186", "AQAAAAEAACcQAAAAEGj6JYzf0YkXgmtgnReGloN1b9y0AD/4nXct0U82RGU76HWwHY8evD9whg1YPRE0PQ==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cadce2d4-d7f3-42b3-a65c-775326b0489e", "AQAAAAEAACcQAAAAELvY/qcnNF6uTyfJIQb3sPKBQYIMno+W8YPByuHh2gPWuOpSBspB5ZoEAgqDqEA/VQ==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("ef234b11-ccc7-45d3-ba16-5ebf721ee6c8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22509324-1b6f-4c74-a992-80198e20a96d", "AQAAAAEAACcQAAAAEKIds6KWyvwjvH3D5FsEG7V08UjjdXXNdiannundbYApjdwaKIWJ7f7obUWQzCZI7w==" });
        }
    }
}
