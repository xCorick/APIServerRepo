using API_Capacitacion.Data;
using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.Data.Servicios;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
PostgresSQLConfiguration postgressqlconfiguration = new PostgresSQLConfiguration(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "");
builder.Services.AddSingleton(postgressqlconfiguration);

builder.Services.AddScoped<IUserServices, UserService>();
builder.Services.AddScoped<ITareaServices, TareaService>();

//servicios


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
