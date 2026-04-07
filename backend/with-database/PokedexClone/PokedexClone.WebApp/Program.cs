using PokedexClone.WebApp.Extensions;
using PokedexClone.WebApp.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// SeriLog
builder.Host.UseSerilog();

// Add Core
builder.Services.AddCore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
