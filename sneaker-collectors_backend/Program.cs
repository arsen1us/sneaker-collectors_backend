using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using sneaker_collectors_backend;
using System.Text;
using sneaker_collectors_backend.Services;
using sneaker_collectors_backend.Models.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policy =>
    {
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
        policy.WithOrigins("http://localhost:3000");
        policy.WithExposedHeaders("Authorization"); // Чтобы достать Header на фронте;
    });
});

var configuration = builder.Configuration;

// JwtToken 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JwtSettings:Issuer"],
            ValidAudience = configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
        };
    });

// БД
var configBuilder = new ConfigurationBuilder();
configBuilder.SetBasePath(Directory.GetCurrentDirectory());
configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();
string connectionString = config.GetConnectionString("Default");

builder.Services.AddDbContext<SneakerCollectorsContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Custom-Зависимости
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();
builder.Services.AddTransient<ISneakerOverviewService, SneakerOverviewService>();
builder.Services.AddTransient<ISnSampleService, SnSampleService>();
builder.Services.AddTransient<IDatabaseService<SneakerColor>, ColorService>();
builder.Services.AddTransient<ITechnologyService, TechnologyService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Default");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
