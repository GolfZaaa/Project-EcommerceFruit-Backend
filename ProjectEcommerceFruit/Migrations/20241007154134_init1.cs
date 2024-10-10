using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9850), new DateTime(2024, 11, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9853) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9869), new DateTime(2024, 11, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9870) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9874), new DateTime(2024, 11, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9875) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9879), new DateTime(2024, 11, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 11, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9891) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9895), new DateTime(2024, 11, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 7, 22, 41, 31, 685, DateTimeKind.Local).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$afsf.WQsLpoGpoKsUCN6zez8BfcLIr66zHPy7pEAAtAl61u2oj8LO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$fETKVQBvuDaMbpXB92O2P.k7nKjYtAyq9HJQXPio.18jmhmJYUL8y");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4591), new DateTime(2024, 11, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4593) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4601), new DateTime(2024, 11, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4602) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4604), new DateTime(2024, 11, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4605) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4607), new DateTime(2024, 11, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4610), new DateTime(2024, 11, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4610) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4693), new DateTime(2024, 11, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 1, 12, 18, 52, 845, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$dAYoTHJi7AdhLiS13yLIre5PHRMKMlQbpnYeawoKw9lnFXEREmtZ6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$JD6MOk37ZSssFzzVdilKM.JhdmKdwe3l16JoZzgHq4kgKlSpqqfEy");
        }
    }
}
