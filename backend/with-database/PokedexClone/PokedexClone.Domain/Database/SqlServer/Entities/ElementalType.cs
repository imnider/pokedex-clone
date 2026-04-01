using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class ElementalType
{
    public int TypeId { get; set; }

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<Move> Moves { get; set; } = new List<Move>();

    public virtual ICollection<PokemonType> PokemonTypes { get; set; } = new List<PokemonType>();
}
