using BoardGamesMini.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesMini.Data;

public class BoardGamesDbContext : DbContext
{
    public BoardGamesDbContext(DbContextOptions<BoardGamesDbContext> options)
        : base(options)
    {
    }

    public DbSet<BoardGame> BoardGames => Set<BoardGame>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BoardGame>(entity =>
        {
            entity.HasKey(game => game.Id);
            entity.Property(game => game.Name).IsRequired().HasMaxLength(100);
            entity.Property(game => game.Category).IsRequired().HasMaxLength(50);
            entity.Property(game => game.Description).IsRequired().HasMaxLength(1000);
        });
    }
}
