using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Persistence.Migrations
{
    public partial class PlanDepot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_RoleId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EndDepotId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartDepotId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_EndDepotId",
                table: "Plans",
                column: "EndDepotId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_StartDepotId",
                table: "Plans",
                column: "StartDepotId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Depots_EndDepotId",
                table: "Plans",
                column: "EndDepotId",
                principalTable: "Depots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Depots_StartDepotId",
                table: "Plans",
                column: "StartDepotId",
                principalTable: "Depots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Depots_EndDepotId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Depots_StartDepotId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_EndDepotId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_StartDepotId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RoleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EndDepotId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "StartDepotId",
                table: "Plans");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId",
                unique: true);
        }
    }
}
