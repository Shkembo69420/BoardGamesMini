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

        var strategy = db.Categories.First(category => category.Name == "Стратегическа");
        var party = db.Categories.First(category => category.Name == "Парти");
        var logic = db.Categories.First(category => category.Name == "Логическа");

        var catanStudio = db.Publishers.First(publisher => publisher.Name == "Catan Studio");
        var libellud = db.Publishers.First(publisher => publisher.Name == "Libellud");
        var classicGames = db.Publishers.First(publisher => publisher.Name == "Класически игри");

        db.BoardGames.AddRange(
            new BoardGame
            {
                Name = "Catan",
                Category = strategy,
                Publisher = catanStudio,
                MinPlayers = 3,
                MaxPlayers = 4,
                Description = "Играчите събират ресурси, търгуват и развиват своите селища."
            },
            new BoardGame
            {
                Name = "Dixit",
                Category = party,
                Publisher = libellud,
                MinPlayers = 3,
                MaxPlayers = 6,
                Description = "Асоциативна игра с красиви илюстрирани карти."
            },
            new BoardGame
            {
                Name = "Шах",
                Category = logic,
                Publisher = classicGames,
                MinPlayers = 2,
                MaxPlayers = 2,
                Description = "Класическа стратегическа игра за двама играчи."
            });

        db.SaveChanges();
    }

    public static void SeedReferenceData(BoardGamesDbContext db)
    {
        if (!db.Categories.Any(category => category.Name == "Стратегическа"))
        {
            db.Categories.Add(new Category { Name = "Стратегическа", Description = "Игри с планиране и тактика." });
        }

        if (!db.Categories.Any(category => category.Name == "Парти"))
        {
            db.Categories.Add(new Category { Name = "Парти", Description = "Игри за компания и забавление." });
        }

        if (!db.Categories.Any(category => category.Name == "Логическа"))
        {
            db.Categories.Add(new Category { Name = "Логическа", Description = "Игри за мислене и логика." });
        }

        if (!db.Publishers.Any(publisher => publisher.Name == "Catan Studio"))
        {
            db.Publishers.Add(new Publisher { Name = "Catan Studio", Country = "Германия", Website = "https://www.catan.com" });
        }

        if (!db.Publishers.Any(publisher => publisher.Name == "Libellud"))
        {
            db.Publishers.Add(new Publisher { Name = "Libellud", Country = "Франция", Website = "https://www.libellud.com" });
        }

        if (!db.Publishers.Any(publisher => publisher.Name == "Класически игри"))
        {
            db.Publishers.Add(new Publisher { Name = "Класически игри", Country = "Международен" });
        }

        db.SaveChanges();
    }
}
