using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class createInitProductDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductGIId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductGIs_ProductGIId",
                        column: x => x.ProductGIId,
                        principalTable: "ProductGIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$8oZ2XgFT8.24qBP/Mn5IAO0d0u1qQeJx6eQ29BJflOBH67zpGGplW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$db13v5XNlVvJy1zbO7PY..yOMHZy9d9I4H/PYbbgp1Vo4tqExeIAS");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGIId",
                table: "Products",
                column: "ProductGIId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$CeFSMKFbDjHJLJ7QCrZhUOjhU1pAFS.oA5LpTi1e1.gJN.gtX0/Xa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$FldUTwSftdcAgWARx2oyC.4P7E68bdbJrJjuAn9LiYpD7U8hnSA/i");
        }
    }
}
