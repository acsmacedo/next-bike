using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NextBike.Migrations
{
    public partial class RentalRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: true),
                    BikeId = table.Column<int>(nullable: true),
                    RentalDate = table.Column<DateTime>(nullable: false),
                    DeliveredDate = table.Column<DateTime>(nullable: true),
                    ExpectedDeliveredDate = table.Column<DateTime>(nullable: false),
                    PricePerDay = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalRecords_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalRecords_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalRecords_BikeId",
                table: "RentalRecords",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRecords_ClientId",
                table: "RentalRecords",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalRecords");
        }
    }
}
