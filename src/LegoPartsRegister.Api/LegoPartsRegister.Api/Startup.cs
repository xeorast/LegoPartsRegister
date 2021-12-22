using LegoPartsRegister.Data;

namespace LegoPartsRegister.Api;

public static class Startup
{
	// Add services to the container.
	public static void ConfigureServices( WebApplicationBuilder builder )
	{
		_ = builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		_ = builder.Services.AddEndpointsApiExplorer();
		_ = builder.Services.AddSwaggerGen();


		_ = builder.Services.AddNpgsql<AppDbContext>(
			builder.Configuration.GetConnectionString( "postgresConnection" ),
			  pgob => pgob.MigrationsAssembly( "LegoPartsRegister.Migrations.Pg" ),
			  ob => ob.UseLoggerFactory( LoggerFactory.Create( factoryBuilder => factoryBuilder.AddConsole() ) )
			);

		_ = builder.Services.AddScoped<IUsersService, UsersService>();

	}

	// Configure the HTTP request pipeline.
	public static void Configure( WebApplication app )
	{
		if ( app.Environment.IsDevelopment() )
		{
			_ = app.UseSwagger();
			_ = app.UseSwaggerUI();
		}

		_ = app.UseHttpsRedirection();

		_ = app.UseAuthorization();

		_ = app.MapControllers();
	}

}
