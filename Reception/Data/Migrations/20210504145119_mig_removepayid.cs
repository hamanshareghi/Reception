using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig_removepayid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayTypeId",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "PayTypeId1",
                table: "PayTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayTypes_PayTypeId1",
                table: "PayTypes",
                column: "PayTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PayTypes_PayTypes_PayTypeId1",
                table: "PayTypes",
                column: "PayTypeId1",
                principalTable: "PayTypes",
                principalColumn: "PayTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayTypes_PayTypes_PayTypeId1",
                table: "PayTypes");

            migrationBuilder.DropIndex(
                name: "IX_PayTypes_PayTypeId1",
                table: "PayTypes");

            migrationBuilder.DropColumn(
                name: "PayTypeId1",
                table: "PayTypes");

            migrationBuilder.AddColumn<int>(
                name: "PayTypeId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
