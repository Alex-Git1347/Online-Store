using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class UpdateTableCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bodyType",
                table: "Car",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cityCar",
                table: "Car",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "colour",
                table: "Car",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "companyID",
                table: "Car",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataPublished",
                table: "Car",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "mileageCar",
                table: "Car",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "modelCar",
                table: "Car",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typeDVS",
                table: "Car",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "volumeDVS",
                table: "Car",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "yearBorn",
                table: "Car",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_companyID",
                table: "Car",
                column: "companyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Companies_companyID",
                table: "Car",
                column: "companyID",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Companies_companyID",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_companyID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "bodyType",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "cityCar",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "colour",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "companyID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "dataPublished",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "mileageCar",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "modelCar",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "typeDVS",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "volumeDVS",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "yearBorn",
                table: "Car");
        }
    }
}
