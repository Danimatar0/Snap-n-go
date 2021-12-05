using Microsoft.EntityFrameworkCore.Migrations;

namespace Snap_n_go.Migrations
{
    public partial class UserStockMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "stocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_stocks_UserId",
                table: "stocks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_users_UserId",
                table: "stocks",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_users_UserId",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_stocks_UserId",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "stocks");
        }
    }
}
