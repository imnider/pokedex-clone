using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class PokemonAbility
{
    public int PokemonId { get; set; }

    public Guid AbilityId { get; set; }

    public bool IsHidden { get; set; }

    public int Slot { get; set; }

    public virtual Ability Ability { get; set; } = null!;

    public virtual Pokemon Pokemon { get; set; } = null!;
}
