using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changeCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_AspNetUsers_UserId",
                table: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_Costs_UserId",
                table: "Costs");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Costs",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Costs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.CreateIndex(
                name: "IX_Costs_UserId",
                table: "Costs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_AspNetUsers_UserId",
                table: "Costs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
