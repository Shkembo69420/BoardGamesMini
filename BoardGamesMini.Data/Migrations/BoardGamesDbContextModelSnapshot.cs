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

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnType("INTEGER");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnType("TEXT");
            entity.Property(e => e.Description).IsRequired().HasMaxLength(300).HasColumnType("TEXT");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Name).IsUnique();
            entity.ToTable("Categories");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnType("INTEGER");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100).HasColumnType("TEXT");
            entity.Property(e => e.Country).IsRequired().HasMaxLength(60).HasColumnType("TEXT");
            entity.Property(e => e.Website).IsRequired().HasMaxLength(200).HasColumnType("TEXT");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Name).IsUnique();
            entity.ToTable("Publishers");
        });

        modelBuilder.Entity<BoardGame>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnType("INTEGER");
            entity.Property(e => e.Description).IsRequired().HasMaxLength(1000).HasColumnType("TEXT");
            entity.Property(e => e.MaxPlayers).HasColumnType("INTEGER");
            entity.Property(e => e.MinPlayers).HasColumnType("INTEGER");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100).HasColumnType("TEXT");
            entity.Property(e => e.CategoryId).HasColumnType("INTEGER");
            entity.Property(e => e.PublisherId).HasColumnType("INTEGER");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.CategoryId);
            entity.HasIndex(e => e.PublisherId);
            entity.ToTable("BoardGames");

            entity.HasOne(e => e.Category)
                .WithMany(e => e.BoardGames)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasOne(e => e.Publisher)
                .WithMany(e => e.BoardGames)
                .HasForeignKey(e => e.PublisherId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });
    }
}
