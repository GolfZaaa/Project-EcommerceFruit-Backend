using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class updateconfirmReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmReceipt",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmReceipt",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4421), new DateTime(2024, 10, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4424) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4440), new DateTime(2024, 10, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4441) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4445), new DateTime(2024, 10, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4446) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4450), new DateTime(2024, 10, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4451) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4454), new DateTime(2024, 10, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4455) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4465), new DateTime(2024, 10, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4466) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 20, 17, 43, 9, 470, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$mK7gZ6EQtFv4CZmlr9J2G.4yQ8toRl3LklAHhOZFIeByiBCLDNb4y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$Ct2NAY35hpOqNiVfhhO8JOYMDWx9btXI4BylFBPRydZCW2nIWY1OK");
        }
    }
}
