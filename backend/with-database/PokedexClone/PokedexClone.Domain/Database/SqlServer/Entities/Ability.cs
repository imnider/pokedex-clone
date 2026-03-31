using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class Ability
{
    public Guid AbilityId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string Effect { get; set; } = null!;

    public virtual ICollection<PokemonAbility> PokemonAbilities { get; set; } = new List<PokemonAbility>();
}
