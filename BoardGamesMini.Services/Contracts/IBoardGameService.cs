using BoardGamesMini.Data.Entities;

namespace BoardGamesMini.Services.Contracts;

public interface IBoardGameService
{
    List<BoardGame> GetAll();
}
