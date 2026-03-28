using PokedexClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace PokedexClone.Application.Models.Requests.Pokemon
{
    public class CreatePokemonRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public Guid EvolutionChainID { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public string DisplayName { get; set; } = null!;

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int Generation { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int HP { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int Attack { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int Defense { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int SpecialAttack { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int SpecialDefense { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int Speed { get; set; }
    }
}
