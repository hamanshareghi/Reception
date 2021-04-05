using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class change3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerKind",
                table: "AspNetUsers",
                newName: "UserKind");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Costs",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserKind",
                table: "AspNetUsers",
                newName: "CustomerKind");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Costs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
