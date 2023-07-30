global using Service.Models;
using Microsoft.EntityFrameworkCore;
using Service.Data;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

