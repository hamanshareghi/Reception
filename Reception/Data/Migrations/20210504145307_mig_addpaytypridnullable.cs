using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig_addpaytypridnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayTypeId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PayTypeId",
                table: "Sales",
                column: "PayTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PayTypes_PayTypeId",
                table: "Sales",
                column: "PayTypeId",
                principalTable: "PayTypes",
                principalColumn: "PayTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PayTypes_PayTypeId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_PayTypeId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PayTypeId",
                table: "Sales");
        }
    }
}
