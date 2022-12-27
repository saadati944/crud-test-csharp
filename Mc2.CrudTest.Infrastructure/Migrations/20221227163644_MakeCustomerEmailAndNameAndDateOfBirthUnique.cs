using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mc2.CrudTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeCustomerEmailAndNameAndDateOfBirthUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email_Address",
                table: "Customers",
                column: "Email_Address",
                unique: true,
                filter: "[Email_Address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Firstname_Lastname_DateOfBirth",
                table: "Customers",
                columns: new[] { "Firstname", "Lastname", "DateOfBirth" },
                unique: true,
                filter: "[Firstname] IS NOT NULL AND [Lastname] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Email_Address",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Firstname_Lastname_DateOfBirth",
                table: "Customers");
        }
    }
}
