using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Data;
using SmartHomeAPI.Interfaces;
using SmartHomeAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<SmartHomeDBContext>(options => options.UseMySQL(
    builder.Configuration.GetConnectionString("SmartHomeDBConnectionString")));

builder.Services.AddScoped<IRelayRepository, RelayRepository>();
builder.Services.AddScoped<ITempAndHumidRepository,TempAndHumidRepository>();
builder.Services.AddScoped<IToggleRepository, ToggleRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
