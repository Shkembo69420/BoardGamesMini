using BoardGamesMini.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGamesMini.Data.Migrations;

[DbContext(typeof(BoardGamesDbContext))]
[Migration("202611200001_AddCategoriesAndPublishers")]
public partial class AddCategoriesAndPublishers : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Categories", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Publishers",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                Country = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                Website = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Publishers", x => x.Id));

        migrationBuilder.CreateIndex("IX_Categories_Name", "Categories", "Name", unique: true);
        migrationBuilder.CreateIndex("IX_Publishers_Name", "Publishers", "Name", unique: true);

        // Preserve existing category names from the original BoardGames table.
        migrationBuilder.Sql("INSERT INTO Categories (Name, Description) SELECT DISTINCT Category, '' FROM BoardGames;");
        migrationBuilder.Sql("INSERT INTO Publishers (Name, Country, Website) VALUES ('Неизвестен', '', '');");

        // SQLite rebuild keeps existing game rows while replacing the old Category text column with foreign keys.
        migrationBuilder.Sql(@"
CREATE TABLE BoardGames_new (
    Id INTEGER NOT NULL CONSTRAINT PK_BoardGames PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    MinPlayers INTEGER NOT NULL,
    MaxPlayers INTEGER NOT NULL,
    Description TEXT NOT NULL,
    CategoryId INTEGER NOT NULL,
    PublisherId INTEGER NOT NULL,
    CONSTRAINT FK_BoardGames_Categories_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories (Id) ON DELETE RESTRICT,
    CONSTRAINT FK_BoardGames_Publishers_PublisherId FOREIGN KEY (PublisherId) REFERENCES Publishers (Id) ON DELETE RESTRICT
);
INSERT INTO BoardGames_new (Id, Name, MinPlayers, MaxPlayers, Description, CategoryId, PublisherId)
SELECT b.Id, b.Name, b.MinPlayers, b.MaxPlayers, b.Description, c.Id, p.Id
FROM BoardGames b
JOIN Categories c ON c.Name = b.Category
CROSS JOIN Publishers p
WHERE p.Name = 'Неизвестен';
DROP TABLE BoardGames;
ALTER TABLE BoardGames_new RENAME TO BoardGames;
CREATE INDEX IX_BoardGames_CategoryId ON BoardGames (CategoryId);
CREATE INDEX IX_BoardGames_PublisherId ON BoardGames (PublisherId);");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
CREATE TABLE BoardGames_old (
    Id INTEGER NOT NULL CONSTRAINT PK_BoardGames PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Category TEXT NOT NULL,
    MinPlayers INTEGER NOT NULL,
    MaxPlayers INTEGER NOT NULL,
    Description TEXT NOT NULL
);
INSERT INTO BoardGames_old (Id, Name, Category, MinPlayers, MaxPlayers, Description)
SELECT b.Id, b.Name, c.Name, b.MinPlayers, b.MaxPlayers, b.Description
FROM BoardGames b JOIN Categories c ON c.Id = b.CategoryId;
DROP TABLE BoardGames;
ALTER TABLE BoardGames_old RENAME TO BoardGames;");

        migrationBuilder.DropTable(name: "Categories");
        migrationBuilder.DropTable(name: "Publishers");
    }
}
