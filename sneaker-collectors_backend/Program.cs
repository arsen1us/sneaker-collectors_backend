using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using sneaker_collectors_backend;
using sneaker_collectors_backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var configBuilder = new ConfigurationBuilder();
configBuilder.SetBasePath(Directory.GetCurrentDirectory());
configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();
string connectionString = config.GetConnectionString("Default");

builder.Services.AddDbContext<SneakerCollectorsContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
