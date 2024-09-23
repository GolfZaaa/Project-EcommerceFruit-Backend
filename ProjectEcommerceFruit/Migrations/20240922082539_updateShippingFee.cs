using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class updateShippingFee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShippingFee",
                table: "Shippings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(285), new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(287) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(297), new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(298) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(335), new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(336) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(340), new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(341) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(344), new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(345) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(355), new DateTime(2024, 10, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(356) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 22, 15, 25, 35, 425, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$S5zjXW8fJH5iTtQZIlYWbORViCuNOG/jNIRW0CCoWsNOmqIZ2iMha");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$F6pbv5jZlA2z5IrEzfO5BO50X75kdD/ttwuyUR6CteLLqW7k5vvfS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingFee",
                table: "Shippings");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4646), new DateTime(2024, 10, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4664), new DateTime(2024, 10, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4666) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4673), new DateTime(2024, 10, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4674) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4680), new DateTime(2024, 10, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4682) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4687), new DateTime(2024, 10, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4689) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4703), new DateTime(2024, 10, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4705) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 22, 2, 17, 25, 292, DateTimeKind.Local).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$rJWgVvDzFcAc2P/zq2lh4.xzL4Lsw37l16CiHUpkhUZjDDyZSYOwK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$TSySNXGlkeLDVbFBgRppsOeCXVxWJyQCMRGyvmc0PWNbAjkjLjmg6");
        }
    }
}
