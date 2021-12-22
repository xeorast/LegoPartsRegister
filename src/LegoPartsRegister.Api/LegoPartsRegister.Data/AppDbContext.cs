using LegoPartsRegister.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LegoPartsRegister.Data;

public class AppDbContext : DbContext
{
	public AppDbContext( DbContextOptions options )
		: base( options )
	{
		ArgumentNullException.ThrowIfNull( Users );
	}

	public DbSet<UserModel> Users { get; set; }

}
