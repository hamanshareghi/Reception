using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_AspNetUsers_UserId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Products_ProductId",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Sales");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_UserId",
                table: "Sales",
                newName: "IX_Sales_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_ProductId",
                table: "Sales",
                newName: "IX_Sales_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "Sale");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_UserId",
                table: "Sale",
                newName: "IX_Sale_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_ProductId",
                table: "Sale",
                newName: "IX_Sale_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_AspNetUsers_UserId",
                table: "Sale",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Products_ProductId",
                table: "Sale",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
