using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class updateimageinsystemsetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7412), new DateTime(2024, 10, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7420), new DateTime(2024, 10, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7423), new DateTime(2024, 10, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7424) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7426), new DateTime(2024, 10, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7428), new DateTime(2024, 10, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7435), new DateTime(2024, 10, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7436) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 18, 0, 0, 25, 283, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$nHQq.4GqcQUK3Q9xxqd50O94JAVXjswcdvmTiTzanL.0yqDfLpgJi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$brEurHtwCnA31g32aARcXOqEvFI1HKAJwb7atdbpIbWGlGo/KxLuy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "SystemSettings");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2016), new DateTime(2024, 10, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2017) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2025), new DateTime(2024, 10, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2028), new DateTime(2024, 10, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2028) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2030), new DateTime(2024, 10, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2031) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2032), new DateTime(2024, 10, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2041), new DateTime(2024, 10, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(2042) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 12, 14, 45, 33, 847, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$FQnLDLduCkocqZzYPcO8S.7jyqXY/LvdugmEjLV1/yBZMhweCLyS2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$E3zx5hw/TBbAL9ScVs/.YOe2hn/IXdpBC2Judu/CNL.DyeaNBw2Ma");
        }
    }
}
