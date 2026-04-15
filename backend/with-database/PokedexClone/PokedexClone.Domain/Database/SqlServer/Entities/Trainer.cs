using System;
using System.Collections.Generic;

namespace PokedexClone.Domain.Database.SqlServer.Entities;

public partial class Trainer
{
    public Guid TrainerId { get; set; }

    public string UserName { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
