using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Car_Rental_System.Migrations
{
    /// <inheritdoc />
    public partial class ModelCustomerRentalHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerRentalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Rented = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Due = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Returned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRentalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRentalHistory_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRentalHistory_CustomerId",
                table: "CustomerRentalHistory",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRentalHistory");
        }
    }
}
