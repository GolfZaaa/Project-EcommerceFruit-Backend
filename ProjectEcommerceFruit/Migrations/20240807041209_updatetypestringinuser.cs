using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class updatetypestringinuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PhoneNumber" },
                values: new object[] { "$2a$11$jPE2bi9hEqg8BmniNaN.cu9rxKu2yZPGve6y0AClvJ7D2AvjkqK4K", "0123456789" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PhoneNumber" },
                values: new object[] { "$2a$11$WQi131enZUmf5fNd1tHcNe0279CwgHSc8i/aSwDSBwvrKrNa0poX6", "0987654321" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PhoneNumber" },
                values: new object[] { "$2a$11$aBpjKhFkWGoXJj5UJxP6FewUqUrClZPBH0MuKMkhieqTeAqJLM03O", 123456789 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PhoneNumber" },
                values: new object[] { "$2a$11$hsiwuofCDA0IBeUlBHpj8evcrittSuhMOeIxoHQR7GXswJEhk0e0u", 987654321 });
        }
    }
}
