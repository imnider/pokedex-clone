using PokedexClone.Domain.Exceptions;

namespace PokedexClone.WebApp.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException exception)
            {

                throw;
            }
        }
    }
}
