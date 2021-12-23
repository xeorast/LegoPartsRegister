using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegoPartsRegister.Migrations.MsSql.Migrations
{
	public partial class AddedPartModel : Migration
	{
		protected override void Up( MigrationBuilder migrationBuilder )
		{
			_ = migrationBuilder.CreateTable(
				name: "Parts",
				columns: table => new
				{
					Id = table.Column<int>( type: "int", nullable: false )
						.Annotation( "SqlServer:Identity", "1, 1" ),
					No = table.Column<string>( type: "nvarchar(32)", maxLength: 32, nullable: false ),
					Name = table.Column<string>( type: "nvarchar(512)", maxLength: 512, nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_Parts", x => x.Id );
				} );
		}

		protected override void Down( MigrationBuilder migrationBuilder )
		{
			_ = migrationBuilder.DropTable(
				name: "Parts" );
		}
	}
}
