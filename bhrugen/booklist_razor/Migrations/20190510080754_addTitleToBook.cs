using Microsoft.EntityFrameworkCore.Migrations;

namespace booklist_razor.Migrations
{
    public partial class addTitleToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Books",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "id");
        }
    }
}
