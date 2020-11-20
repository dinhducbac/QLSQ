using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLSQ.Data.Migrations
{
    public partial class ChangeFileImageSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "SiQuanImage",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("37fe170e-027e-4e7f-aba5-15743063aeb2"),
                column: "ConcurrencyStamp",
                value: "0dede3f7-6489-4cdc-bcd4-e19cf1a85df3");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("42ff6f47-9edd-451f-bf03-db895dfcfff9"),
                column: "ConcurrencyStamp",
                value: "42f14c76-c045-4d2b-b3c5-b967a2ad7466");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("2c31d31e-1520-48ee-9e62-2311829cf7ba"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f35032cd-2e95-42fc-b995-7973d40db770", "AQAAAAEAACcQAAAAEBdBMH6q2GKAZDw6Dw53l15PG8bT73MbwjKpQLJCOxttiIUYqzZAX+dIA/rE7ASPfg==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("41a8e023-7c08-46bb-858c-5a3b219818cb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b43b74e-6ce9-48ed-9b0d-54114bf48313", "AQAAAAEAACcQAAAAED8/2giydekdGdnL3NApkcm6T8BMPZ87HgTa8/eZtOPuulPhCfdtBceNrFvDqMKtzw==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("4c39ee3b-0277-4b32-8173-261988cce2ee"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84a53fdf-e1f6-4fa5-afcb-b4c81049d67d", "AQAAAAEAACcQAAAAEJ4oMuuLTW21soCn+uolLZnbtpau95NeqOCbGgTU10iCXRy4qNpdmLJlA4TbeP4gPA==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("78b61ff5-714b-4c2e-9566-6df4396b1208"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7746f526-e8e4-4ac1-a611-380082a0159b", "AQAAAAEAACcQAAAAEIfFjZOS5BpGTLpFM1FW2uEa6vUVZqPtZk3N+TbcxUn/ryBnWpQY3VB2dKmNy2VfLA==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("9ece85c8-a453-4ffc-b5ab-bf7d4c3365f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8652cd47-697b-41b5-8c17-0d03080b77d3", "AQAAAAEAACcQAAAAEPa5mEsyYPVcpL4VZCHtEuUB1Gy5SDwLxvdGCuBVxsgluA1qYqDhAlQklrtUvFz3og==" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("ef234b11-ccc7-45d3-ba16-5ebf721ee6c8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b90f027e-561b-4e7c-8528-9667129a8236", "AQAAAAEAACcQAAAAEBpXq0cdEsBAljReAOSkPED+HI46WV0txVjkPEogDUzGOhNfZZKB/+Kxm7jYsTob0A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "SiQuanImage",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
        }
    }
}
