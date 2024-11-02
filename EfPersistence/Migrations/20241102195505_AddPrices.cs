using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnytourApi.EfPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "RoomTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "DietTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DietTypes");
        }
    }
}
