using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Models.DTOs;
using PokedexClone.Application.Services;
using PokedexClone.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Services
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IMoveService, MoveService>();

builder.Services.AddSingleton<Cache<PokemonDto>>();
builder.Services.AddSingleton<Cache<MoveDto>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
