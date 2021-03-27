using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig_ChangeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Status_CustomerKindStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerKindStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProductGroups");

            migrationBuilder.DropColumn(
                name: "CustomerKindStatusId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerKind",
                table: "AspNetUsers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerKind",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ProductGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerKindStatusId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerKindStatusId",
                table: "AspNetUsers",
                column: "CustomerKindStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Status_CustomerKindStatusId",
                table: "AspNetUsers",
                column: "CustomerKindStatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
