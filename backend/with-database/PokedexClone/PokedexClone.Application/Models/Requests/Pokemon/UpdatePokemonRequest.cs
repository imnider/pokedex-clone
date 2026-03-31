namespace PokedexClone.Application.Models.Requests.Pokemon
{
    public class UpdatePokemonRequest
    {
        public int? PokemonID { get; set; } = null;
        public Guid? EvolutionChainID { get; set; } = null;
        public string? DisplayName { get; set; } = null;
        public string? Description { get; set; } = null;
        public int? Generation { get; set; } = null;
        public int? HP { get; set; } = null;
        public int? Attack { get; set; } = null;
        public int? Defense { get; set; } = null;
        public int? SpecialAttack { get; set; } = null;
        public int? SpecialDefense { get; set; } = null;
        public int? Speed { get; set; } = null;
    }
}
