using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class createInitDriverandShipping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shippings_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingFee = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShippingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverHistories_Shippings_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shippings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DriverHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DriverHistories_ShippingId",
                table: "DriverHistories",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverHistories_UserId",
                table: "DriverHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_OrderId",
                table: "Shippings",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverHistories");

            migrationBuilder.DropTable(
                name: "Shippings");

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
    }
}
