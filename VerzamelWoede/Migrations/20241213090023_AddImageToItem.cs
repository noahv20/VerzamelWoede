using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerzamelWoede.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Items");
        }
    }
}
