using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class removessslideShow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlideShows_SystemSettings_SystemSettingId",
                table: "SlideShows");

            migrationBuilder.DropIndex(
                name: "IX_SlideShows_SystemSettingId",
                table: "SlideShows");

            migrationBuilder.DropColumn(
                name: "SystemSettingId",
                table: "SlideShows");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemSettingId",
                table: "SlideShows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(892), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(917), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(919) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(924), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(925) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(930), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(944), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(945) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(949), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(951) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$3YYRjoplxR4oAHCGKrYxV.m8L8c6/rvjPpeIE5beJxposnCtdI/B6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$DXo3c.iCg4VZ05G/DG0k0OZjLrPccOhSpL0NeRVxLYqt6ZMQTkakG");

            migrationBuilder.CreateIndex(
                name: "IX_SlideShows_SystemSettingId",
                table: "SlideShows",
                column: "SystemSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlideShows_SystemSettings_SystemSettingId",
                table: "SlideShows",
                column: "SystemSettingId",
                principalTable: "SystemSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
