using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class createInitproductGI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGIs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductGIs_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$dhmBp3YqPfIcOy7UA25ffeMPToCMP5x9Bw2TBJocfYr2FYe4iyxX.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$r1nj/CyZd/YrIcoKrembzOGICBLrDMK9Ckmb3fojc7cJy3khJAghO");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGIs_CategoryId",
                table: "ProductGIs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGIs_StoreId",
                table: "ProductGIs",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductGIs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$XjDKXfT/oXwJQeqA4.1Yve4oS.Ua6dcYUij.ZJrTV0iIjpzW/CFCu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$mkBrH/4RcH6mbbGmCBO9zuseyYORTfCECgbQ6esS7xwR53l15Yrp2");
        }
    }
}
