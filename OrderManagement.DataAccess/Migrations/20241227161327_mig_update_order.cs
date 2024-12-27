using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "OrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderDetails");
        }
    }
}
