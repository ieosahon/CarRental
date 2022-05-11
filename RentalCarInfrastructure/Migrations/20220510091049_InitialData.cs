using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalCarInfrastructure.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Cars_carId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "carId",
                table: "Ratings",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_carId",
                table: "Ratings",
                newName: "IX_Ratings_CarId");

            migrationBuilder.RenameColumn(
                name: "SociallMedia",
                table: "Dealers",
                newName: "SocialMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Cars_CarId",
                table: "Ratings",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Cars_CarId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Ratings",
                newName: "carId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_CarId",
                table: "Ratings",
                newName: "IX_Ratings_carId");

            migrationBuilder.RenameColumn(
                name: "SocialMedia",
                table: "Dealers",
                newName: "SociallMedia");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Cars_carId",
                table: "Ratings",
                column: "carId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
