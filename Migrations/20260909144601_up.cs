using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Car_Rental_System.Migrations
{
    /// <inheritdoc />
    public partial class up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Email",
                table: "Customer");

            migrationBuilder.AddCheckConstraint(
                name: "C_check",
                table: "Customer",
                sql: "Email = 'N/A' OR(Email LIKE '%@%' AND Email LIKE '%.%')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "C_check",
                table: "Customer");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Email",
                table: "Customer",
                sql: "Email LIKE '%@%' AND Email LIKE '%.%'");
        }
    }
}
