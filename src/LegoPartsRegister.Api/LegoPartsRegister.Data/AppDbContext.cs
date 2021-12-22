using Microsoft.EntityFrameworkCore;

namespace LegoPartsRegister.Data;

public class AppDbContext : DbContext
{
	public AppDbContext( DbContextOptions options )
		: base( options )
	{
	}

}
