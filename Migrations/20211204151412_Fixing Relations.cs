using Microsoft.EntityFrameworkCore.Migrations;

namespace Snap_n_go.Migrations
{
    public partial class FixingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_histories_products_ScannedObjectId",
                table: "histories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_histories_ScannedObjectId",
                table: "histories");

            migrationBuilder.DropColumn(
                name: "CategoryIdCategory",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ScannedObjectId",
                table: "histories");

            migrationBuilder.RenameColumn(
                name: "ProductIdProduct",
                table: "histories",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_histories_ProductId",
                table: "histories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_histories_products_ProductId",
                table: "histories",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_histories_products_ProductId",
                table: "histories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_histories_ProductId",
                table: "histories");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "histories",
                newName: "ProductIdProduct");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryIdCategory",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScannedObjectId",
                table: "histories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_histories_ScannedObjectId",
                table: "histories",
                column: "ScannedObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_histories_products_ScannedObjectId",
                table: "histories",
                column: "ScannedObjectId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
