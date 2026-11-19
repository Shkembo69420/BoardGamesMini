using BoardGamesMini.Data;
using BoardGamesMini.Data.Entities;
using BoardGamesMini.Services.Contracts;

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
            .OrderBy(game => game.Name)
            .ToList();
    }
}
