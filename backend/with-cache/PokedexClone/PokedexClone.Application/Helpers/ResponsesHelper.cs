using PokedexClone.Application.Models.Responses;

namespace PokedexClone.Application.Helpers
{
    public static class ResponsesHelper
    {
        public static GenericResponse<T> Create<T>(T data, string message = "Solicitud exitosa.")
        {
            var response = new GenericResponse<T>
            {
                Message = message,
                Data = data
            };
            return response;
        }
    }
}
