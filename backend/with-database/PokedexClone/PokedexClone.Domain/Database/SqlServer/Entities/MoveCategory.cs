using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class MoveCategory
{
    public int MoveCategoryId { get; set; }

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<Move> Moves { get; set; } = new List<Move>();
}
