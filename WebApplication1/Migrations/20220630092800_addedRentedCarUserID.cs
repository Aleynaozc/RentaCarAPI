using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addedRentedCarUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedCars_Users_UserId",
                table: "RentedCars");

            migrationBuilder.DropIndex(
                name: "IX_RentedCars_UserId",
                table: "RentedCars");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RentedCars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RentedCars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_UserId",
                table: "RentedCars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentedCars_Users_UserId",
                table: "RentedCars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
