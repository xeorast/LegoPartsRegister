using LegoPartsRegister.Domain.Models;
using LegoPartsRegister.Domain.Relations;
using Microsoft.EntityFrameworkCore;

namespace LegoPartsRegister.Data;

public class AppDbContext : DbContext
{
	public AppDbContext( DbContextOptions options )
		: base( options )
	{
		ArgumentNullException.ThrowIfNull( Users );
		ArgumentNullException.ThrowIfNull( Parts );
		ArgumentNullException.ThrowIfNull( Colors );
		ArgumentNullException.ThrowIfNull( Elements );
	}

	protected override void OnModelCreating( ModelBuilder modelBuilder )
	{
		// part <= element => color
		_ = modelBuilder.Entity<PartModel>()
			.HasMany( p => p.Colors )
			.WithMany( c => c.Parts )
			.UsingEntity<ElementModel>(
				j => j
				.HasOne( e => e.Color )
				.WithMany( c => c.Elements )
				.HasForeignKey( e => e.ColorId ),
				j => j
				.HasOne( e => e.Part )
				.WithMany( p => p.Elements )
				.HasForeignKey( e => e.PartId )
			);

	}

	public DbSet<UserModel> Users { get; set; }
	public DbSet<PartModel> Parts { get; set; }
	public DbSet<ColorModel> Colors { get; set; }
	public DbSet<ElementModel> Elements { get; set; }

}
