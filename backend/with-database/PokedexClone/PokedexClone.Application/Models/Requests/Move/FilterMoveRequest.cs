namespace PokedexClone.Application.Models.Requests.Move
{
    public class FilterMoveRequest : BaseRequest
    {
        public int? TypeID { get; set; }
        public int? MoveCategoryID { get; set; }
        public int? Power { get; set; }
        public int? Accuracy { get; set; }
        public int? MinPP { get; set; }
        public int? MaxPP { get; set; }
    }
}
