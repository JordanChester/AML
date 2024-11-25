using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AML.Server.Migrations
{
    /// <inheritdoc />
    public partial class RenamePhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Accounts",
                newName: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Accounts",
                newName: "PhoneNumber");
        }
    }
}
