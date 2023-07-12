using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCrudDotNetSix.Migrations
{
    public partial class UpdateNewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Affiliation",
                table: "users",
                newName: "affiliation");

            migrationBuilder.RenameColumn(
                name: "IsEmancipated",
                table: "users",
                newName: "is_emancipated");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "affiliation",
                table: "users",
                newName: "Affiliation");

            migrationBuilder.RenameColumn(
                name: "is_emancipated",
                table: "users",
                newName: "IsEmancipated");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
