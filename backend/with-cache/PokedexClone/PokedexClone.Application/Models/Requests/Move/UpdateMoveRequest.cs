namespace PokedexClone.Application.Models.Requests.Move
{
    public class UpdateMoveRequest
    {
        public int? TypeID { get; set; } = null;
        public int? MoveCategoryID { get; set; } = null;
        public string? DisplayName { get; set; } = null;
        public int? Power { get; set; } = null;
        public int? Accuracy { get; set; } = null;
        public int? MinPP { get; set; } = null;
        public int? MaxPP { get; set; } = null;
        public string? Effect { get; set; } = null;
    }
}
