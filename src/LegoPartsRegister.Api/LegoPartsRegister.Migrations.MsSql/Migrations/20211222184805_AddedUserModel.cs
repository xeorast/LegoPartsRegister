using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegoPartsRegister.Migrations.MsSql.Migrations
{
	public partial class AddedUserModel : Migration
	{
		protected override void Up( MigrationBuilder migrationBuilder )
		{
			_ = migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<int>( type: "int", nullable: false )
						.Annotation( "SqlServer:Identity", "1, 1" ),
					Uuid = table.Column<string>( type: "nvarchar(24)", maxLength: 24, nullable: false ),
					Username = table.Column<string>( type: "nvarchar(32)", maxLength: 32, nullable: false ),
					PasswordHash = table.Column<string>( type: "nvarchar(max)", nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_Users", x => x.Id );
				} );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Users_Username",
				table: "Users",
				column: "Username",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Users_Uuid",
				table: "Users",
				column: "Uuid",
				unique: true );
		}

		protected override void Down( MigrationBuilder migrationBuilder )
		{
			_ = migrationBuilder.DropTable(
				name: "Users" );
		}
	}
}
