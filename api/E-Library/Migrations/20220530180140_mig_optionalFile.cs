using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELibrary.Migrations
{
    public partial class mig_optionalFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "BookFiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CoverType",
                table: "BookFiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                column: "ConcurrencyStamp",
                value: "90ef0333-fedc-4fa5-ad6c-d0532f4bc7a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "ConcurrencyStamp",
                value: "9ce00cbb-3f2c-483b-9a72-d46ecf895a32");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69cd1e37-fb54-411f-9012-4c3b7d85580f", "AQAAAAEAACcQAAAAEGGtWnPB7tDEUH7IBvWU3Fy0FB4YCJHL2rOei2c994BiNYyn9XRf6LHC0hA/wVkGNg==", "1b1232c9-fce0-4c6a-9a9c-ee1bfbd3a242" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13dc5d2b-2e12-4240-8e3f-8d51af82cc17", "AQAAAAEAACcQAAAAEAYlSEMSxVUgWl/ieT969E4mbdn4C7gAKfrOSiDVYVb1C+n8R/iEtv7iDV78/n16FA==", "1f9c5d22-b239-4aab-9e66-352fe990d25d" });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 845, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 845, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 845, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "BookFiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 845, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 844, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 845, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 845, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 845, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 845, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 5, 30, 21, 1, 39, 845, DateTimeKind.Local).AddTicks(179));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "BookFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoverType",
                table: "BookFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                column: "ConcurrencyStamp",
                value: "6064b58a-502b-4bb0-ba51-363dc1732db0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "ConcurrencyStamp",
                value: "b1c9fee5-2a58-416d-a23f-f1224191a487");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2003a72a-1cf9-4d6a-9527-7f8174719950", "AQAAAAEAACcQAAAAEK7JAetDpgZCQXROMGH+jb+Yoo4Pj4wvFqqXprOCW6g37BFDY+onPGkso4qpsTn+9w==", "a2d80fa4-b083-48c3-bf7e-c7d5b60f507b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a744cdf-d5c9-46dd-b3ea-e085559f80d7", "AQAAAAEAACcQAAAAEDVc7SMnBh/dhjBovUGU+KqmTRntiImIyoRCXEROjONY+1NYUo1KzNg5iSAMKtXPPw==", "d01c1948-8624-47c5-b4e4-51cfbfede10c" });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "BookFiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 5, 7, 22, 43, 5, 313, DateTimeKind.Local).AddTicks(5378));
        }
    }
}
