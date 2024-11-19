using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AML.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdNamesForEF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MediaStockId",
                table: "MediaStock",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Media",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Branches",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MediaStock",
                newName: "MediaStockId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Media",
                newName: "MediaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Branches",
                newName: "BranchId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "AccountId");
        }
    }
}
