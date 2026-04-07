using PokedexClone.Application.Models.Responses;

namespace PokedexClone.Application.Helpers
{
    public static class ResponsesHelper
    {
        public static GenericResponse<T> Create<T>(T data, string? message = null, List<string>? errors = null)
        {
            var response = new GenericResponse<T>
            {
                Message = message ?? "Solicitud exitosa.",
                Data = data,
                Errors = errors ?? []
            };
            return response;
        }
    }
}
