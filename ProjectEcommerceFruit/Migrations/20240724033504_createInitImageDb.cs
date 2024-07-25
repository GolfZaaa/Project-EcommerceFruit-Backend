using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class createInitImageDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGIId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_ProductGIs_ProductGIId",
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
                value: "$2a$11$CeFSMKFbDjHJLJ7QCrZhUOjhU1pAFS.oA5LpTi1e1.gJN.gtX0/Xa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$FldUTwSftdcAgWARx2oyC.4P7E68bdbJrJjuAn9LiYpD7U8hnSA/i");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductGIId",
                table: "Images",
                column: "ProductGIId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

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
        }
    }
}
