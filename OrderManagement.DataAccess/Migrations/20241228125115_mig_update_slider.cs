﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_slider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description1",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Description2",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Description3",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Title1",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "Title3",
                table: "Sliders",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "Sliders",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Sliders",
                newName: "Title3");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Sliders",
                newName: "Title2");

            migrationBuilder.AddColumn<string>(
                name: "Description1",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title1",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
