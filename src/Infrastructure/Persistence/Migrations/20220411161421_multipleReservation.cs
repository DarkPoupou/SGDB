using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Persistence.Migrations
{
    public partial class multipleReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_VehicleId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "KilometerTraveled",
                table: "Vehicles");

            migrationBuilder.AddColumn<double>(
                name: "Kilometers",
                table: "Reservations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VehicleId",
                table: "Reservations",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_VehicleId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "Reservations");

            migrationBuilder.AddColumn<double>(
                name: "KilometerTraveled",
                table: "Vehicles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VehicleId",
                table: "Reservations",
                column: "VehicleId",
                unique: true);
        }
    }
}
