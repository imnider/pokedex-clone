using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class PokemonMove
{
    public int PokemonId { get; set; }

    public Guid MoveId { get; set; }

    public int? MachineTypeId { get; set; }

    public int? RequiredLevel { get; set; }

    public bool RequiresMachine { get; set; }

    public virtual MachineType? MachineType { get; set; }

    public virtual Move Move { get; set; } = null!;

    public virtual Pokemon Pokemon { get; set; } = null!;
}
