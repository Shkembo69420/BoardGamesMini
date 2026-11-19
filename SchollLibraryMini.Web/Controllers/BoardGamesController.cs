using BoardGamesMini.Data;
using Microsoft.AspNetCore.Mvc;

namespace SchollLibraryMini.Web.Controllers;

public class BoardGamesController : Controller
{
    private readonly BoardGamesDbContext _context;

    public BoardGamesController(BoardGamesDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var boardGames = _context.BoardGames
            .OrderBy(game => game.Name)
            .ToList();

        return View(boardGames);
    }

    public IActionResult Create()
    {
        return View();
    }
}
