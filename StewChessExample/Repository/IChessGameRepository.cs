using ChessGame.Models;

namespace ChessGame.Repositories
{
    public interface IChessGameRepository
    {
	Task<ChessGameEvent> GetGameByIdAsync(int gameId);
	Task<ChessGameEvent> CreateAsync(string whitePlayer, string blackPlayer);
    }
}
