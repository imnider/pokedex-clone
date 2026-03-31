using PokedexClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace PokedexClone.Application.Models.Requests.Move
{
    public class CreateMoveRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int TypeID { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int MoveCategoryID { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(30, ErrorMessage = ValidationConstants.MAX_LENGHT)]
        public string DisplayName { get; set; } = null!;

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int Power { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int Accuracy { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int MinPP { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public int MaxPP { get; set; }

        [MaxLength(255, ErrorMessage = ValidationConstants.MAX_LENGHT)]
        public string Effect { get; set; } = "Inflicts regular damage with no additional effect.";
    }
}
