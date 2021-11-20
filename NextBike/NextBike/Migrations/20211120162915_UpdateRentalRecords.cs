using Microsoft.EntityFrameworkCore.Migrations;

namespace NextBike.Migrations
{
    public partial class UpdateRentalRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalRecords_Bikes_BikeId",
                table: "RentalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalRecords_Clients_ClientId",
                table: "RentalRecords");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RentalRecords");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "RentalRecords",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BikeId",
                table: "RentalRecords",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRecords_Bikes_BikeId",
                table: "RentalRecords",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRecords_Clients_ClientId",
                table: "RentalRecords",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalRecords_Bikes_BikeId",
                table: "RentalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalRecords_Clients_ClientId",
                table: "RentalRecords");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "RentalRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BikeId",
                table: "RentalRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RentalRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRecords_Bikes_BikeId",
                table: "RentalRecords",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRecords_Clients_ClientId",
                table: "RentalRecords",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
