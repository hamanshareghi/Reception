using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig_AddCurrentUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentUser",
                table: "Debtors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentUser",
                table: "Debtors");
        }
    }
}
