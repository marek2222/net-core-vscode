using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_filmy.Migrations
{
    public partial class FilmOcena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ocena",
                table: "Film",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Ocena",
                table: "Film");
        }
    }
}
