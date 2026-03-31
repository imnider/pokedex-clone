namespace PokedexClone.Application.Models.DTOs
{
    public class PokemonDto
    {
        public int PokemonID { get; set; }
        public Guid EvolutionChainID { get; set; }
        public string DisplayName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Generation { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}