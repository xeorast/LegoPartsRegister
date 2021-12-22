global using LegoPartsRegister.Api.Services;
using LegoPartsRegister.Api;
using LegoPartsRegister.Data;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
Startup.ConfigureServices( builder );


var app = builder.Build();

// Configure the HTTP request pipeline.
Startup.Configure( app );

app.Run();
