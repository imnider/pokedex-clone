using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class MachineType
{
    public int MachineTypeId { get; set; }

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<PokemonMove> PokemonMoves { get; set; } = new List<PokemonMove>();
}
