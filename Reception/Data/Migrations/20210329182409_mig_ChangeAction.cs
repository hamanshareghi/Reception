using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig_ChangeAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    DutyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceptionId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ShippingId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.DutyId);
                    table.ForeignKey(
                        name: "FK_Duties_Receptions_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Receptions",
                        principalColumn: "ReceptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duties_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duties_Shippings_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shippings",
                        principalColumn: "ShippingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duties_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duties_ReceptionId",
                table: "Duties",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_ServiceId",
                table: "Duties",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_ShippingId",
                table: "Duties",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_StatusId",
                table: "Duties",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duties");

            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    DutyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ReceptionId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ShippingId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UpDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.DutyId);
                    table.ForeignKey(
                        name: "FK_Action_Receptions_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Receptions",
                        principalColumn: "ReceptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Action_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Action_Shippings_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shippings",
                        principalColumn: "ShippingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Action_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Action_ReceptionId",
                table: "Action",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_ServiceId",
                table: "Action",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_ShippingId",
                table: "Action",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_StatusId",
                table: "Action",
                column: "StatusId");
        }
    }
}
