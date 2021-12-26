using Microsoft.EntityFrameworkCore.Migrations;

namespace Snap_n_go.Migrations
{
    public partial class Migrationaftermovingexpirydatetostockproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expiryDate",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "imgUrl",
                table: "products",
                newName: "ImgUrl");

            migrationBuilder.RenameColumn(
                name: "barcode",
                table: "products",
                newName: "Barcode");

            migrationBuilder.AddColumn<string>(
                name: "ExpiryDate",
                table: "StockProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Barcode",
                table: "products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "StockProducts");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "products",
                newName: "imgUrl");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "products",
                newName: "barcode");

            migrationBuilder.AlterColumn<int>(
                name: "barcode",
                table: "products",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "expiryDate",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
