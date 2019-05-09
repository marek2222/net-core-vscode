using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace booklist_razor.Migrations {
	public partial class addBookToDB : Migration {
		protected override void Up (MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable (
				name: "Books",
				columns : table => new {
					id = table.Column<int> (nullable: false)
						.Annotation ("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
						Tytul = table.Column<string> (nullable: true),
						Autor = table.Column<string> (nullable: true),
						ISBN = table.Column<string> (nullable: true),
						Dostepnosc = table.Column<int> (nullable: false),
						Cena = table.Column<double> (nullable: false)
				},
				constraints : table => {
					table.PrimaryKey ("PK_Books", x => x.id);
				});
		}

		protected override void Down (MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable (
				name: "Books");
		}
	}
}