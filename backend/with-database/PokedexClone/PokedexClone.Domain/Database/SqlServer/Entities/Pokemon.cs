using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class Pokemon
{
    public int PokemonId { get; set; }

    public Guid EvolutionChainId { get; set; }

    public string Description { get; set; } = null!;

    public int Generation { get; set; }

    public int Hp { get; set; }

    public int Attack { get; set; }

    public int Defense { get; set; }

    public int SpecialAttack { get; set; }

    public int? SpecialDefense { get; set; }

    public int Speed { get; set; }

    public virtual EvolutionChain EvolutionChain { get; set; } = null!;

    public virtual ICollection<PokemonAbility> PokemonAbilities { get; set; } = new List<PokemonAbility>();

    public virtual ICollection<PokemonEvolution> PokemonEvolutionFromPokemons { get; set; } = new List<PokemonEvolution>();

    public virtual ICollection<PokemonEvolution> PokemonEvolutionToPokemons { get; set; } = new List<PokemonEvolution>();

    public virtual ICollection<PokemonMove> PokemonMoves { get; set; } = new List<PokemonMove>();

    public virtual ICollection<PokemonType> PokemonTypes { get; set; } = new List<PokemonType>();
}
