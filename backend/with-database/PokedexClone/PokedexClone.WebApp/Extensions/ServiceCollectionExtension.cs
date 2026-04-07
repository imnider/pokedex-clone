using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Services;
using PokedexClone.Domain.Database.SqlServer.Context;
using PokedexClone.Domain.Interfaces.Repositories;
using PokedexClone.Infrastructure.Persistence.SqlServer.Repositories;
using PokedexClone.WebApp.Middlewares;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace PokedexClone.WebApp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddCore(this IServiceCollection services, IConfiguration configaration)
        {
            services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();

            // Database
            services.AddSqlServer<PokedexCloneContext>(configaration.GetConnectionString("Database"));

            // Repositories
            services.AddRepositories();

            // Services
            services.AddServices();

            // Middlewares
            services.AddMiddlewares();

            // Logging
            AddLogging(services);
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<IMoveRepository, MoveRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IMoveService, MoveService>();
        }

        public static void AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlerMiddleware>();
        }

        public static void AddLogging(this IServiceCollection services)
        {
            services.AddSerilog();

            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .MSSqlServer(
                    connectionString: "Server=localhost,1433;User=sa;Password=Admin1234@;Database=PokedexClone;TrustServerCertificate=True;",
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "LogEvents",
                        AutoCreateSqlTable = true
                    })
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "logs", "log.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
