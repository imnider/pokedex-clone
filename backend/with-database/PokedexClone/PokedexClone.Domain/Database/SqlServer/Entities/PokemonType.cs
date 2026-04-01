using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class PokemonType
{
    public int PokemonId { get; set; }

    public int TypeId { get; set; }

    public int Slot { get; set; }

    public virtual Pokemon Pokemon { get; set; } = null!;

    public virtual ElementalType Type { get; set; } = null!;
}
