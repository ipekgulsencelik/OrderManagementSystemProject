using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_slider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShown",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShown",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Sliders");
        }
    }
}
