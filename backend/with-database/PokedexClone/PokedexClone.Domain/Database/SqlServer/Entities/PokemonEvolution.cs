using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class PokemonEvolution
{
    public int FromPokemonId { get; set; }

    public int ToPokemonId { get; set; }

    public int? MinLevel { get; set; }

    public bool? IsTrade { get; set; }

    public string? RequiredItem { get; set; }

    public string? ConditionDescription { get; set; }

    public virtual Pokemon FromPokemon { get; set; } = null!;

    public virtual Pokemon ToPokemon { get; set; } = null!;
}
