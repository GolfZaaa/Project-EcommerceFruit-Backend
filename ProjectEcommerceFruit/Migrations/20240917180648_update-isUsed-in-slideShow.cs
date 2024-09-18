using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class updateisUsedinslideShow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "SlideShows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "SlideShows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6312), new DateTime(2024, 10, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6313) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6323), new DateTime(2024, 10, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6323) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6326), new DateTime(2024, 10, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6326) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6328), new DateTime(2024, 10, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6329) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6331), new DateTime(2024, 10, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6332) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Expire" },
                values: new object[] { new DateTime(2024, 9, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6344), new DateTime(2024, 10, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6344) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 18, 1, 6, 47, 744, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$sqXVAvQsnA/gSUv4VXP4F.w2PHMTpcu7cF8AcXqp3k98mnAvx81gq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$wK8h2sq4HYy5/.TpWMU89.ON0TPYufTfcj0cYTTlIKdUsAfBjEeNy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "SlideShows");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "SlideShows");

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
    }
}
