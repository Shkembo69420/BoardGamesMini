using BoardGamesMini.Data;
using BoardGamesMini.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGamesMini.Data.Migrations;

[DbContext(typeof(BoardGamesDbContext))]
partial class BoardGamesDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "10.0.13")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        modelBuilder.Entity<BoardGame>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnType("INTEGER");
            entity.Property(e => e.Category).IsRequired().HasMaxLength(50).HasColumnType("TEXT");
            entity.Property(e => e.Description).IsRequired().HasMaxLength(1000).HasColumnType("TEXT");
            entity.Property(e => e.MaxPlayers).HasColumnType("INTEGER");
            entity.Property(e => e.MinPlayers).HasColumnType("INTEGER");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100).HasColumnType("TEXT");
            entity.HasKey(e => e.Id);
            entity.ToTable("BoardGames");
        });
    }
}
