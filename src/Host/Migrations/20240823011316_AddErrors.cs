using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Host.Migrations
{
    /// <inheritdoc />
    public partial class AddErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Posts");
        }
    }
}
