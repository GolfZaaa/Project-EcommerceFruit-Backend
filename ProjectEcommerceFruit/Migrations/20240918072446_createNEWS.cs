using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class createNEWS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NEWSs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hidden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEWSs", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NEWSs");

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
    }
}
