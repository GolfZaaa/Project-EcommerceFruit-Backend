using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class createhiddenproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire", "Hidden" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(892), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(896), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire", "Hidden" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(917), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(919), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire", "Hidden" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(924), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(925), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire", "Hidden" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(930), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(940), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire", "Hidden" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(944), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(945), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire", "Hidden" },
                values: new object[] { new DateTime(2024, 9, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(949), new DateTime(2024, 10, 19, 15, 31, 57, 290, DateTimeKind.Local).AddTicks(951), false });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5477), new DateTime(2024, 10, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5478) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5486), new DateTime(2024, 10, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5487) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5493), new DateTime(2024, 10, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5494) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5667), new DateTime(2024, 10, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5669) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5672), new DateTime(2024, 10, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5673) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5681), new DateTime(2024, 10, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5682) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 18, 14, 24, 42, 850, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$foiMOfATzj0wYZtJ40FBeu5zVQ34p5hmhHipx/.MdlswAscrUg6QC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$PGb9yNPd5bUMB5MAVAuqCOtcwJTz0QW.v10lN9H6X60bcbRXeuBGC");
        }
    }
}
