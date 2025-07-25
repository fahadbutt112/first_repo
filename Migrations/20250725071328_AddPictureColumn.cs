using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcRecipeApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPictureColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Recipes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Recipes");
        }
    }
}
