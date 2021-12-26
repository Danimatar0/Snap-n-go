using Microsoft.EntityFrameworkCore.Migrations;

namespace Snap_n_go.Migrations
{
    public partial class MigrationafteraddingbarodeandexpiryDatetoProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "barcode",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "expiryDate",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "barcode",
                table: "products");

            migrationBuilder.DropColumn(
                name: "expiryDate",
                table: "products");
        }
    }
}
