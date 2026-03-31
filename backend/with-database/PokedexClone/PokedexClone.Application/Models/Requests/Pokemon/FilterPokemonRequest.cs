namespace PokedexClone.Application.Models.Requests.Pokemon
{
    public class FilterPokemonRequest : BaseRequest
    {
        public string? DisplayName { get; set; }
        public int? Generation { get; set; }
        public int? HP { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public int? SpecialAttack { get; set; }
        public int? SpecialDefense { get; set; }
        public int? Speed { get; set; }
    }
}
