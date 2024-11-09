using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.AspNetCore.Authentication.OAuth;
using LibraryAPI.Data;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

Console.WriteLine($"Issuer: {jwtSettings["Issuer"]}");
Console.WriteLine($"Audience: {jwtSettings["Audience"]}");
Console.WriteLine($"SecretKey: {jwtSettings["SecretKey"]}");


if (string.IsNullOrEmpty(secretKey))
{
	throw new ArgumentNullException(nameof(secretKey), "SecretKey is not configured in the appsettings.json");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
{
	options.RequireHttpsMetadata = false;
	options.SaveToken = true;
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidIssuer = jwtSettings["Issuer"],
		ValidateAudience = true,
		ValidAudience = jwtSettings["Audience"],
		ValidateLifetime = false,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
		ValidateIssuerSigningKey = true,
		ClockSkew = TimeSpan.Zero,
	};
});


builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure JWT authentication


// Configure DbContext
builder.Services.AddDbContext<LibraryContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
