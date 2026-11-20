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
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Publisher> Publishers => Set<Publisher>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(category => category.Id);
            entity.Property(category => category.Name).IsRequired().HasMaxLength(50);
            entity.Property(category => category.Description).HasMaxLength(300);
            entity.HasIndex(category => category.Name).IsUnique();
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(publisher => publisher.Id);
            entity.Property(publisher => publisher.Name).IsRequired().HasMaxLength(100);
            entity.Property(publisher => publisher.Country).HasMaxLength(60);
            entity.Property(publisher => publisher.Website).HasMaxLength(200);
            entity.HasIndex(publisher => publisher.Name).IsUnique();
        });

        modelBuilder.Entity<BoardGame>(entity =>
        {
            entity.HasKey(game => game.Id);
            entity.Property(game => game.Name).IsRequired().HasMaxLength(100);
            entity.Property(game => game.Description).IsRequired().HasMaxLength(1000);

            entity.HasOne(game => game.Category)
                .WithMany(category => category.BoardGames)
                .HasForeignKey(game => game.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(game => game.Publisher)
                .WithMany(publisher => publisher.BoardGames)
                .HasForeignKey(game => game.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
