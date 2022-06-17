using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class deleteIMGURLcar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropOffDate",
                table: "RentedCars");

            migrationBuilder.DropColumn(
                name: "PickUpDate",
                table: "RentedCars");

            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImgURL2",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DropOffDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgURL2",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
