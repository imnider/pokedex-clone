namespace PokedexClone.Application.Models.Requests.Pokemon
{
    public class GetAllPokemonRequest
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
