using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegoPartsRegister.Migrations.MsSql.Migrations
{
	public partial class AddedElementModel : Migration
	{
		protected override void Up( MigrationBuilder migrationBuilder )
		{
			_ = migrationBuilder.CreateTable(
				name: "Colors",
				columns: table => new
				{
					Id = table.Column<int>( type: "int", nullable: false )
						.Annotation( "SqlServer:Identity", "1, 1" ),
					Name = table.Column<string>( type: "nvarchar(450)", nullable: false ),
					HexValue = table.Column<string>( type: "nvarchar(450)", nullable: false ),
					IsTrans = table.Column<bool>( type: "bit", nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_Colors", x => x.Id );
				} );

			_ = migrationBuilder.CreateTable(
				name: "Elements",
				columns: table => new
				{
					Id = table.Column<int>( type: "int", nullable: false )
						.Annotation( "SqlServer:Identity", "1, 1" ),
					No = table.Column<string>( type: "nvarchar(450)", nullable: false ),
					PartId = table.Column<int>( type: "int", nullable: false ),
					ColorId = table.Column<int>( type: "int", nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_Elements", x => x.Id );
					_ = table.ForeignKey(
						name: "FK_Elements_Colors_ColorId",
						column: x => x.ColorId,
						principalTable: "Colors",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade );
					_ = table.ForeignKey(
						name: "FK_Elements_Parts_PartId",
						column: x => x.PartId,
						principalTable: "Parts",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade );
				} );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Parts_Name",
				table: "Parts",
				column: "Name" );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Parts_No",
				table: "Parts",
				column: "No",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Colors_HexValue",
				table: "Colors",
				column: "HexValue",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Colors_Name",
				table: "Colors",
				column: "Name",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Elements_ColorId",
				table: "Elements",
				column: "ColorId" );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Elements_No",
				table: "Elements",
				column: "No",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Elements_PartId_ColorId",
				table: "Elements",
				columns: new[] { "PartId", "ColorId" },
				unique: true );
		}

		protected override void Down( MigrationBuilder migrationBuilder )
		{
			_ = migrationBuilder.DropTable(
				name: "Elements" );

			_ = migrationBuilder.DropTable(
				name: "Colors" );

			_ = migrationBuilder.DropIndex(
				name: "IX_Parts_Name",
				table: "Parts" );

			_ = migrationBuilder.DropIndex(
				name: "IX_Parts_No",
				table: "Parts" );
		}
	}
}
