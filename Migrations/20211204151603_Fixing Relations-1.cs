using Microsoft.EntityFrameworkCore.Migrations;

namespace Snap_n_go.Migrations
{
    public partial class FixingRelations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_products_ProductId",
                table: "StockProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_stocks_StockId",
                table: "StockProducts");

            migrationBuilder.DropColumn(
                name: "ProductIdProduct",
                table: "StockProducts");

            migrationBuilder.DropColumn(
                name: "StockIdStock",
                table: "StockProducts");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "StockProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "StockProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_products_ProductId",
                table: "StockProducts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_stocks_StockId",
                table: "StockProducts",
                column: "StockId",
                principalTable: "stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_products_ProductId",
                table: "StockProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_stocks_StockId",
                table: "StockProducts");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "StockProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "StockProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductIdProduct",
                table: "StockProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockIdStock",
                table: "StockProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_products_ProductId",
                table: "StockProducts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_stocks_StockId",
                table: "StockProducts",
                column: "StockId",
                principalTable: "stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
