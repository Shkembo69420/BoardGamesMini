# BoardGamesMini

Учебно ASP.NET Core MVC приложение за каталог на настолни игри.

## Проекти
- `BoardGamesMini.Data` – моделът `BoardGame`, `BoardGamesDbContext`, конфигурацията и миграциите.
- `SchollLibraryMini.Web` – MVC приложението, контролерите и Razor изгледите.
- `BoardGamesMini.Services` – интерфейсът `IBoardGameService` и реализацията `BoardGameService`.

## Технологии
.NET 10, ASP.NET Core MVC, Entity Framework Core 10.0.13 и SQLite. Запазени са framework и database provider-ът от първоначалното repository.

## Подготовка на базата
В Visual Studio отвори Tools → NuGet Package Manager → Package Manager Console и изпълни:

```powershell
Update-Database -Project BoardGamesMini.Data -StartupProject SchollLibraryMini.Web -Context BoardGamesDbContext
```

Миграцията `InitialCreate` създава таблицата `BoardGames`. Не изпълнявай повторно `Add-Migration InitialCreate`, защото миграцията вече е включена.

## Стартиране
Задай `SchollLibraryMini.Web` като Startup Project и стартирай приложението. В Development среда `DemoData.Seed` добавя три примерни игри, ако таблицата е празна. Отвори `/BoardGames`.

## Реализирано до текущия учебен етап
- Модел и бизнес валидации за положителен брой играчи и максимум не по-малък от минимума.
- EF Core контекст, Fluent API и начална миграция.
- Примерни данни и Razor таблица със списък на настолните игри.
- Сервизен слой с `GetAll()` и Dependency Injection.

Търсене, филтриране и пълните CRUD операции са следващи етапи и умишлено не са добавени тук.
