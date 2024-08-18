using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using sneaker_collectors_backend;

var builder = WebApplication.CreateBuilder(args);

var configBuilder = new ConfigurationBuilder();
configBuilder.SetBasePath(Directory.GetCurrentDirectory());
configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();
string connectionString = config.GetConnectionString("Default");

builder.Services.AddDbContext<SneakerCollectorsContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
