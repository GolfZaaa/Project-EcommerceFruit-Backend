using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class updateshippingCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShippingCost",
                table: "SystemSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5447), new DateTime(2024, 10, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5448) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5464), new DateTime(2024, 10, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5465) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5470), new DateTime(2024, 10, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5471) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5474), new DateTime(2024, 10, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5475) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5479), new DateTime(2024, 10, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5488), new DateTime(2024, 10, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5489) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 21, 13, 59, 20, 392, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$buTzMXFlQJnwqbUFf3lKa.jCPiX.3mehb8xJpMgyNfXckUUTsseWa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$pT55ErunDuMY5nmvem1VWulFdh9qqbZ1yCBO2QBF8QEKki4B1UFuS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingCost",
                table: "SystemSettings");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9880), new DateTime(2024, 10, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9881) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9889), new DateTime(2024, 10, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9892), new DateTime(2024, 10, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9893) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9895), new DateTime(2024, 10, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9899) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9901), new DateTime(2024, 10, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9902) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9904), new DateTime(2024, 10, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9905) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 21, 10, 39, 10, 23, DateTimeKind.Local).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$rsfz/dCcYn0fu3hJ9367g.Jj/fbOxGIyzUcq.n4zjYXe3ajhqEvUy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$PPRoRNhxci.vHV1F4GhncuxkAL8ZRKacM4dwJIQpb/x6PCxH4MeTa");
        }
    }
}
