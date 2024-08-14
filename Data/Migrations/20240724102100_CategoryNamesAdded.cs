using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryNamesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageNames",
                table: "TShirts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "ImageNames",
                table: "Sweetshirts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "ImageNames",
                table: "Socks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageNames",
                table: "Shorts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "ImageNames",
                table: "Shirts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "ImageNames",
                table: "Mayos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "ImageNames",
                table: "Kazaks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageNames",
                table: "TShirts");

            migrationBuilder.DropColumn(
                name: "ImageNames",
                table: "Sweetshirts");

            migrationBuilder.DropColumn(
                name: "ImageNames",
                table: "Socks");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "ImageNames",
                table: "Shorts");

            migrationBuilder.DropColumn(
                name: "ImageNames",
                table: "Shirts");

            migrationBuilder.DropColumn(
                name: "ImageNames",
                table: "Mayos");

            migrationBuilder.DropColumn(
                name: "ImageNames",
                table: "Kazaks");
        }
    }
}
