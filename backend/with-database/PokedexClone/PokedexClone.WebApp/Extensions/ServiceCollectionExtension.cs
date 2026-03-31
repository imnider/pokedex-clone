using PokedexClone.Application.Interfaces.Services;
using PokedexClone.Application.Services;
using PokedexClone.Domain.Database.SqlServer.Context;
using PokedexClone.Domain.Interfaces.Repositories;
using PokedexClone.Infrastructure.Persistence.SqlServer.Repositories;
using PokedexClone.WebApp.Middlewares;

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
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPokemonRepository, PokemonRepository>();
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
    }
}
