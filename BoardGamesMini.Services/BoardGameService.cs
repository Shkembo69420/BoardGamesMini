using BoardGamesMini.Data;
using BoardGamesMini.Data.Entities;
using BoardGamesMini.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesMini.Services;

public class BoardGameService : IBoardGameService
{
    private readonly BoardGamesDbContext _context;

    public BoardGameService(BoardGamesDbContext context)
    {
        _context = context;
    }

    public List<BoardGame> GetAll()
    {
        return _context.BoardGames
            .Include(game => game.Category)
            .Include(game => game.Publisher)
            .OrderBy(game => game.Name)
            .ToList();
    }
}
