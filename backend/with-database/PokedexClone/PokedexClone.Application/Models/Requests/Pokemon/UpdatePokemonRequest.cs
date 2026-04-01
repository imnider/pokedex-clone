using PokedexClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace PokedexClone.Application.Models.Requests.Pokemon
{
    public class UpdatePokemonRequest
    {
        public int? PokemonID { get; set; } = null;

        [MaxLength(30, ErrorMessage = ValidationConstants.MAX_LENGHT)]
        public string? DisplayName { get; set; } = null;

        [MaxLength(255, ErrorMessage = ValidationConstants.MAX_LENGHT)]
        public string? Description { get; set; } = null;

        [MaxLength(255, ErrorMessage = ValidationConstants.MAX_LENGHT)]
        public string? SpriteUrl { get; set; } = null;

        public int? Generation { get; set; } = null;
        public int? HP { get; set; } = null;
        public int? Attack { get; set; } = null;
        public int? Defense { get; set; } = null;
        public int? SpecialAttack { get; set; } = null;
        public int? SpecialDefense { get; set; } = null;
        public int? Speed { get; set; } = null;
    }
}
