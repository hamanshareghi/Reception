using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig_AddRelationCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_AspNetUsers_UserId",
                table: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_Costs_UserId",
                table: "Costs");
        }
    }
}
