using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCrudDotNetSix.Migrations
{
    public partial class NewEntityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "Affiliation",
                table: "users",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmancipated",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Affiliation",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsEmancipated",
                table: "users");
        }
    }
}
