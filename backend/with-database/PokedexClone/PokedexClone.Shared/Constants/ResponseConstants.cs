namespace PokedexClone.Shared.Constants
{
    public static class ResponseConstants
    {
        // Pokemon
        public const string POKEMON_NOT_EXISTS = "El pokemon no existe.";

        // Move
        public const string MOVE_NOT_EXISTS = "El movimiento no existe";

        public static string ERROR_UNEXPECTED(string traceId)
        {
            return $"Ha ocurrido un error inesperado. Contacte con soporte mencionando el siguiente código de error: {traceId}";
        }
    }
}
