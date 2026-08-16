using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarinShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_imagelocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "HomePageImages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "HomePageImages");
        }
    }
}
