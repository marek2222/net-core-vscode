﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace booklist.Migrations {
	public partial class UpdateNameProperty : Migration {
		protected override void Up (MigrationBuilder migrationBuilder) {
			migrationBuilder.AlterColumn<string> (
				name: "Name",
				table: "Books",
				nullable : false,
				oldClrType : typeof (string),
				oldNullable : true);
		}

		protected override void Down (MigrationBuilder migrationBuilder) {
			migrationBuilder.AlterColumn<string> (
				name: "Name",
				table: "Books",
				nullable : true,
				oldClrType : typeof (string));
		}
	}
}