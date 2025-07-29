using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcRecipeApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Recipes");
        }
    }
}
