using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class cannullshippingType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShippingType",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShippingType",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4348), new DateTime(2024, 10, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4475), new DateTime(2024, 10, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4477) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4481), new DateTime(2024, 10, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4482) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4486), new DateTime(2024, 10, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4487) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4490), new DateTime(2024, 10, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4491) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4502), new DateTime(2024, 10, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4503) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 23, 29, 3, 988, DateTimeKind.Local).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$mPlJGhpGSEciwOpFdJ6L3Osta7TbNdI8W0th/fiwI2s/5msZT0MFa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$fdLcw8XfoXC0jM.CKSs8IuWePLKyesYYzMtmhPjzR6JDcufdRzdXW");
        }
    }
}
