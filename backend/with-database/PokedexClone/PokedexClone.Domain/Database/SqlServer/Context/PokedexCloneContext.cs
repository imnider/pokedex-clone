using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PokedexClone.Domain.Database.SqlServer.Entities;

namespace PokedexClone.Domain.Database.SqlServer.Context;

public partial class PokedexCloneContext : DbContext
{
    public PokedexCloneContext()
    {
    }

    public PokedexCloneContext(DbContextOptions<PokedexCloneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ability> Abilities { get; set; }

    public virtual DbSet<ElementalType> ElementalTypes { get; set; }

    public virtual DbSet<EvolutionChain> EvolutionChains { get; set; }

    public virtual DbSet<MachineType> MachineTypes { get; set; }

    public virtual DbSet<Move> Moves { get; set; }

    public virtual DbSet<MoveCategory> MoveCategories { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<PokemonAbility> PokemonAbilities { get; set; }

    public virtual DbSet<PokemonEvolution> PokemonEvolutions { get; set; }

    public virtual DbSet<PokemonMove> PokemonMoves { get; set; }

    public virtual DbSet<PokemonType> PokemonTypes { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;User=sa;Password=Admin1234@;Database=PokedexClone;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ability>(entity =>
        {
            entity.HasKey(e => e.AbilityId).HasName("PK__Ability__88B2505F9622FF3A");

            entity.ToTable("Ability");

            entity.Property(e => e.AbilityId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("AbilityID");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Effect)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ElementalType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Elementa__516F0395B0B8B68C");

            entity.ToTable("ElementalType");

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EvolutionChain>(entity =>
        {
            entity.HasKey(e => e.EvolutionChainId).HasName("PK__Evolutio__A342BA5ACE1F7B63");

            entity.ToTable("EvolutionChain");

            entity.Property(e => e.EvolutionChainId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("EvolutionChainID");
        });

        modelBuilder.Entity<MachineType>(entity =>
        {
            entity.HasKey(e => e.MachineTypeId).HasName("PK__MachineT__52CA84A035948100");

            entity.ToTable("MachineType");

            entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Move>(entity =>
        {
            entity.HasKey(e => e.MoveId).HasName("PK__Move__A931A43CBDC9B932");

            entity.ToTable("Move");

            entity.Property(e => e.MoveId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("MoveID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Effect)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("Inflicts regular damage with no additional effect.");
            entity.Property(e => e.MaxPp).HasColumnName("MaxPP");
            entity.Property(e => e.MinPp).HasColumnName("MinPP");
            entity.Property(e => e.MoveCategoryId).HasColumnName("MoveCategoryID");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.MoveCategory).WithMany(p => p.Moves)
                .HasForeignKey(d => d.MoveCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Move__MoveCatego__4AB81AF0");

            entity.HasOne(d => d.Type).WithMany(p => p.Moves)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Move__TypeID__49C3F6B7");
        });

        modelBuilder.Entity<MoveCategory>(entity =>
        {
            entity.HasKey(e => e.MoveCategoryId).HasName("PK__MoveCate__E687A05E63D3B378");

            entity.ToTable("MoveCategory");

            entity.Property(e => e.MoveCategoryId).HasColumnName("MoveCategoryID");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => e.PokemonId).HasName("PK__Pokemon__69C4E9C3342B3AEA");

            entity.ToTable("Pokemon");

            entity.Property(e => e.PokemonId).HasColumnName("PokemonID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DisplayName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Hp).HasColumnName("HP");
            entity.Property(e => e.SpriteUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PokemonAbility>(entity =>
        {
            entity.HasKey(e => new { e.PokemonId, e.Slot }).HasName("PK_PokemonAbility_Pokemon_Slot");

            entity.ToTable("PokemonAbility");

            entity.HasIndex(e => new { e.PokemonId, e.AbilityId }, "UK_PokemonAbility_Pokemon_Ability").IsUnique();

            entity.Property(e => e.PokemonId).HasColumnName("PokemonID");
            entity.Property(e => e.AbilityId).HasColumnName("AbilityID");

            entity.HasOne(d => d.Ability).WithMany(p => p.PokemonAbilities)
                .HasForeignKey(d => d.AbilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PokemonAb__Abili__60A75C0F");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.PokemonAbilities)
                .HasForeignKey(d => d.PokemonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PokemonAb__Pokem__5FB337D6");
        });

        modelBuilder.Entity<PokemonEvolution>(entity =>
        {
            entity.HasKey(e => new { e.FromPokemonId, e.ToPokemonId }).HasName("PK_PokemonEvolution_From_To");

            entity.ToTable("PokemonEvolution");

            entity.Property(e => e.FromPokemonId).HasColumnName("FromPokemonID");
            entity.Property(e => e.ToPokemonId).HasColumnName("ToPokemonID");
            entity.Property(e => e.ConditionDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsTrade).HasDefaultValue(false);
            entity.Property(e => e.RequiredItem)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FromPokemon).WithMany(p => p.PokemonEvolutionFromPokemons)
                .HasForeignKey(d => d.FromPokemonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PokemonEv__FromP__6477ECF3");

            entity.HasOne(d => d.ToPokemon).WithMany(p => p.PokemonEvolutionToPokemons)
                .HasForeignKey(d => d.ToPokemonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PokemonEv__ToPok__656C112C");
        });

        modelBuilder.Entity<PokemonMove>(entity =>
        {
            entity.HasKey(e => new { e.PokemonId, e.MoveId }).HasName("PK_PokemonMove_Pokemon_Move");

            entity.ToTable("PokemonMove");

            entity.Property(e => e.PokemonId).HasColumnName("PokemonID");
            entity.Property(e => e.MoveId).HasColumnName("MoveID");
            entity.Property(e => e.MachineTypeId).HasColumnName("MachineTypeID");

            entity.HasOne(d => d.MachineType).WithMany(p => p.PokemonMoves)
                .HasForeignKey(d => d.MachineTypeId)
                .HasConstraintName("FK__PokemonMo__Machi__5441852A");

            entity.HasOne(d => d.Move).WithMany(p => p.PokemonMoves)
                .HasForeignKey(d => d.MoveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PokemonMo__MoveI__534D60F1");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.PokemonMoves)
                .HasForeignKey(d => d.PokemonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PokemonMo__Pokem__52593CB8");
        });

        modelBuilder.Entity<PokemonType>(entity =>
        {
            entity.HasKey(e => new { e.PokemonId, e.Slot }).HasName("PK_PokemonType_Pokemon_Slot");

            entity.ToTable("PokemonType");

            entity.HasIndex(e => new { e.PokemonId, e.TypeId }, "UK_PokemonType_Pokemon_Type").IsUnique();

            entity.Property(e => e.PokemonId).HasColumnName("PokemonID");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.PokemonTypes)
                .HasForeignKey(d => d.PokemonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PokemonTy__Pokem__59FA5E80");

            entity.HasOne(d => d.Type).WithMany(p => p.PokemonTypes)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PokemonTy__TypeI__5AEE82B9");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainer__366A1B9C2E0F08BF");

            entity.ToTable("Trainer");

            entity.HasIndex(e => e.Email, "UQ__Trainer__A9D105346CC48B6C").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Trainer__C9F28456B71AEF1D").IsUnique();

            entity.Property(e => e.TrainerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("TrainerID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
