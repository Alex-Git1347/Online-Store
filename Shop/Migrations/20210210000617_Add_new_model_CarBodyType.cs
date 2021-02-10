using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class Add_new_model_CarBodyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarBodyId",
                table: "Car",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarBodyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBodyType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarBodyId",
                table: "Car",
                column: "CarBodyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_CarBodyType_CarBodyId",
                table: "Car",
                column: "CarBodyId",
                principalTable: "CarBodyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CarBodyType_CarBodyId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "CarBodyType");

            migrationBuilder.DropIndex(
                name: "IX_Car_CarBodyId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CarBodyId",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "bodyType",
                table: "Car",
                nullable: true);
        }
    }
}
