using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class Move
{
    public Guid MoveId { get; set; }

    public int TypeId { get; set; }

    public int MoveCategoryId { get; set; }

    public string DisplayName { get; set; } = null!;

    public int Power { get; set; }

    public int Accuracy { get; set; }

    public int MinPp { get; set; }

    public int MaxPp { get; set; }

    public string? Effect { get; set; }

    public virtual MoveCategory MoveCategory { get; set; } = null!;

    public virtual ICollection<PokemonMove> PokemonMoves { get; set; } = new List<PokemonMove>();

    public virtual Type Type { get; set; } = null!;
}
