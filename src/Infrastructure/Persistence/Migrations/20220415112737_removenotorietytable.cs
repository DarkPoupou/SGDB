using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Persistence.Migrations
{
    public partial class removenotorietytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Notorieties_NotorietyId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Notorieties");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_NotorietyId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "NotorietyId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "EndDepotId",
                table: "Plans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Notoriety",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notoriety",
                table: "Brands");

            migrationBuilder.AddColumn<int>(
                name: "NotorietyId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EndDepotId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Notorieties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coefficient = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notorieties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_NotorietyId",
                table: "Vehicles",
                column: "NotorietyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Notorieties_NotorietyId",
                table: "Vehicles",
                column: "NotorietyId",
                principalTable: "Notorieties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
