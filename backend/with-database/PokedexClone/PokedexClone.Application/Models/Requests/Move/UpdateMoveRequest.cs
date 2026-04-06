using PokedexClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace PokedexClone.Application.Models.Requests.Move
{
    public class UpdateMoveRequest
    {
        public int? TypeID { get; set; } = null;
        public int? MoveCategoryID { get; set; } = null;

        [MaxLength(30, ErrorMessage = ValidationConstants.MAX_LENGHT)]
        public string? DisplayName { get; set; } = null;

        public int? Power { get; set; } = null;
        public int? Accuracy { get; set; } = null;
        public int? MinPP { get; set; } = null;
        public int? MaxPP { get; set; } = null;

        [MaxLength(255, ErrorMessage = ValidationConstants.MAX_LENGHT)]
        public string? Effect { get; set; } = null;
    }
}
