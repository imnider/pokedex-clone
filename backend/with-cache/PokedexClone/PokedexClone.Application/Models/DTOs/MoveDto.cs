namespace PokedexClone.Application.Models.DTOs
{
    public class MoveDto
    {
        public Guid MoveID { get; set; }
        public int TypeID { get; set; }
        public int MoveCategoryID { get; set; }
        public string DisplayName { get; set; } = null!;
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public int MinPP { get; set; }
        public int MaxPP { get; set; }
        public string Effect { get; set; } = null!;
    }
}
