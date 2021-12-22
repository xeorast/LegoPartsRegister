using LegoPartsRegister.Data;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

_ = builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_ = builder.Services.AddEndpointsApiExplorer();
_ = builder.Services.AddSwaggerGen();


_ = builder.Services.AddNpgsql<AppDbContext>(
	builder.Configuration.GetConnectionString( "postgresConnection" ), 
	  pgob => pgob.MigrationsAssembly( "LegoPartsRegister.Migrations.Pg" ), 
	  ob => ob.UseLoggerFactory( LoggerFactory.Create( factoryBuilder => factoryBuilder.AddConsole() ) )
	);


var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
	_ = app.UseSwagger();
	_ = app.UseSwaggerUI();
}

_ = app.UseHttpsRedirection();

_ = app.UseAuthorization();

_ = app.MapControllers();

app.Run();
