using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEcommerceFruit.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Hidden", "PasswordHash" },
                values: new object[] { false, "$2a$11$Tci8b3fFtncKMn9vtT0T0ehCrwjDoiHi/8GFNEdhk/CJYVcDmM9rK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Hidden", "PasswordHash" },
                values: new object[] { false, "$2a$11$tX4tp7EqYQO4oyH/1Nvzz.BY3cvwplZq8jGyKNkS9mCk63fxoOchy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$5MmRpwc.YapBlV1ijz48rumDZo3AR/YxzjK.GbQS7hupi1lCkG3P2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$OxubkCWj27AjaaIPMJveXey2bn3fDKuvHy/Y0vrNfCI2nGZJk/BsG");
        }
    }
}
