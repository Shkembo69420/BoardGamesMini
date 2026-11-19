using BoardGamesMini.Data.Entities;

namespace BoardGamesMini.Data;

public static class DemoData
{
    public static void Seed(BoardGamesDbContext db)
    {
        if (db.BoardGames.Any())
        {
            return;
        }

        db.BoardGames.AddRange(
            new BoardGame
            {
                Name = "Catan",
                Category = "Стратегическа",
                MinPlayers = 3,
                MaxPlayers = 4,
                Description = "Играчите събират ресурси, търгуват и развиват своите селища."
            },
            new BoardGame
            {
                Name = "Dixit",
                Category = "Парти",
                MinPlayers = 3,
                MaxPlayers = 6,
                Description = "Асоциативна игра с красиви илюстрирани карти."
            },
            new BoardGame
            {
                Name = "Шах",
                Category = "Логическа",
                MinPlayers = 2,
                MaxPlayers = 2,
                Description = "Класическа стратегическа игра за двама играчи."
            });

        db.SaveChanges();
    }
}
