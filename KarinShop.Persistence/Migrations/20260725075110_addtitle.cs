using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarinShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addtitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "HomePageImages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "HomePageImages");
        }
    }
}
