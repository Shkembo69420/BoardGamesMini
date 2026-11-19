using BoardGamesMini.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace SchollLibraryMini.Web.Controllers;

public class BoardGamesController : Controller
{
    private readonly IBoardGameService _boardGameService;

    public BoardGamesController(IBoardGameService boardGameService)
    {
        _boardGameService = boardGameService;
    }

    public IActionResult Index()
    {
        var boardGames = _boardGameService.GetAll();
        return View(boardGames);
    }

    public IActionResult Create()
    {
        return View();
    }
}
