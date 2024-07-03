using Microsoft.EntityFrameworkCore;
using Practica2.Models;
using Practica2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddDbContext<VentaspruebaContext>((options) => options.UseSqlServer(builder.Configuration.GetConnectionString("DefautlConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
