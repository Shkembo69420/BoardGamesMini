# BoardGamesMini

Учебно ASP.NET Core MVC приложение за настолни игри.

## Проекти
- `BoardGamesMini.Data` – Entity класове, `BoardGamesDbContext`, начални данни и EF Core миграции.
- `BoardGamesMini.Services` – `IBoardGameService` и `BoardGameService`.
- `SchollLibraryMini.Web` – MVC приложение, контролери, Razor изгледи и Dependency Injection.

## Entities и връзки
- `BoardGame` – име, минимален/максимален брой играчи, описание, `CategoryId` и `PublisherId`.
- `Category` – име, описание и колекция от настолни игри.
- `Publisher` – име, държава, уебсайт и колекция от настолни игри.

Връзките са One-to-Many: една категория има много настолни игри, както и един издател може да има много настолни игри.

## Стартиране
1. Отворете `SchoolLibraryMini.slnx` във Visual Studio.
2. Възстановете NuGet пакетите и изпълнете Build Solution.
3. В Package Manager Console изпълнете:

```powershell
Update-Database -Project BoardGamesMini.Data -StartupProject SchollLibraryMini.Web -Context BoardGamesDbContext
```

Миграцията `AddCategoriesAndPublishers` запазва старите записи и превръща текстовата категория в реална връзка към `Categories`. След това стартирайте `SchollLibraryMini.Web` и отворете `/BoardGames`.

В Development среда `DemoData.SeedReferenceData` добавя липсващи категории и издатели, а `DemoData.Seed` добавя примерните игри, ако таблицата е празна.
